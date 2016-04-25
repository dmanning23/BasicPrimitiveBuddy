nuget pack .\PrimitiveBuddy.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push *.nupkg