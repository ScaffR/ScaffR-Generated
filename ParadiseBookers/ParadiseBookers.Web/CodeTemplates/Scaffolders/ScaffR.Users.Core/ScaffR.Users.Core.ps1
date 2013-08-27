[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Add-Template $coreProjectName "Model\Gender" "Gender" -Force:$Force $TemplateFolders

Add-Domain "Model\Person" "Person" -Force:$Force $TemplateFolders
Add-Domain "Model\User" "User" -Force:$Force $TemplateFolders