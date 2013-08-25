[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

##############################################################
# Create the JSON Controller in the MvcApp
##############################################################
# Ensure we have a controller name, plus a model type if specified
$foundModelType = Get-ProjectType $ModelType -Project $baseProject.Name
if (!$foundModelType) { return }

$outputPath = "Controllers\" + $ModelType + "Controller"
$ximports = $coreProjectName + ".Model," + $coreProjectName + ".Interfaces.Service" 

Write-Host Creating new $($ModelType)Controller -ForegroundColor DarkGreen
Add-ProjectItemViaTemplate $outputPath -Template Controller `
	-Model @{ 	
	Namespace = $baseProject.Name; 
	DataType = [MarshalByRefObject]$foundModelType;	
	ExtraUsings = $ximports;
	} `
	-SuccessMessage "Added Controller of $ModelType output at {0}" `
	-TemplateFolders $TemplateFolders -Project $baseProject.Name -CodeLanguage $CodeLanguage -Force:$Force