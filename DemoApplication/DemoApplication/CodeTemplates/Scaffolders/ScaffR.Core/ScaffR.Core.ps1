[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Model\DomainObject"
Add-Template $coreProjectName $outputPath "DomainObject" -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Validation\IValidationContainer"
Add-Template $coreProjectName $outputPath "IValidationContainer" -Force:$Force $TemplateFolders

$outputPath = "Common\Validation\ValidationContainer"
Add-Template $coreProjectName $outputPath "ValidationContainer" -Force:$Force $TemplateFolders

$outputPath = "Common\Validation\ValidationEngine"
Add-Template $coreProjectName $outputPath "ValidationEngine" -Force:$Force $TemplateFolders

$outputPath = "Configuration\CoreSection"
Add-Template $coreProjectName $outputPath "CoreSection" -Force:$Force $TemplateFolders

