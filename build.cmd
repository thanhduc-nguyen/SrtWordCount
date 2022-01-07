@echo off

cd SrtWordCount.Data
echo === Define schema ===
dotnet ef migrations add InitialCreate -s ..\SrtWordCount.WebApp\SrtWordCount.WebApp.csproj

echo === Create database ===
cd ../SrtWordCount.WebApp
if not exist App_Data\ (
	mkdir App_Data
)
dotnet ef database update -s ..\SrtWordCount.WebApp\SrtWordCount.WebApp.csproj
cd ..

dotnet build

pause