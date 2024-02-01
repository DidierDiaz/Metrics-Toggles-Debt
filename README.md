![image](https://github.com/DidierDiaz/Metrics-Toggles-Debt/assets/22352012/2067df36-8bd8-4820-a9e9-bd2ebca4c99d)

# Proyecto de Tesis de Maestria en Ingenieria de Sistema. NET SDK (Backend)

# 📊 Titulo: Una metrica para medir deuda tecnica basada en el analisis de las más usadas. Caso de estudio del repositorio Square

# 📊 Obejtivo General. 
Proponer una metrica de deuda tecnica basada en el analisis de las metricas más usadas en la literatura, aplicada al repositorio Square como caso de estudio.

# 📊 Obejtivo Especifico. 
- Identificar las principales metricas en la literatura usadas para medir deuda tecnica.
- Proponer una métrica para evaluar la deuda tecnica basada en el analisis de las principales metricas identificadas en la literatura.
- Validar la métrica propuesta aplicada al repositorio Square como caso de estudio.

# 📊 Metrics Toggles-Debt
Proyecto escrito en .NET Core 6
* [Requirements](#requirements)
* [Installation](#installation)

## Requisitos para ejecutar el API
 - 🐘 [PostgreSQL](https://www.postgresql.org/download/)
 - 👁️ [Insomnia REST](https://insomnia.rest/download)
 - [Microsoft Visual Studio 2022](https://visualstudio.microsoft.com/es/vs/).
 - [Visual Studio Code](https://visualstudio.microsoft.com/es/vs/).
 - [Angular](https://angular.io/).
 - [NuGet](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design).

## Installation

For more information, see [Set Up Your Square SDK for a Python Project](https://developer.squareup.com/docs/sdks/python/setup-project).

## SDK Reference
- https://github.com/square/square-python-sdk/
  
### Database Table.
* ClassesAndMethods
* Table Commits
* Table LinesOfCode
* Table Remotes
* Table Tags
* __EFMigrationsHistory
### Formula & Metrica. 

- Metrica = Peso 1*Normalización Depth of Inheritance + Peso 2* Normalización Class Coupling + Peso 3* Normalización Lines of Source code.
- Formula = 0,29*0,12+ 0,24* 0,13 + 0,48*0,18.
