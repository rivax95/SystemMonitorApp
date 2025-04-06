# 🖥️ SystemMonitorApp

Una aplicación WPF en C# que monitoriza el sistema en tiempo real, mostrando información relevante del hardware como:

- 📅 Fecha y hora del muestreo
- 🧠 Uso de CPU
- 🧮 RAM disponible y usada
- ⚙️ ID del procesador
- 🧩 ID de la placa base
- 🎮 Nombre de la GPU real (filtrado, sin monitores virtuales)

---

## 🚀 Tecnologías utilizadas

- [.NET 8.0 (WPF)](https://dotnet.microsoft.com/en-us/)
- [JetBrains Rider](https://www.jetbrains.com/rider/) como IDE
- `Microsoft.Extensions.DependencyInjection` para inyección de dependencias
- `System.Diagnostics.PerformanceCounter` para monitorización de CPU y RAM
- `System.Management` (WMI) para obtener información de hardware
- DLL externa `Visiotech.HardwareInfo` para lectura de CPU y placa base

---

## 🧠 Arquitectura

El proyecto sigue principios **SOLID** y una arquitectura desacoplada:

- 🧩 **Inyección de dependencias estructurada** usando `Microsoft.Extensions.DependencyInjection`
- 📦 `App.xaml.cs` configura el contenedor de servicios en el arranque
- 🔌 Interfaces para cada dependencia (`ISystemInfoProvider`, `ISystemSampleRepository`)
- 🧠 `MainViewModel` abstrae toda la lógica de presentación
- 💾 Repositorio JSON para persistencia de datos en disco
- 🧪 `RealSystemInfoProvider` para producción / `PlaceholderSystemInfoProvider` para entornos de prueba


---

## ✅ Cómo ejecutar

1. Abre el proyecto en Rider
2. Asegúrate de tener instalado el SDK de .NET 8.0
3. Ejecuta el proyecto (`F5` o `Shift + F10`)
4. La app mostrará datos del sistema en una tabla, actualizándose en tiempo real

---

## 💡 Notas

- Si estás en escritorio remoto o máquina virtual, la GPU puede no ser detectada correctamente (los adaptadores virtuales se filtran automáticamente).
- Si la DLL `Visiotech.HardwareInfo.dll` no está presente, solo la CPU y RAM funcionarán.
- La inyección de dependencias está basada en `ServiceCollection` y puedes ampliar fácilmente con nuevos servicios o vistas.

---

## 📝 Créditos

Este proyecto fue desarrollado como parte de una prueba técnica, aplicando buenas prácticas de arquitectura, diseño de UI en WPF y lectura eficiente del sistema.

