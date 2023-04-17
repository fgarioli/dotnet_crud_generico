run:
	dotnet run
watch:
	dotnet watch run
build:
	dotnet build
coverage:
	dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
test:
	dotnet test