git pull

REM Stats Service
dotnet build ./02.Services/Stats/GoalKeeper.Stats.WebApi/GoalKeeper.Stats.WebApi.csproj
start cmd.exe @cmd /k "Title Stats Service && cd ./02.Services/Stats/GoalKeeper.Stats.WebApi && dotnet watch run"

REM DataCollector
dotnet build ./02.Services/DataCollector/GoalKeeper.DataCollector.MinimalApi/GoalKeeper.DataCollector.MinimalApi.csproj
start cmd.exe /k "Title DataCollector Service && cd ./02.Services/DataCollector/GoalKeeper.DataCollector.MinimalApi && dotnet watch run"