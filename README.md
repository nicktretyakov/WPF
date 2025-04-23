# Ecours Desktop WPF Application

A **WPF** desktop application built using the **MVVM** pattern, serving as the UI layer of the Ecours platform. Demonstrates dialog invocation, custom controls, resource styling, and Prism/Unity integration.

---

## Table of Contents
1. [Solution Overview](#solution-overview)
2. [Features](#features)
3. [Architecture & Technology Stack](#architecture--technology-stack)
4. [Prerequisites](#prerequisites)
5. [Getting Started](#getting-started)
6. [Solution Structure](#solution-structure)
7. [Ecours.Desktop Project Structure](#ecoursdesktop-project-structure)
8. [Key Components](#key-components)
9. [Running the Application](#running-the-application)
10. [Testing](#testing)
11. [Contributing](#contributing)
12. [License](#license)

---

## Solution Overview
This Visual Studio solution (**Ecours.Client.sln**) comprises several projects:

- **Ecours.Desktop**: WPF MVVM front-end application.
- **Ecours.Account**: Domain logic for user accounts.
- **Ecours.Contractor**: Contractor-specific business logic.
- **Ecours.Default**: Default implementations and models.
- **ecours**: Core entities, interfaces, and shared definitions.
- **Ecours.Utils**: Shared utilities (logging, configuration).
- **Ecours.Client.Tests**: Unit tests for core libraries.

The **Ecours.Desktop** project leverages **Prism** and **Unity** to implement the MVVM pattern, promoting maintainability and testability.

## Features
- **MVVM Architecture**: Separation of concerns between UI (Views), logic (ViewModels), and data (Models).
- **Dialog Service**: Open custom styled dialog windows (e.g., EcoursMessageWindow) via commands.
- **Custom Controls**: Reusable `WidgetControl` showcasing templating and interaction states.
- **Resource Styling**: Centralized XAML resource dictionaries for consistent styling (buttons, dialogs, textboxes).
- **Prism Commanding**: Use of `DelegateCommand` for handling UI actions.
- **Dependency Injection**: Configured via `Prism.Unity.Wpf` and `Unity.Container`.
- **Logging**: Integrated `log4net` for structured runtime logging.

## Architecture & Technology Stack
- **.NET Framework 4.6.1**
- **WPF** with **MVVM** (Prism v7.1)
- **Unity** DI container
- **log4net** for logging
- **CommonServiceLocator** for service resolution

## Prerequisites
- Windows OS
- Visual Studio 2017 or later with **.NET desktop development** workload
- NuGet package restore enabled

## Getting Started
1. **Clone the repository**
   ```bash
git clone https://github.com/nicktretyakov/WPF.git
cd WPF
```
2. **Open solution**
   - Launch `Ecours.Client.sln` in Visual Studio.
3. **Restore NuGet packages**
   - Visual Studio will automatically restore.
4. **Build solution**
   - Use **Build → Build Solution** (`Ctrl+Shift+B`).

## Solution Structure
```
Ecours.Client.sln
├── Ecours.Desktop/           # WPF MVVM application
├── Ecours.Account/           # Account domain library
├── Ecours.Contractor/        # Contractor logic library
├── Ecours.Default/           # Default models and implementations
├── ecours/                   # Core entities and interfaces
├── Ecours.Utils/             # Shared utilities (logging, config)
└── Ecours.Client.Tests/      # Unit tests
```

## Ecours.Desktop Project Structure
```
Ecours.Desktop/
├── App.xaml (+.cs)            # Bootstrap, Prism initialization
├── Views/
│   ├── MainWindow.xaml        # Main window layout
│   ├── EcoursMessageWindow.xaml # Custom modal dialog
│   └── WidgetControl.xaml     # Reusable control template
├── ViewModel/
│   ├── MainWindowVM.cs        # Main window view model
│   ├── TabVM.cs               # Tab item view model
│   └── ApplicationCommands.cs # Central command definitions
├── Model/                     # Model definitions and data commands
├── Resources/                 # Resource dictionaries (styles, themes)
├── Images/                    # Icon assets for buttons and controls
└── Ecours.Desktop.csproj      # Project file (TargetFramework 4.6.1)
```

## Key Components
- **MainWindow & MainWindowVM**: Hosts tabbed interface and toolbar commands.
- **TabVM**: Represents individual tabs with close functionality.
- **ApplicationCommands**: Defines `DelegateCommand` instances for UI actions.
- **EcoursMessageWindow**: Styled pop-up dialog for messages and confirmations.
- **WidgetControl**: Demonstrates custom control creation with XAML templates.

## Running the Application
1. In Visual Studio, set **Ecours.Desktop** as startup project.
2. Press **F5** or **Debug → Start Debugging**.
3. Main window appears. Click the pencil icon to open a styled dialog.

## Testing
- Open **Test Explorer** in Visual Studio to run **Ecours.Client.Tests**.
- Or use command-line:
  ```bash
  dotnet test Ecours.Client.Tests\Ecours.Client.Tests.csproj
  ```

## Contributing
Contributions welcome! Please fork the repo and submit PRs:
1. Fork and branch off `main`.
2. Implement changes or new features in separate branch.
3. Add unit tests for new logic.
4. Ensure solution builds and tests pass.
5. Submit a pull request with detailed description.

## License
Licensed under the **MIT License**. See [LICENSE](LICENSE) for details.

