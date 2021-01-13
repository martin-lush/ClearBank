# ClearBank DevTest

### Developer Setup
#### Requirements
- Install [.NET Core 3.1 SDK](https://www.microsoft.com/net/download)
- Install [Visual Studio 2019](https://www.visualstudio.com/downloads)

##### Alternatives (caveat emptor)
- [Visual Studio Code](https://code.visualstudio.com/download)

#### Setup
- Clone this repository
- Open solution in Visual Studio

##### Testing the solution

Solution was created to work with dotnet test.

- run `dotnet restore`
- run `dotnet test`

or

- Run all tests within Text Explorer window

### TODO List
Comments are placed throughout the code base, however here's a quick rundown:
- Add console app / Startup class to allow code execution
- Implement Dependency Injection
- Add additional validation in PaymentService.cs (done payment schemes but nothing to do with date ranges nor amount ranges)
- Service/Orchestrator to transfer money between accounts
- Return list of validation messages in addition to the success flag (true/false)
- Specification / Integration tests so full end to end journey can be done
