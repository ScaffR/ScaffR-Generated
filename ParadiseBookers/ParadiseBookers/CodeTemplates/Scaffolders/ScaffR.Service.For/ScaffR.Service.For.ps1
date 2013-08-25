[T4Scaffolding.Scaffolder(Description = "Enter a description of ScaffR.Services.For here")][CmdletBinding()]
param(   
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,     
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = $ModelType + "Service"
Add-TemplateWithModel $serviceProjectName $outputPath Service @{ Namespace = $rootNamespace; ClassName = $ModelType } -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Service\I" + $ModelType + "Service"
Add-TemplateWithModel $coreProjectName $outputPath IService @{ Namespace = $rootNamespace; ClassName = $ModelType } -Force:$Force $TemplateFolders
