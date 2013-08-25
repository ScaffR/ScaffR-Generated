[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "DependencyInjection\NinjectResolver"
Add-Template $infrastructureProjectName $outputPath "NinjectResolver" -Force:$Force $TemplateFolders

$outputPath = "DependencyInjection\NinjectScope"
Add-Template $infrastructureProjectName $outputPath "NinjectScope" -Force:$Force $TemplateFolders