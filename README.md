# Registro de configuracion del proyecto .NET MAUI

## Fecha
**12/4/2025**

## Creacion del proyecto
- **Framework utilizado:** .NET 8
- Instalacion de `maui-check` con el comando:
  **`dotnet tool install -g redth.net.maui.check`**
- Ejecuci�n del comando **`maui-check`** para verificar si el proyecto contiene todos los componentes necesarios o si hay alguno desactualizado.

## Problemas encontrados
- Faltaban componentes en **Android SDK**, por lo que proced� a la instalaci�n de los siguientes desde la herramienta **`maui-check`**, aunque estaba dando problemas y no instalaba correctamente.

## Configuracion manual
### Variables de entorno configuradas:
- **Ruta principal del SDK:**
	**`C:\Users\mcris\AppData\Local\Android\Sdk`** 
- **Rutas a�adidas al `PATH`:**			
  **`%ANDROID_SDK_ROOT%\platform-tools`** 
  **`%ANDROID_SDK_ROOT%\emulator`** 
  **`%ANDROID_SDK_ROOT%\cmdline-tools\latest\bin`** 

  
### Configuracion desde Visual Studio:
1. **Emulator (31.3.12):** Simula un dispositivo Android.
2. **Build-tools (33.0.0):** Incluye compiladores y herramientas de empaquetado.
3. **System-images (android-33;google_apis;x86_64):** Im�genes del sistema Android que permiten emular diferentes versiones.
4. **Cmdline-tools (8.0):** Herramientas de l�nea de comandos.

## Verificacion final
- Ejecut� el emulador para corroborar que pod�a interactuar con �l.
![Preview TODO List Inteligence](Resources/Images/TODOListInteligence.JPG)

## Fecha
**13 y 14/4/2025**

### Integración de Grial UI Kit y avances en la estructura del proyecto ###
- Estuve leyendo documentación y recursos sobre la estructura de proyectos en .NET MAUI y las mejores prácticas para organizar la solución.

- Inicié la integración de Grial UI Kit para .NET MAUI, siguiendo el procedimiento oficial para enlazarlo y vincularlo correctamente al proyecto.

- Tuve numerosos problemas de instalación y de licencia con Grial; tras varios intentos y revisiones, logré vincular la biblioteca y agregar las plantillas al proyecto.

- Añadí la extensión de Grial a Visual Studio y creé una cuenta en Grial para gestionar la licencia y acceder a los recursos.

- Configuración de Grial en Visual Studio:

    - Accedí a Herramientas > Opciones > Administrador de paquetes NuGet > Orígenes de paquetes.

    - Añadí la URL del repositorio privado de Grial como nuevo origen de paquetes NuGet para poder instalar y restaurar los paquetes de Grial en el proyecto.

    - Guardé los cambios y verifiqué que Visual Studio reconociera el nuevo origen.

- Me familiaricé con la biblioteca de Grial

- Renombré archivos existentes para adaptarlos a la estructura y convenciones de Grial, asegurando la compatibilidad con las nuevas plantillas.

- Incorporé varias plantillas de Grial a la solución tratando de  personalizar y adaptar la estructura generada a las necesidades del proyecto.

- Diseñé parte de la interfaz de usuario, incluyendo pantallas de login, registro, configuración de tema e idioma, y el cuestionario inicial.


**Importante** : Todavía no he subido el código con las plantillas de Grial al repositorio porque actualmente está desorganizado y necesita una reestructuración. Además, requiero un entendimiento más profundo de cómo funciona Grial para organizar correctamente la arquitectura y los recursos antes de compartir el código.

### Notas adicionales: ###

- Grial UI Kit proporciona una amplia colección de plantillas XAML y recursos de UI para acelerar el desarrollo de aplicaciones .NET MAUI, permitiendo personalizar temas, idiomas y componentes visuales de forma sencilla.

- La integración de Grial facilita la separación entre lógica de negocio y presentación, siguiendo el patrón MVVM y mejorando la mantenibilidad del proyecto.

**Estado actual:**
- El proyecto no tiene las plantillas de Grial bien integradas y necesita una reestructuración, ya que actualmente no funcionan correctamente.

- Es necesario aprender más sobre la biblioteca Grial para poder realizar la configuración adecuada y entender cómo relacionar las vistas y el código XAML.

- Quedan paquetes por instalar y resolver problemas de dependencias que impiden el funcionamiento correcto del proyecto.

**Próximos pasos**
- Reestructurar el código y organizar correctamente la solución.

- Profundizar en el aprendizaje de la estructura y funcionamiento de Grial UI Kit.

- Comprender cómo se relacionan las vistas y cómo trabajar con el código XAML generado por Grial.

- Instalar y verificar correctamente todos los paquetes y dependencias necesarias.

- Una vez que todo esté funcionando y bien organizado, subir el código al repositorio.



## Actualización 18-20/4/2025
**Desarrollo del proyecto, desafíos técnicos y configuración**

### 1. Estructura del proyecto y comandos

**Problema inicial:** El comando `tree` no mostraba las carpetas `ViewModels` y `Views`, impidiendo la visualización correcta de la estructura del proyecto.

**Causa:** Ejecución del comando desde un directorio incorrecto (`maui-samples` en lugar del directorio raíz del proyecto `TODOListInteligence`).

**Solución:** Navegación al directorio correcto y ejecución del comando.


### 2. Errores de importación de `Microsoft.Maui.Controls`

**Problema:** Errores de compilación CS0246: "No se encuentra el tipo o namespace `Microsoft.Maui.Controls`". Estos errores impedían la compilación y ejecución del proyecto.

**Causas:**

*   Herencia incorrecta en los ViewModels: La clase `LoginPageViewModel` heredaba de `ContentPage`, lo cual es incorrecto ya que los ViewModels no deben heredar de clases de la interfaz de usuario.
*   Configuración incompleta del SDK en el archivo `.csproj`: Faltaban propiedades importantes que indicaran que el proyecto era de tipo .NET MAUI y que habilitaran los ImplicitUsings.

