[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Add-CodeToMethod $baseProject.Name "\Filters\" "UserContextFilter.cs" "UserContextFilter" "RegisterFilters" "filters.Add(new UserContextFilters.ChangePasswordRequired());"

