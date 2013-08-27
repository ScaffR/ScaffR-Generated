[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Interfaces\Data\IRepository"
Add-Template $coreProjectName $outputPath "IRepository" -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Data\IUnitOfWork"
Add-Template $coreProjectName $outputPath "IUnitOfWork" -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Paging\IPage"
Add-Template $coreProjectName $outputPath "IPage" -Force:$Force $TemplateFolders

$outputPath = "Common\Paging\Page"
Add-Template $coreProjectName $outputPath "Page" -Force:$Force $TemplateFolders