**Soluciones:**
```bash
Correcciones en el archivo .csproj --> <PropertyGroup> <TargetFrameworks>net8.0-android;net8.0-ios;net8.0-maccatalyst</TargetFrameworks> <UseMaui>true</UseMaui> <ImplicitUsings>enable</ImplicitUsings> </PropertyGroup> ```
ViewModel corregido: Eliminación de la herencia incorrecta
```

```bash
public class LoginPageViewModel // Sin herencia de ContentPage
{
    // Lógica MVVM aquí
}
```

### Procedimiento adicional:

*   Cerrar Visual Studio.
*   Eliminar las carpetas `bin` y `obj` del proyecto.
*   Eliminar la carpeta `.vs` del proyecto (carpeta oculta).
*   Abrir Visual Studio y reconstruir la solución.

### 3. Configuración del entorno de desarrollo

**Problemas detectados:**

*   Cargas de trabajo de .NET MAUI no instaladas en Visual Studio, lo que impedía el reconocimiento de los componentes de .NET MAUI.
*   Faltaban componentes específicos de Android SDK, necesarios para la compilación y ejecución en dispositivos Android.

**Acciones realizadas:**

*   Instalación manual de las cargas de trabajo necesarias mediante el Visual Studio Installer:
    *   ".NET Multi-platform App UI development"
    *   "Mobile development with .NET"
    *   "Android SDK setup (API level 33)" o superior (si es necesario el desarrollo para Android)
*   Reinicio de la máquina después de la instalación para asegurar que todos los componentes se registraran correctamente en el sistema.

### 4. Problemas de vinculación MVVM

**Errores comunes:** Dificultades para enlazar las vistas con sus respectivos ViewModels, lo que impedía la actualización correcta de la interfaz de usuario.

**Implementacion correcta**
<!-- En LoginPage.xaml: Definición del BindingContext y enlace de propiedades -->
<ContentPage.BindingContext>
    <viewmodel:LoginPageViewModel />
</ContentPage.BindingContext>

<Entry Text="{Binding Email}" />

> Nota: La implementación de INotifyPropertyChanged en los ViewModels está pendiente de evaluación para determinar su necesidad y aplicabilidad en el proyecto.

### 5. Pruebas y Depuración

**Implementación:** Dada la falta de enlace completo de las vistas con los ViewModels y la necesidad de seguir desarrollando las vistas del proyecto, se pospusieron las pruebas exhaustivas de navegación y funcionalidad hasta tener una estructura más completa.

**Planificación:** Se decidió priorizar la creación de las vistas restantes y sus respectivos ViewModels, junto con su diseño y lógica, antes de realizar pruebas de navegación entre pantallas.

### 6. Errores de compilación recurrentes

| Error       | Causa                  | Solución                                 |
| ----------- | ---------------------- | ---------------------------------------- |
| NETSDK1136  | SDK no encontrado      | `dotnet workload install maui`            |
| XA4212      | Duplicados en .csproj | Usar `Update` en lugar de `Include`:       |
| MAUI0001    | Configuración de imágenes | Eliminar `bin/obj`, limpiar la solución |

### 7. Integración de Grial UI Kit

**Dificultades:**

*   Configuración de repositorios NuGet privados.
*   Conflictos de licencia.
*   Estructura de carpetas incompatible.

**Estado actual del proyecto**

- La referencia a Microsoft.Maui.Controls se reconoce correctamente.
- Navegación básica entre algunas páginas (en desarrollo).
- Enlace de datos básico (Entry -> ViewModel) en algunas vistas (en desarrollo).
- Aproximadamente la mitad de las vistas del proyecto están enlazadas a sus ViewModels correspondientes,
  que contienen el código que se va a visualizar y cierta lógica sobre la que se seguirá desarrollando.
- Pendiente por definir la mayoría de la lógica de la interfaz y del backend
- Pendiente de comprender el patrón de diseño MVVM
- Pendiente de arreglar más errores que ocurren en la ejecución para poder avanzar en el desarrollo del proyecto


## Actualización 26-27/4/2025

### Cambio de enfoque y avances en el desarrollo

Durante este fin de semana se ha producido un cambio fundamental en la estrategia del proyecto:

- **Abandono de Grial UI Kit:** Tras evaluar las dificultades y limitaciones de las plantillas de Grial, se decidió dejar de usarlas y desarrollar manualmente las vistas y su lógica asociada. Esto permite mayor flexibilidad y control sobre la experiencia de usuario y la arquitectura del proyecto.

### Vistas desarrolladas y navegación

Actualmente, el flujo de navegación entre páginas es funcional y se han creado las siguientes vistas, que ya interactúan correctamente entre sí:

- `WelcomePage`
- `StartOptionPage`
- `CreateAccountPage`
- `LoginPage`
- `ThemeConfigurationPage`
- `LanguageConfigurationPage`

Se está trabajando en la vista `InitialConfigurationPage`.

> **Nota:** Las imágenes utilizadas en las vistas de configuración de tema e idioma son provisionales y de pruebas. El diseño visual definitivo se abordará en fases posteriores, priorizando ahora la navegación y la interacción entre páginas.

Se han diseñado vistas futuras para:
- Añadir tareas.
- Visualizar cada uno de los cuatro cuadrantes de la matriz Eisenhower.
- Vista detallada de tareas por cuadrante, con posibilidad de agregar nuevas tareas.
- Perfil de usuario para modificar la configuración y mostrar datos personales.

Además, se está valorando el uso de **SQLite para la persistencia local** de datos.

### Internacionalización

- Se han creado **dos archivos de recursos de strings** para soportar los idiomas español e inglés, permitiendo la traducción de la interfaz y facilitando la futura ampliación a otros idiomas.
- Actualmente se está trabajando en **referenciar dinámicamente los strings** para que, tras cargar el idioma seleccionado por el usuario, las cadenas de texto de la interfaz se muestren en el idioma elegido.

### Navegación entre páginas

- La navegación entre páginas está basada en **`Navigation.PushAsync`** y se activa mediante el evento **`Clicked`** directamente desde XAML, en lugar de utilizar Shell.

### Diseño y desarrollo del algoritmo de clasificación

El algoritmo de clasificación de tareas basado en la matriz Eisenhower está en fase de diseño, con un enfoque claro hacia una solución sencilla y eficiente:

- Se utilizarán dos colecciones de preguntas, una para aspectos relacionados con la urgencia y otra para la importancia.
- Cada pregunta está asociada a un conjunto de palabras clave vinculadas a las tareas.
- Se realizará una suma total de puntos basada en las respuestas, para clasificar las tareas en los cuadrantes de la matriz.
- Se usará un diccionario de palabras clave para relacionar tareas con preguntas y calcular las puntuaciones.

### Clases principales creadas

- `Question`: representa cada pregunta del cuestionario inicial.
- `User`: modelo que contiene información del usuario.
- `UserAnswer`: almacena las respuestas del usuario a cada pregunta.

### Gestión del cuestionario y reutilización de vistas

- Actualmente se está trabajando en la configuración de la lógica para reutilizar una única vista que irá mostrando las preguntas del cuestionario inicial una a una, gestionando la navegación y el flujo desde el ViewModel. Esto permitirá mantener una interfaz limpia y flexible, facilitando futuras ampliaciones o modificaciones del cuestionario.
- El cuestionario está definido en formato JSON, permitiendo fácil modificación y extensión sin necesidad de cambiar el código fuente.

### Problemas resueltos

- Corrección de errores de binding y navegación entre vistas, asegurando que la interacción mediante botones y eventos en code-behind funcione correctamente.
- Ajuste de la estructura del proyecto para separar claramente las carpetas de `Views`, `ViewModels` y `Models`.
- Corrección de herencias incorrectas en los ViewModels, eliminando herencias de clases UI para cumplir con el patrón MVVM.

### Próximos pasos

- Finalizar la implementación de la vista `InitialConfigurationPage` y conectar el cuestionario con la lógica del algoritmo.
- Desarrollar las vistas para gestión y visualización de tareas por cuadrantes.
- Implementar persistencia de datos mediante SQLite.
- Diseñar e integrar el perfil de usuario para configuración y visualización de datos.
- Profundizar en la validación de respuestas y optimización del algoritmo de clasificación.

---

> **Nota:** Resources/VideoUpdates contiene una demo del proyecto actual.


---

**Resumen para el README:**

> **26-27/4/2025:** Se abandona el uso de plantillas Grial para crear manualmente las vistas y sus ViewModels, logrando una navegación funcional entre 6 páginas principales mediante `Navigation.PushAsync` y eventos `Clicked` en XAML. Se diseña un algoritmo de clasificación basado en dos colecciones de preguntas (urgente e importante) y un diccionario de palabras clave para sumar puntos y clasificar tareas según la matriz Eisenhower. Se crean las clases `Question`, `User` y `UserAnswer`, y se desarrolla un cuestionario reutilizable que carga preguntas una a una desde JSON. Las imágenes en las vistas de configuración de tema e idioma son provisionales. Se crean archivos de recursos de strings para español e inglés y se trabaja en la referencia dinámica de los textos según el idioma seleccionado. Se planifican vistas para añadir tareas y visualización detallada por cuadrantes, así como la integración de SQLite para persistencia y un perfil de usuario. Se corrigen errores de binding, navegación y estructura MVVM, sentando bases sólidas para el desarrollo futuro.


## Fecha
**4-5/5/2025**

### Implementación de la lógica de la matriz de Eisenhower y configuración avanzada

### Rama de trabajo

El desarrollo de la lógica de la matriz de Eisenhower y sus servicios asociados se está realizando en la rama **feature-heisenhower-matrix**.

> **Nota:** Algunas clases aún no contienen el namespace correcto, algo pendiente de corregir en próximas refactorizaciones para mantener la coherencia del proyecto.

---

### Avances y cambios realizados

#### Servicios y modelos principales

- **EisenhowerMatrixService:** Servicio estático que centraliza la lógica de clasificación de tareas en los cuadrantes de la matriz Eisenhower.
- **UserPreferenceService:** Procesa las respuestas del cuestionario y actualiza los diccionarios de importancia y urgencia del usuario.
- **Modelos:** `User`, `UserAnswer`, `Question`, `AreaType`.

#### Nuevas clases de configuración y mapeo

- **EisenhowerConfig** (`Config/EisenhowerConfig.cs`):  
  Clase estática que centraliza la configuración de los umbrales utilizados en la lógica de clasificación Eisenhower.
  - `ImportanceThreshold = 3` (mínimo de selecciones para considerar un área como importante, ajustado al número de preguntas del cuestionario).
  - `UrgencyThreshold = 2` (mínimo de selecciones para considerar un área como urgente).
  - Permite modificar los criterios de clasificación de manera sencilla y coherente para toda la aplicación, evitando la dispersión de "números mágicos" por el código.
- **QuestionnaireMapping:** Diccionarios bilingües para mapear opciones del cuestionario a áreas.
- **AppConfig:** Centraliza las colecciones de palabras clave por área y expone el método `DetectArea`.
- **UserConfig:** Clase para la configuración del usuario, incluyendo idioma, tema y palabras clave personalizadas.

---

### Compartimentación y estructura de código

- **Separación clara de responsabilidades:**
  - Lógica de negocio y clasificación → `EisenhowerMatrixService`, `UserPreferenceService`
  - Configuración y mapeo de áreas → `EisenhowerConfig`, `AppConfig`, `QuestionnaireMapping`, `UserConfig`
  - Modelos de datos → `/Models`
- **Centralización de palabras clave y umbrales** en los servicios y archivos de configuración.
- **Flexibilidad para futuras ampliaciones:** la arquitectura permite añadir nuevas áreas, ajustar umbrales y cargar palabras clave dinámicamente.

---

### Problemas de algoritmia y soluciones aplicadas

- **Exclusividad o solapamiento de áreas en colecciones de prioridad:**  
  Actualmente se está valorando si una misma área debe pertenecer exclusivamente a una sola colección de prioridad (es decir, ser considerada únicamente como importante o únicamente como urgente) o si, por el contrario, puede formar parte de ambas colecciones simultáneamente. El objetivo es encontrar el equilibrio óptimo entre la claridad en la clasificación y la flexibilidad del algoritmo.  
  Además, se está flexibilizando el algoritmo para permitir que varias áreas puedan formar parte de una misma categoría (por ejemplo, que varias áreas sean importantes o varias sean urgentes si cumplen los umbrales).
- **Detección de áreas multilingüe:**  
  Colecciones de palabras clave y diccionarios bilingües para identificar correctamente el área de una tarea o respuesta.
- **Asignación de prioridades precisa:**  
  Umbrales diferenciados para importancia (3) y urgencia (2), ajustados al número de preguntas de cada tipo en el cuestionario, centralizados en la clase `EisenhowerConfig`.
- **Gestión de áreas no marcadas:**  
  Si un área no alcanza el umbral, las tareas asociadas se clasifican automáticamente en el cuadrante 4.
- **Internacionalización y normalización:**  
  Procesamiento robusto de tipos de pregunta y mapeo correcto de opciones a áreas.
- **Namespaces incompletos:**  
  Detectado que algunas clases carecen del namespace adecuado, pendiente de corregir.


---

### Archivos y clases creados en esta iteración

- `/Services/EisenhowerMatrixService.cs`
- `/Services/UserPreferenceService.cs`
- `/Services/QuestionLoader.cs`
- `/Models/AreaType.cs`
- `/Models/User.cs`
- `/Models/UserAnswer.cs`
- `/Models/Question.cs`
- `/Config/EisenhowerConfig.cs`
- `/Config/QuestionnaireMapping.cs`
- `/Config/AppConfig.cs`
- `/Config/UserConfig.cs`

---

### Estado y próximos pasos

- La lógica de clasificación de tareas en los cuadrantes de la matriz de Eisenhower está operativa y en fase de pruebas.
- Es necesario cargar el cuestionario de preguntas y respuestas asignadas en bloques, convirtiendo el JSON en objetos con los que trabajar y almacenando esas respuestas para su posterior análisis.
- Se está trabajando en la reutilización de una única vista para ir mostrando secuencialmente cada pregunta del cuestionario, facilitando la navegación y el flujo dinámico de preguntas y respuestas.
- Se continuará con la integración de la carga dinámica de cuestionarios y la mejora de la detección de áreas.
- Se revisarán y corregirán los namespaces de todas las clases para cumplir con las buenas prácticas de organización de código.

> **Nota:** La matriz de Eisenhower está actualmente en fase de pruebas y ajustes.


---

**Rama:**  
Todo el código mencionado se encuentra en la rama **feature-heisenhower-matrix**, que sigue en desarrollo activo.

## Fecha
**10-11/5/2025**

## 🛠️ Cambios y avances recientes 

### Nuevas funcionalidades implementadas
- **Selector de Urgencia e Importancia:**  
  Ahora, al añadir una tarea, el usuario puede marcar si la tarea es *urgente* y/o *importante* mediante dos casillas de verificación (CheckBox), ambas alineadas a la izquierda y con etiquetas en negrita.
- **Clasificación automática de tareas:**  
  Si el usuario no marca ninguna etiqueta de urgencia o importancia, el sistema clasifica la tarea automáticamente usando el algoritmo de palabras clave y los resultados del cuestionario, asignando el área y el cuadrante de la matriz de Eisenhower.
- **Detección automática de área:**  
  Al crear una tarea, el sistema analiza el título y la descripción para identificar a qué área pertenece (Trabajo, Familia, Salud, Ocio, Amigos) usando palabras clave en español e inglés.
- **Visualización de cuadrante y área:**  
  Las tareas pueden mostrar en la lista tanto el área detectada como el cuadrante Eisenhower correspondiente.

### Clases y arquitectura
- **Creación y mejora de clases:**  
  Se crearon y/o reconfiguraron varias clases clave del proyecto:
  - `UserTask`: Ahora almacena información sobre urgencia, importancia, área y cuadrante.
  - `AppConfig`: Gestiona palabras clave y detección de áreas.
  - `EisenhowerMatrixService`: Clasifica las tareas según la matriz de Eisenhower.
  - `UserConfig`: Gestiona la configuración y preferencias del usuario.
  - `QuestionnaireMapping` y servicios relacionados: Mapean respuestas del cuestionario a áreas.
- **Refactorización de código:**  
  Se reorganizó y limpió el code-behind y los modelos para mejorar la claridad, la mantenibilidad y la integración con la lógica de clasificación.

### Errores corregidos
- **RadioButton sustituido por CheckBox:**  
  Se corrigió el uso de RadioButton (que no permite desmarcarse) por CheckBox, permitiendo seleccionar y deseleccionar las opciones de urgencia e importancia.
- **Alineación y diseño:**  
  Se ajustó la alineación de los campos y botones para que todo quede a la izquierda, y los campos de entrada ocupen todo el ancho disponible.
- **Scroll vertical:**  
  Se envolvió toda la vista en un `ScrollView` para asegurar que la pantalla es completamente desplazable en dispositivos móviles.
- **Limpieza de referencias obsoletas:**  
  Se eliminaron referencias a controles ya no existentes (como `NotUrgentRadio`) y se actualizaron los nombres de controles en el code-behind.
- **Reseteo de campos tras añadir tarea:**  
  Ahora, al añadir una tarea, todos los campos y checkboxes se limpian correctamente.

### Otros avances
- Se integró el algoritmo de clasificación de áreas y cuadrantes con la lógica de la interfaz de usuario.
- Se mejoró la estructura del modelo `UserTask` para almacenar área y cuadrante.
- Se añadió la posibilidad de mostrar área y cuadrante en la lista de tareas.
- Se documentó el flujo de clasificación automática y manual de tareas.

--- 

### ¿Qué queda pendiente?
- Mejorar la visualización de cuadrantes (por ejemplo, con colores o iconos).
- Permitir edición y eliminación de tareas.
- Mejorar la detección automática de área con IA o reglas más avanzadas (opcional).
- Internacionalización completa de etiquetas si se añaden nuevos campos.




# 🛠️ Informe Detallado de Cambios, Avances, Problemas y Soluciones

**Fecha:** 20/5/2025 Última entrega

---

## 1. Nuevas vistas implementadas

### 🔹 AddTaskModalPage

**Propósito:**  
Permitir al usuario crear una nueva tarea mediante un formulario modal, integrado con la colección observable de tareas y la persistencia de datos.

---

**Funcionalidad:**
- Validación de campos obligatorios (título).
- Entrada de descripción opcional.
- Botón para guardar la tarea, que añade la tarea a la colección principal, guarda los datos y cierra el modal.
- Botón para cancelar y cerrar el modal sin cambios.
- Textos internacionalizados mediante recursos `.resx`.

---

**Code-behind (C#):**
- Recibe una `ObservableCollection<UserTask>` por parámetro en el constructor y la almacena en `_collection` para añadir nuevas tareas directamente.

**En `OnSaveClicked`:**
- Valida que el campo de título no esté vacío.
- Crea una nueva instancia de `UserTask` con los datos introducidos.
- Añade la nueva tarea a la colección observable (lo que actualiza automáticamente la UI de la lista principal).
- Llama a `UserConfigStorage.Save()` para persistir los datos.
- Cierra el modal con `Navigation.PopModalAsync()`.

**En `OnCancelClicked`:**
- Cierra el modal sin realizar cambios.

---

**XAML:**
- Interfaz sencilla y clara, con:
  - Título principal.
  - Campos para nombre y descripción de la tarea.
  - Botones de guardar y cancelar.
- Todos los textos están internacionalizados usando recursos `.resx`.

---

**Problemas encontrados:**
- Dificultad para limpiar correctamente los campos tras guardar, ya que el modal se cierra y no se reutiliza.
- Necesidad de refrescar la lista de tareas en la vista principal tras añadir una tarea, especialmente si la colección no es observable.
- Gestión de la persistencia de datos tras añadir la tarea (asegurando que la tarea se guarda correctamente en almacenamiento local).

---

**Soluciones:**
- Se utilizó una `ObservableCollection<UserTask>` compartida entre la página principal y el modal, lo que permite que la lista principal se actualice automáticamente al añadir una tarea.
- Se invoca `UserConfigStorage.Save()` inmediatamente después de añadir la tarea para garantizar la persistencia.
- Se optó por cerrar el modal tras guardar o cancelar, simplificando el flujo y evitando la necesidad de limpiar campos manualmente.

---

**📌 Resumen técnico:**
- La implementación actual es eficiente y simple para el flujo de alta de tareas.
- El uso de `ObservableCollection` garantiza la actualización automática de la UI.
- La persistencia inmediata evita pérdidas de datos.
- La internacionalización está correctamente aplicada en todos los textos de la vista.


### 🔹 CollectionsMatrixPage

**Propósito:**  
Mostrar una lista de tareas clasificadas (por ejemplo, por cuadrante en la matriz de Eisenhower), permitiendo al usuario visualizar, crear y seleccionar tareas para su edición o eliminación.

---

**Funcionalidad:**
- Visualización de la lista de tareas en un `CollectionView` con scroll.
- Título dinámico de la colección, internacionalizable.
- Botón fijo para añadir una nueva tarea, siempre visible en la parte inferior.
- Selección de una tarea para acceder a su detalle y edición.
- Soporte para internacionalización según el idioma del usuario.

---

**Code-behind (C#):**

**Constructor:**
- Recibe una `ObservableCollection<UserTask>` y un título, que se asignan a las propiedades `ItemsSource` y `CollectionTitle`, respectivamente.
- Inicializa la cultura de la aplicación según la preferencia del usuario (`UserConfig.Instance.UserLanguage`).
- Establece el `BindingContext` para la vista.

**`OnAddButtonClicked`:**
- Abre el modal `AddTaskModalPage`, pasando la colección observable para que la nueva tarea se añada y la lista se actualice automáticamente.

**`OnTaskSelected`:**
- Al seleccionar una tarea, abre la vista de detalle (`UserTaskDetailPage`), pasando la tarea seleccionada y la colección para permitir edición/eliminación.
- Deselecciona el elemento tras la navegación para permitir futuras selecciones.

---

**XAML:**
- Estructura con `Grid` y tres filas: título, lista de tareas y botón de añadir.
- `CollectionView` para mostrar las tareas, cada una en un `ContentView` con estilo y margen.
- Botón **"Añadir tarea"** siempre visible, alineado en la parte inferior.
- Todos los textos preparados para internacionalización.

---

**Problemas encontrados:**

- **Internacionalización:**  
  Inicialmente, el título de la colección y los textos no se actualizaban correctamente al cambiar el idioma del usuario.

- **Actualización de la lista:**  
  Si la colección no es observable, la lista no se actualiza automáticamente al añadir o editar tareas.

- **Selección múltiple:**  
  Si no se deselecciona el elemento tras navegar, el usuario no puede volver a seleccionar la misma tarea hasta que seleccione otra.

- **Gestión de la pila de navegación:**  
  Al navegar a detalles y volver, la pila de navegación puede crecer si no se gestiona correctamente.

---

**Soluciones:**
- Se utiliza `ObservableCollection<UserTask>` para asegurar que la UI se actualiza automáticamente al añadir, editar o eliminar tareas.
- El título de la colección se obtiene y se internacionaliza usando recursos y la cultura del usuario, inicializada en el constructor.
- Tras navegar a la vista de detalle, se deselecciona el elemento en el `CollectionView` para evitar problemas de selección.
- Se recomienda (y se documenta como mejora futura) gestionar la pila de navegación usando rutas absolutas de Shell para evitar acumulación de páginas en la pila.
- Se sugiere migrar a un patrón **MVVM** y usar notificaciones de cambio para una arquitectura más escalable y desacoplada.

---

**📌 Resumen técnico:**
- La vista permite una gestión eficiente y


---

### 🔹 UserProfilePage

**Propósito:**  
Permitir al usuario visualizar sus datos personales y preferencias de configuración dentro de la aplicación.

---

**Funcionalidad:**
- Muestra el nombre, email, idioma y tema actual del usuario.
- Todos los datos se obtienen directamente de la instancia singleton `UserConfig`.
- Botón para editar el perfil, preparado para navegar a una página de edición (a implementar o ampliar).
- Interfaz adaptada para scroll vertical y diseño limpio con separación entre campos.

---

**Code-behind (C#):**

- En el constructor, se establece el `BindingContext` a `UserConfig.Instance`, lo que permite enlazar directamente las propiedades del usuario a la UI.
- El método `OnEditProfileClicked` está preparado para manejar la navegación a la página de edición de perfil (pendiente de implementación o ampliación según necesidades).

---

**XAML:**

- Estructura basada en un `VerticalStackLayout` dentro de un `ScrollView` para asegurar desplazamiento en dispositivos móviles.
- Cada campo (nombre, email, idioma, tema) se muestra con una etiqueta en negrita y el valor correspondiente enlazado por *binding*.
- Botón **“Editar Perfil”** centrado y con margen superior para mejor usabilidad.

---

**Problemas encontrados:**

- **Actualización de datos en tiempo real:**  
  Si se modifica algún dato del usuario fuera de esta vista, los cambios no se reflejan automáticamente al volver, ya que `UserConfig` no implementa `INotifyPropertyChanged`.

- **Edición de perfil:**  
  La lógica para editar el perfil aún no está implementada; actualmente, el botón solo sirve como *placeholder*.

- **Internacionalización:**  
  Los textos de las etiquetas están actualmente en español fijo; sería recomendable internacionalizarlos usando recursos `.resx`.

---

**Soluciones:**

- Se documentó la necesidad de implementar `INotifyPropertyChanged` en `UserConfig` para que la UI se actualice automáticamente cuando cambien los datos del usuario.
- Se sugiere internacionalizar los textos estáticos de las etiquetas para soportar múltiples idiomas, siguiendo el estándar ya usado en otras vistas.

---

**📌 Resumen técnico:**

- La vista proporciona una experiencia sencilla y directa para consultar los datos del usuario.
- El uso del singleton como fuente de datos simplifica el *binding*, pero limita la actualización automática de la UI.
- La estructura de la vista está preparada para ampliaciones futuras, tanto en campos como en lógica de edición.
- Se identifican mejoras clave en notificación de cambios y soporte multilingüe.


---

### 🔹 UserTaskDetailPage

**Propósito:**  
Permitir al usuario consultar, editar o eliminar una tarea específica seleccionada desde la matriz o la lista principal de tareas.

---

**Funcionalidad:**
- Muestra el título de la tarea en modo solo lectura.
- Permite editar la descripción de la tarea.
- Ofrece tres acciones principales: **guardar cambios**, **cancelar** y **eliminar** la tarea.
- Todos los textos y etiquetas están internacionalizados mediante recursos `.resx`.
- Interfaz adaptada para móviles, con scroll y botones dispuestos de forma *responsive*.

---

**Code-behind (C#):**

- **Constructor:**
  - Recibe la tarea seleccionada (`UserTask`) y la colección principal de tareas (`ObservableCollection<UserTask>`).
  - Inicializa la cultura según el idioma del usuario.
  - Asigna los datos de la tarea a las propiedades públicas `TaskTitle` y `TaskDescription` para el *binding*.
  - Establece el `BindingContext` a la propia página.

- **OnSaveClicked:**
  - Si la tarea existe, actualiza la descripción con el nuevo texto introducido.
  - Si la tarea no existe (caso poco habitual), crea una nueva tarea y la añade a la colección.
  - Cierra la página y vuelve a la anterior.

- **OnCancelClicked:**
  - Descarta los cambios y vuelve a la página anterior.

- **OnDeleteClicked:**
  - Solicita confirmación al usuario antes de eliminar la tarea (*pendiente de internacionalizar el mensaje*).
  - Si el usuario confirma, elimina la tarea de la colección principal y cierra la página.

---

**XAML:**

- Estructura basada en un `VerticalStackLayout` dentro de un `ScrollView`.
- Campo de **título** en modo solo lectura (`Entry` deshabilitado y en gris).
- Campo de **descripción** editable (`Editor`).
- Botones de **guardar**, **cancelar** y **eliminar** dispuestos en una sola fila (`Grid`), con colores diferenciados y esquinas redondeadas.
- Todos los textos y *placeholders* están internacionalizados.

---

**Problemas encontrados:**

- **Internacionalización incompleta:**  
  El mensaje de confirmación de borrado aún está en español fijo y requiere traducción.

- **Actualización de la UI:**  
  Si la colección principal no es `ObservableCollection`, los cambios no se reflejan automáticamente en la vista principal.

- **Edición de título:**  
  Actualmente solo lectura. Para permitir su edición, sería necesario modificar la lógica y el binding.

- **Gestión de navegación:**  
  La pila de navegación puede crecer si no se controla el flujo al navegar repetidamente entre vistas.

---

**Soluciones:**

- Se utiliza una `ObservableCollection<UserTask>` compartida para que los cambios se reflejen automáticamente en la UI principal.
- Se documenta la necesidad de internacionalizar todos los mensajes, incluidos los de confirmación en diálogos.
- El campo de título se mantiene como solo lectura para evitar ediciones accidentales. Si se requiere edición, se sugiere una vista específica.
- Se recomienda gestionar la pila de navegación con rutas absolutas de `Shell` o un patrón de navegación más controlado.

---

**📌 Resumen técnico:**

- La vista permite consultar, editar la descripción y eliminar tareas de forma segura y controlada.
- El uso de `ObservableCollection` garantiza la actualización automática de la UI principal.
- La experiencia de usuario es clara y los controles están bien diferenciados.
- Se identifican mejoras clave en internacionalización y control de navegación para futuras versiones.

---

### 🔹 EisenhowerMatrixPage

**Tipo de cambio:**  
Modificación de vista existente (no es de nueva creación).

**Propósito:**  
Visualizar la matriz de Eisenhower, mostrando las tareas clasificadas en sus cuatro cuadrantes según **urgencia** e **importancia**, y permitir la navegación a las listas detalladas de cada cuadrante.

---

**Funcionalidad:**
- Muestra los encabezados de “Urgente”, “No urgente”, “Importante” y “No importante” en la matriz.
- Cada cuadrante es un `Frame` interactivo con un listado (`CollectionView`) de tareas correspondiente.
- Permite al usuario pulsar en un cuadrante para navegar a una vista detallada de las tareas de ese cuadrante (`CollectionsMatrixPage`).
- Permite seleccionar una tarea de un cuadrante para futuras acciones (edición, detalle, etc.).

---

**Code-behind (C#):**

- Inicializa la cultura de la aplicación según la preferencia del usuario.
- Establece el `BindingContext` a la instancia singleton de `UserConfig`, que contiene las colecciones observables de tareas para cada cuadrante.
- `OnQuadrantTapped`: navega a la página de detalle de tareas del cuadrante seleccionado, pasando la colección y el título adecuados.
- `OnTaskSelected`: preparado para futuras acciones al seleccionar una tarea (por ejemplo, mostrar detalles o editar).

---

**XAML:**

- Usa un `Grid` complejo para estructurar la matriz de Eisenhower con filas y columnas bien definidas.
- Cada cuadrante contiene un `CollectionView` para mostrar las tareas.
- Diseño *responsive* y visualmente claro, con separación entre cuadrantes.
- Encabezados internacionalizados.
- Se había considerado incluir un botón de eliminación (“-”) junto a cada tarea, pero este código está comentado y **no se utiliza actualmente**.

---

**Problemas encontrados con los botones de eliminación:**

- **Complejidad de layouts:**  
  La estructura con múltiples `Grids`, `Frames` y `CollectionViews` hacía difícil añadir botones funcionales sin afectar la legibilidad del código y la estética.

- **Gestión de eventos en CollectionView:**  
  Añadir botones de acción dentro de cada elemento generaba problemas de alineación, espacio y manejo de eventos, especialmente en móviles y con textos largos.

- **Ambigüedad en la interacción:**  
  Múltiples acciones (selección, tap en cuadrante, eliminar) en un mismo elemento generaban confusión para el usuario.

- **Duplicidad de lógica:**  
  Gestionar la eliminación tanto desde la matriz como desde la vista de detalle podía provocar inconsistencias en el código.

---

**Soluciones y decisiones:**

- **Eliminación de los botones de borrar tarea en la matriz:**  
  Por motivos de complejidad visual y usabilidad, se eliminaron los botones de eliminación directa desde la matriz.

- **Centralización de la eliminación en la vista de detalle:**  
  La tarea se elimina únicamente desde `UserTaskDetailPage`, donde el flujo es más claro y controlado.

- **Documentación de la decisión:**  
  Se documenta en el código y diseño que no se incluyen botones de eliminar en la matriz por razones de mantenimiento y UX.

- **Futuras mejoras sugeridas:**  
  Si se desea reintroducir la funcionalidad, se recomienda utilizar `SwipeView` o menús contextuales en lugar de botones visibles permanentemente.

---

**📌 Resumen técnico:**

- La matriz de Eisenhower está correctamente implementada y conectada con las `ObservableCollection`.
- La navegación entre cuadrantes y sus vistas detalladas es fluida.
- La eliminación de botones de borrado directo mejora la experiencia de usuario y la mantenibilidad.
- El código está preparado para futuras mejoras, manteniendo la simplicidad visual como prioridad y se pretende corregir los errores al agregar tareas de alineación con los bordes del Frame..

---
### 🔹 UserConfigDTO

**Tipo de cambio:**  
Nueva clase de transferencia de datos (DTO) creada para resolver problemas de serialización con el singleton `UserConfig`.

---

**Propósito:**  
Permitir la serialización y deserialización segura de la configuración y datos del usuario, evitando las restricciones y problemas asociados al patrón singleton implementado en la clase principal `UserConfig`.

---

**Funcionalidad y estructura:**

**🔸 Datos personales:**
- `Name`
- `Email`
- `Password`

**🔸 Configuración de usuario:**
- `UserLanguage` (idioma preferido)
- `UserTheme` (tema claro/oscuro)

**🔸 Respuestas del cuestionario:**
- `List<UserAnswer> UserAnswers`

**🔸 Palabras clave personalizadas por área:**
- `Dictionary<AreaType, List<string>> AreaKeywords`

**🔸 Puntuaciones y porcentajes por área:**
- `Dictionary<AreaType, int> Importance`
- `Dictionary<AreaType, int> Urgency`
- `Dictionary<AreaType, double> ImportancePercent`
- `Dictionary<AreaType, double> UrgencyPercent`

**🔸 Tareas del usuario:**
- `List<UserTask> UserTasks`

**🔸 Colecciones observables por cuadrante de la matriz de Eisenhower:**
- `ObservableCollection<UserTask> UrgentAndImportantTasks`
- `ObservableCollection<UserTask> ImportantButNotUrgentTasks`
- `ObservableCollection<UserTask> UrgentButNotImportantTasks`
- `ObservableCollection<UserTask> NeitherUrgentNorImportantTasks`

**🔸 Diccionario de tareas agrupadas por área:**
- `Dictionary<AreaType, List<UserTask>> TasksByArea`

---

**Justificación y problemas resueltos:**

- **❌ Imposibilidad de serializar un singleton:**  
  `UserConfig` implementa el patrón singleton y contiene lógica interna, referencias a servicios y eventos que no deben serializarse.

- **📦 Necesidad de persistencia y recuperación de datos:**  
  Para guardar/restaurar la configuración del usuario, se requiere una estructura simple, plana y libre de lógica.

- **🔄 Desacoplamiento de la lógica de negocio:**  
  `UserConfigDTO` no contiene lógica ni dependencias externas. Solo representa datos, facilitando la serialización/deserialización.

- **🔔 Compatibilidad con colecciones observables:**  
  Se incluyen `ObservableCollection<UserTask>` para mantener la reactividad de la UI tras deserialización.

---

**Uso en el proyecto:**

- **Guardar datos:**  
  Se crea una instancia de `UserConfigDTO` a partir de `UserConfig` y se serializa a almacenamiento persistente.

- **Cargar datos:**  
  Se deserializa un `UserConfigDTO` y se utiliza para poblar `UserConfig`, restaurando el estado de la aplicación.

---

**Ventajas:**

- ✅ Permite persistir/restaurar el estado del usuario sin romper el patrón singleton.
- 🔧 Facilita la evolución del modelo de datos.
- 🧼 Mejora la mantenibilidad

---

## 2. Creación y uso del menú principal (TabBar)

**Implementación:**
- Definido en `AppShell.xaml` usando el componente `TabBar` de Shell.
- Pestañas: 
  - **Matriz** (`EisenhowerMatrixPage`)
  - **Añadir** (`AddTaskPage`)
  - **Usuario** (`UserProfilePage`)

**Ventajas:**
- Navegación clara y accesible entre las áreas principales.
- Experiencia de usuario nativa y consistente en todas las plataformas.

**Problemas encontrados:**
- Al navegar a subpáginas dentro de una pestaña, el `TabBar` nativo no permite limpiar la pila de navegación automáticamente al volver a pulsar la pestaña.
- No existe el evento `CurrentItemChanged` en .NET MAUI, por lo que no se puede interceptar el cambio de pestaña para ejecutar lógica personalizada.
- NO está solucionada la limpieza de la pila de llamadas en submenús.

**Soluciones y alternativas:**
- Uso de rutas absolutas (`Shell.Current.GoToAsync("//EisenhowerMatrixPage")`) en menús y botones personalizados.
- Se documentó la alternativa de crear un `TabBar` personalizado con botones si se requiere lógica avanzada, aunque se decidió mantener el `TabBar` nativo por simplicidad y experiencia de usuario.

---

## 3. Modificaciones en clases y arquitectura

### 🔹 `UserConfig`

**Nuevo método `UserDataIsComplete`:**
- Permite comprobar si el usuario está logueado y si su información es válida antes de acceder a funcionalidades sensibles.

**Motivación:**
- Mejorar la seguridad y la experiencia de usuario, evitando accesos no autorizados o flujos incompletos.

---


### 🔹 Otras mejoras

- Refactorización del `code-behind` para separar lógica de UI y lógica de negocio.
- Mejoras en la validación y gestión de errores en formularios.

---

## 4. Internacionalización y recursos

**Implementación de archivos `.resx`:**
- Todos los textos de la interfaz se gestionan mediante recursos para soportar múltiples idiomas.
- Se inicializa la cultura en el arranque de la aplicación y se referencia desde XAML y *code-behind*.

**Problemas encontrados:**
- Dificultad inicial para vincular correctamente los recursos en XAML.

**Soluciones:**
- Uso de `{x:Static resx:AppResources.Clave}` y comprobación de la inicialización de la cultura en cada vista.

---

## 5. Problemas generales encontrados y soluciones

### 🔸 Gestión de la pila de navegación en Shell

**Problema:**  
Al navegar a subpáginas y volver a la pestaña principal, la pila no se limpiaba automáticamente, lo que puede llevar a una experiencia de navegación confusa y a acumulación de páginas en la pila.

**Solución (pendiente de implementación completa):**  
Uso de rutas absolutas en la navegación desde menús y botones personalizados para forzar el retorno a la raíz de la pestaña (por ejemplo, `Shell.Current.GoToAsync("//EisenhowerMatrixPage")`).

**Alternativa:**  
Crear un **TabBar personalizado** si se requiere control total sobre la navegación y la pila, permitiendo interceptar los eventos de selección y ejecutar lógica personalizada.

---

### 🔸 Eventos de navegación en Shell

**Problema:**  
El evento `CurrentItemChanged` no está disponible en .NET MAUI Shell (a diferencia de Xamarin.Forms), lo que impide interceptar el cambio de pestaña en el TabBar nativo para ejecutar lógica personalizada, como limpiar la pila de navegación o recargar la página raíz.

**Solución:**  
Actualmente no existe una solución directa. Se recomienda:

- Utilizar navegación explícita y rutas absolutas en las acciones que requieran garantizar la navegación a la raíz.
- Documentar claramente esta limitación para el equipo de desarrollo y considerar la migración a un **TabBar personalizado** si la lógica de negocio lo requiere.

---

### 🔸 Carga condicional del menú principal

**Problema:**  
Dependiendo del contexto (por ejemplo, si el usuario es nuevo o está en proceso de *onboarding*), puede ser necesario ocultar o mostrar el menú principal (**TabBar**). La lógica actual permite esta carga condicional, pero requiere revisiones para garantizar que todos los flujos (registro, login, primer acceso) estén correctamente cubiertos.

**Solución:**

- Revisar y mejorar la lógica de carga condicional del menú en `AppShell` y en los controladores de navegación.
- Asegurar que el menú solo se muestre cuando el usuario ha completado los pasos necesarios y que se oc


### 🔹 Modificación de `UserConfigStorage` para persistencia de datos

**Tipo de cambio:**  
Modificación importante (no es una clase nueva, sino una mejora significativa de la lógica de persistencia).

**Propósito:**  
Permitir la persistencia y recuperación de todos los datos de usuario y configuración de la aplicación, resolviendo la imposibilidad de serializar directamente el singleton `UserConfig`.

---

#### 📌 Descripción de la modificación

- Se ha implementado la lógica de guardado y carga de datos en la clase estática `UserConfigStorage`.
- Al guardar, se crea un objeto `UserConfigDTO` a partir del singleton `UserConfig` y se serializa a un archivo JSON en el directorio de datos de la app.
- Al cargar, se deserializa el archivo JSON a un objeto `UserConfigDTO` y se copian sus valores de vuelta al singleton `UserConfig`.
- Se han implementado los métodos auxiliares `CopyFromSingleton` y `CopyToSingleton` para mapear todos los campos relevantes entre el singleton y el DTO.

---

#### ⚙️ Funcionamiento técnico

**Ruta de almacenamiento:**  
El archivo se guarda en `FileSystem.AppDataDirectory` bajo el nombre `userconfig.json`.

**Serialización:**  
Se utiliza `System.Text.Json` para serializar y deserializar el DTO de forma eficiente y legible.

**Estructura de datos:**  
Se incluyen todos los datos personales, preferencias, respuestas de cuestionario, palabras clave, puntuaciones y colecciones de tareas, tanto en listas como en colecciones observables para los cuadrantes de la matriz de Eisenhower.

**Robustez:**  
Se manejan correctamente los casos en los que el archivo no existe o los campos son nulos, creando colecciones vacías por defecto.

---

#### 💡 Justificación

**Problema original:**  
El patrón singleton de `UserConfig` impide la serialización directa, ya que la clase contiene lógica, referencias y eventos que no deben persistirse.

**Solución:**  
Se ha creado un DTO (`UserConfigDTO`) específicamente para la transferencia y persistencia de datos, y se ha adaptado `UserConfigStorage` para convertir entre ambos formatos.

---

#### ✅ Ventajas

- Permite guardar y restaurar el estado completo del usuario de forma segura y eficiente.
- Facilita la evolución futura del modelo de datos, ya que los cambios en la lógica de `UserConfig` no afectan a la estructura de serialización.
- Mejora la mantenibilidad y claridad del código.

---

#### 📄 Resumen técnico

- La persistencia de datos de usuario ahora es robusta y desacoplada de la lógica de negocio.
- El flujo de guardado y carga es transparente para el usuario y se integra con el ciclo de vida de la aplicación.
- Esta modificación es fundamental para asegurar la continuidad de los datos entre sesiones.


