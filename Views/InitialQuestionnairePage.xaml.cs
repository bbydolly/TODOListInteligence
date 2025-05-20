using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TODOListInteligence.Models;
using TODOListInteligence.Helpers;
using TODOListInteligence.Resources; // Para los textos multilingües
using Microsoft.Maui.Controls;
using TODOListInteligence.Resources.Strings;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using TODOListInteligence.Services;
using TODOListInteligence.Storage;

namespace TODOListInteligence.Views;

public partial class InitialQuestionnairePage : ContentPage
{
    private List<Question> questions;
    private int currentIndex = 0;
    private int? selectedOptionIndex = null;
    //private readonly List<UserAnswer> userAnswers = new();
    //private UserConfig userConfig;
    public InitialQuestionnairePage()
    {
        InitializeComponent();
        //Aplico idioma y tema según la config del usuario
        AppSettings.ApplyCulture();
        AppSettings.ApplyTheme();
        // Establece el texto del botón desde recursos
        NextButton.Text = AppResources.NextButtonText;
       
        //Limpio las respuestas previas del usuario
        UserConfig.Instance.UserAnswers.Clear();
        //cargo las preguntas del cuestionario
        LoadQuestionsAsync();
    }

    // Método asíncrono para cargar las preguntas del cuestionario según el idioma del usuario
    private async void LoadQuestionsAsync()
    {
        // Si userLenguaje es null, devuelvo es por defecto
        string userLang = UserConfig.Instance.UserLanguage ?? "es";
        string fileName = userLang == "es" ?
            "questions_es.json" :
            "questions_en.json";

        try
        {
            // Cargo el json correspondiente al idioma de forma asíncrona para que la UI no se bloquee
            using var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            using var reader = new StreamReader(stream);
            string json = await reader.ReadToEndAsync(); // Leo de forma asíncrona todo el contenido del archivo json 
                                                         // questions = JsonSerializer.Deserialize<List<Question>>(json);// lista de objetos question
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            questions = JsonSerializer.Deserialize<List<Question>>(json, options);

            Debug.WriteLine(questions.Count);
            //Si questions no es null cargo la pregunta
            if (questions?.Any() == true)
            {
                LoadCurrentQuestion();
            }
            else
            {
                await DisplayAlert(AppResources.ErrorTitle, AppResources.ErrorNoQuestions, AppResources.OkText);
            }
        }
        catch (Exception ex)
        {
            // Manejo de errores en la carga del archivo
            await DisplayAlert(AppResources.ErrorTitle, AppResources.ErrorNoQuestions, AppResources.OkText);
        }
    }

    //Muestra la pregunta actual y sus opciones
    private void LoadCurrentQuestion()
    {
        AppSettings.ApplyCulture();//fuerzo la aplicación del idioma

        selectedOptionIndex = null; //reseteo la opcion seleccionada
        NextButton.IsVisible = false;
        //NextButton.Text = AppResources.NextButtonText;

        OptionsPanel.Children.Clear();
        var question = questions[currentIndex];
        QuestionLabel.Text = question.Text;

        for (int i = 0; i < question.Options.Count; i++)
        {
            var option = question.Options[i];// accedo a mi array de opciones

            var radio = new RadioButton
            {
                Content = option,
                GroupName = "OptionsGroup",
                Value = i
            };
            radio.CheckedChanged += Radio_CheckedChanged;
            OptionsPanel.Children.Add(radio);
        }

        // Cambio el texto del botón dependiendo de si es la última pregunta
        if (currentIndex == questions.Count - 1)
        {

            NextButton.Text = AppResources.FinishButtonText;
        }
        //else
        //{

        //    NextButton.Text = AppResources.NextButtonText;
        //}
    }

    private void Radio_CheckedChanged(object? sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            var radio = sender as RadioButton;
            selectedOptionIndex = (int)radio.Value;
            NextButton.IsVisible = true;
        }
    }

    private async void NextButton_Click(object sender, EventArgs e)
    {
        if (selectedOptionIndex == null)
        {
            return; //finalizo
        }

        var question = questions[currentIndex]; //pregunta actual

        var answer = new UserAnswer();
        answer.QuestionId = question.Id;
        answer.SelectedOption = question.Options[selectedOptionIndex.Value];
        answer.QuestionType = question.Type;
        Debug.WriteLine(answer.QuestionId + " opcionselect " + answer.SelectedOption + " type " + answer.QuestionType);

        //la añado ala colección
        //userAnswers.Add(answer);
        // Añade la respuesta directamente a UserConfig
        UserConfig.Instance.UserAnswers.Add(answer);

        currentIndex++;

        if (currentIndex < questions.Count)
        {
            LoadCurrentQuestion();// cargo la siguiente pregunta
        }
        else //finaliza el cuestionario
        {
            //Proceso las respuestas del cuestionario



            // 1. Procesa el cuestionario y suma puntos por área
            UserQuestionairePreferenceService.ProcessQuestionnaire(
                UserConfig.Instance,
                UserConfig.Instance.UserAnswers,
                UserConfig.Instance.UserLanguage
            );

            // 2. Calcula los porcentajes por área
            UserConfig.Instance.CalculatePercents();

            //visualizacion de las puntuaciones 
            foreach (AreaType area in Enum.GetValues(typeof(AreaType)))
            {
                int imp = UserConfig.Instance.Importance[area];
                int urg = UserConfig.Instance.Urgency[area];
                double impPct = UserConfig.Instance.ImportancePercent[area];
                double urgPct = UserConfig.Instance.UrgencyPercent[area];

                Debug.WriteLine($"{area}: Importancia = {imp} ({impPct:P1}), Urgencia = {urg} ({urgPct:P1})");
            }


            //persistencia de datos del usuario, 
            UserConfigStorage.Save();

            //navego a otra página que todavía no está creada

            await Navigation.PushAsync(new AddTaskPage());
        }
    }
}
