# [My Tic-Tac-Toe Kata](TicTacToeKata.Requirements.md)

## Getting Started

This is a C# implementation of [Tic-Tac-Toe](https://en.wikipedia.org/wiki/Tic-tac-toe) that I use as my kata

## Prerequisites

* .NET Core 2.0

## Using My Tic-Tac-Toe Kata

### TicTacToe.Core.Interfaces

This project contains all the public enums, interfaces, and data transfer objects used by Tic-Tac-Toe.

### TicTacToe.Core

This project contains all the core implementations to Tic-Tac-Toe.

### TicTacToe.Core.Tests

This project contains the tests for the TicTacToe.Core project.

### TicTacToe.Console.Core

This project contains the core implementation for a console application like the TicTacToe.Console project.

### TicTacToe.Console

This projects contains the cross-platform console application of Tic-Tac-Toe.

```
dotnet TicTacToe.Console.dll
```

### TicTacToe.WindowsDesktop.Forms

This project contains the Windows Forms implementation of Tic-Tac-Toe.

```
TicTacToe.WindowsDesktop.Forms.exe
```

## Running the tests

### Unit Tests

Options for running the unit tests:
* Use Visual Studio's Test Runner
* Use ReSharper's Test Runner from within Visual Studio
* Use the nunit console runner, using a command such as:
```
nunit-console {path-to-assembly}
```

## Built With

* .NET Core 2.0
* NUnit and NSubstitute
* Visual Studio 2017
* ReSharper

## License

This project is licensed under the MIT License - see the [LICENSE](../LICENSE) file for details