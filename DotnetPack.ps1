Remove-Item TempRelease\* -ErrorAction Ignore
dotnet pack src\HttpBuilders.sln -c release -o TempRelease