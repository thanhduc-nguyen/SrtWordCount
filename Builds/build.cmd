@echo off

if "%1"=="Release" (set Configuration=Release) else (set Configuration=Debug)
echo Building in %Configuration%

echo === Migrations ===
cd ../SrtWordCount.Data
dotnet ef migrations add InitialCreate -s ../SrtWordCount.WebApp/SrtWordCount.WebApp.csproj

if "%Configuration%"=="Release" (
	echo === Generate SQL script ===
	dotnet ef dbcontext script -s ../SrtWordCount.WebApp/SrtWordCount.WebApp.csproj -o ../SqlScripts/StoreScript.sql 
) else (
	echo === Generate database ===
	cd ../SrtWordCount.WebApp
	if not exist App_Data/ (
		mkdir App_Data
	)
	cd ../SrtWordCount.Data
	dotnet ef database update -s ../SrtWordCount.WebApp/SrtWordCount.WebApp.csproj
)

echo === Build solution ===
cd ..
dotnet build

cd Builds/

pause