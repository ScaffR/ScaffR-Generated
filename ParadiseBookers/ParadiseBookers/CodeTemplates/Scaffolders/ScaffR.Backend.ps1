[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

#$folder = Get-ProjectFolder Model -Project $coreProjectName
#$folder | % { if ($_.Document -ne $null){ $_.Document.Activate() }}

Get-Domain | % { scaffold ScaffR.Backend.For $_.Name -Force:$Force }

#$folder | % { if ($_.Document -ne $null){ $_.Document.Close() }}