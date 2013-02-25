[T4Scaffolding.Scaffolder(Description = "Enter a description of CodePlanner.ScaffoldAll.For here")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$from = "I$($ModelType)Service"
$to = "$($ModelType)Service"

Register-NinjectDependency($from, $to)

$from = I$($ModelType)Repository"
$to = "$($ModelType)Repository"

Register-NinjectDependency($from, to)

