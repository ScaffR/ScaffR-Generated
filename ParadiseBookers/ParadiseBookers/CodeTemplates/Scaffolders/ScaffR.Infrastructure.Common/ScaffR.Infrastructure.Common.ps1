[T4Scaffolding.Scaffolder(Description = "ScaffR.Architecture - Setup of projects and references in solution.")][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Configuration\InfrastructureSection"
Add-Template $infrastructureProjectName $outputPath "InfrastructureSection" -Force:$Force $TemplateFolders