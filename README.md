# Registro de configuración del proyecto .NET MAUI

## Fecha
**12/4/2025**

## Creación del proyecto
- **Framework utilizado:** .NET 8
- Instalación de `maui-check` con el comando:
  **`dotnet tool install -g redth.net.maui.check`**
- Ejecución del comando **`maui-check`** para verificar si el proyecto contiene todos los componentes necesarios o si hay alguno desactualizado.

## Problemas encontrados
- Faltaban componentes en **Android SDK**, por lo que procedí a la instalación de los siguientes desde la herramienta **`maui-check`**, aunque estaba dando problemas y no instalaba correctamente.

## Configuración manual
### Variables de entorno configuradas:
- **Ruta principal del SDK:**
	**`C:\Users\mcris\AppData\Local\Android\Sdk`** 
- **Rutas añadidas al `PATH`:**			
  **`%ANDROID_SDK_ROOT%\platform-tools`** 
  **`%ANDROID_SDK_ROOT%\emulator`** 
  **`%ANDROID_SDK_ROOT%\cmdline-tools\latest\bin`** 

  
### Configuración desde Visual Studio:
1. **Emulator (31.3.12):** Simula un dispositivo Android.
2. **Build-tools (33.0.0):** Incluye compiladores y herramientas de empaquetado.
3. **System-images (android-33;google_apis;x86_64):** Imágenes del sistema Android que permiten emular diferentes versiones.
4. **Cmdline-tools (8.0):** Herramientas de línea de comandos.

## Verificación final
- Ejecuté el emulador para corroborar que podía interactuar con él.
![Preview TODO List Inteligence](Preview_Images/TODOListInteligence.JPG)
