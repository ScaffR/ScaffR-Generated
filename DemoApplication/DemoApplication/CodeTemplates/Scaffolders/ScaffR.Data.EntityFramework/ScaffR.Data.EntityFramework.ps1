[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$outputPath = "Interfaces\Data\IDatabaseFactory"
Add-Template $coreProjectName $outputPath "IDatabaseFactory" -Force:$Force $TemplateFolders

$outputPath = "Interfaces\Data\IDataContext"
Add-Template $coreProjectName $outputPath "IDataContext" -Force:$Force $TemplateFolders

Add-Template $dataProjectName "BaseRepository" "BaseRepository" -Force:$Force $TemplateFolders
Add-Template $dataProjectName "UnitOfWork" "UnitOfWork" -Force:$Force $TemplateFolders
Add-Template $dataProjectName "DatabaseFactory" "DatabaseFactory" -Force:$Force $TemplateFolders
Add-Template $dataProjectName "DataContext" "DataContext" -Force:$Force $TemplateFolders

Register-NinjectDependency "IDatabaseFactory" "DatabaseFactory"
Register-NinjectDependency "IUnitOfWork" "UnitOfWork"