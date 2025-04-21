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






