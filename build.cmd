@echo off

cd SrtWordCount.Data
echo === Define schema ===
dotnet ef migrations add InitialCreate -s ..\SrtWordCount.WebApp\SrtWordCount.WebApp.csproj

echo === Create database ===
dotnet ef database update -s ..\SrtWordCount.WebApp\SrtWordCount.WebApp.csproj
cd ..

dotnet build

pause