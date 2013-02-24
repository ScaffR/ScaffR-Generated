[T4Scaffolding.Scaffolder(Description = "ScaffR.Architecture - Setup of projects and references in solution.")][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Interfaces\Eventing\IHandles"
Add-Template $infrastructureProjectName $outputPath "IHandles" -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Eventing\IMessageBus"
Add-Template $infrastructureProjectName $outputPath "IMessageBus" -Force:$Force $TemplateFolders

$outputPath = "Eventing\MessageBus"
Add-Template $infrastructureProjectName $outputPath "MessageBus" -Force:$Force $TemplateFolders
