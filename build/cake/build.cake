///////////////////////////////////////////////////////////////////////////////
// ADDINS
///////////////////////////////////////////////////////////////////////////////
#addin Cake.Coveralls

///////////////////////////////////////////////////////////////////////////////
// TOOLS
///////////////////////////////////////////////////////////////////////////////
#tool coveralls.io

///////////////////////////////////////////////////////////////////////////////
// OTHER SCRIPTS
///////////////////////////////////////////////////////////////////////////////
#load Utils/paths.cake

///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target = Argument<string>("Target", "Default");
var configuration = Argument<string>("Configuration", "Release");
var packageOutputPath = Argument<DirectoryPath>("PackageOutputPath", "packages");
var nugetApiKey = Argument<string>("NugetApiKey", "NUGET_API_KEY");
var coverageFile = new FilePath($"../{Paths.Artifacts.FullPath}/coverage.opencover.xml");

var coverallsToken = Argument<string>("Coveralls", "REPO_TOKEN");
var coverallsPath = Argument<string>("CoverallsPath", coverageFile.FullPath);

///////////////////////////////////////////////////////////////////////////////
// TASKS
///////////////////////////////////////////////////////////////////////////////

#load Tasks/clean.cake
#load Tasks/create-nuget-package.cake
#load Tasks/restore-nuget-packages.cake
#load Tasks/publish-nuget-package.cake
#load Tasks/build.cake
#load Tasks/run-unit-tests.cake
#load Tasks/publish-coverage.cake
#load Tasks/default.cake

///////////////////////////////////////////////////////////////////////////////
// RUN 
///////////////////////////////////////////////////////////////////////////////

RunTarget(target);