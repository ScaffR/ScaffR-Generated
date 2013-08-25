[T4Scaffolding.Scaffolder(Description = "ScaffR.Architecture - Setup of projects and references in solution.")][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Global"
Add-Template $baseProject.Name $outputPath "Global" -Force $TemplateFolders
