[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("CoreSection.Site")

foreach ($tml in $templates){
	$outputPath = "Configuration\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("SiteElement")

foreach ($tml in $templates){
	$outputPath = "Configuration\Site\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("Site")

foreach ($tml in $templates){
	$outputPath = "Common\Site\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

