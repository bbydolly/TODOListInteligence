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
