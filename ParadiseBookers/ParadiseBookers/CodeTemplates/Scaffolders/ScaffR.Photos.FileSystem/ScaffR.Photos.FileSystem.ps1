[T4Scaffolding.Scaffolder(Description = "Photos File System Provider")][CmdletBinding()]
param(
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("FileSystemProvider")

foreach ($tml in $templates){
	$outputPath = "Common\Photos\Providers\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}