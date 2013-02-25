[T4Scaffolding.Scaffolder(Description = "ScaffR.Architecture - Setup of projects and references in solution.")][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Add-Template $coreProjectName "Interfaces\Service\IService" "IService" -Force:$Force $TemplateFolders

Add-Template $serviceProjectName "BaseService" "BaseService" -Force:$Force $TemplateFolders
#Add-Template $serviceProjectName "IClientFactory" "IClientFactory" -Force:$Force $TemplateFolders
#Add-Template $serviceProjectName "ClientFactory" "ClientFactory" -Force:$Force $TemplateFolders
