# README for RoadStatus (James Smith)

## Building the code

### Pre-requisites
* .Net Core 2.1
* .Net Standard 2.0

### NuGet dependencies
NuGet dependencies will need to be restored. This should be done automatically as part of the build however if it needs to be done manually it can be done by running "dotnet restore" in the root of the application code.
E.g. C:\Git\RoadStatus>dotnet restore

List of Dependencies by Project;
* ConfigProvider - Newtonsoft.Json (v12.0.1)
* ConfigProviderTest - xunit (v2.4.1), xunit.runner.utility (v2.4.1), xunit.runner.visualstudio (v2.4.1)
* Logging - None
* RoadStatus - None
* RoadStatusApi - Newtonsoft.Json (v12.0.1)
* RoadStatusShared - None
* RoadStatusSharedTest - xunit (v2.4.1), xunit.runner.utility (v2.4.1), xunit.runner.visualstudio (v2.4.1)

### Building 
To build the code using the .Net Core Cli run "dotnet build" in the root of the application code.
E.g. C:\Git\RoadStatus>dotnet build

## Running the Output
There is a configuration file called config.json which needs to be updated with the Tfl API App Id and Development key. This file should be output to the RoadStatus project bin\Debug\netcoreapp2.1. If one needs to be created manually then it should have the following structure;

`{
  "TflApplicationId": "",
  "TflDeveloperKey": "",
  "TflRoadSummaryEndpoint": "https://api.tfl.gov.uk/Road/{0}?app_id={1}& app_key={2}"
}`

The build will generate the code to RoadStatus project in the bin\Debug\netcoreapp2.1 folder. To run the output run "dotnet roadstatus.dll {param}" where {param} is the RoadId the app should check. 
E.g. C:\Git\RoadStatus\bin\Debug\netcoreapp2.1>dotnet roadstatus.dll A12

To check the exit code then run "echo %errorlevel".
E.g. C:\Git\RoadStatus\bin\Debug\netcoreapp2.1>echo %errorlevel%

## Running the Tests
The build the code using the .Net Core Cli run "dotnet test {projectname}" in the root of the application code where {projectname} is the test project names.
There are two test projects in the solution as follows;
* ConfigProviderTest (2 tests)
* RoadStatusSharedTest (21 tests)

Example to run tests for both projects as follows;
* C:\Git\RoadStatus>dotnet test ConfigProviderTest

## Assumptions/Notes
* I have used constructor injection to inject dependencies into components however due to time constraints I have not implemented a container for managing dependencies.