[T4Scaffolding.Scaffolder(Description = "WC.Payments - Generic Payment Provider")][CmdletBinding()]
param(
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("PipelineConfigurationElement")

foreach ($tml in $templates){
	add-template $infrastructureProjectName "Configuration\Pipeline\$tml" $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("Filter", `
		"FilterActivator", `
		"FilterChain", `
		"PipelineFactory", `
		"PipelineManager")

foreach ($tml in $templates){
	$outputPath = "Pipeline\$tml"
	add-template $infrastructureProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("ICoreProcessor")

foreach ($tml in $templates){
	$outputPath = "Interfaces\Pipeline\$tml"
	add-template $infrastructureProjectName $outputPath $tml -Force:$Force $TemplateFolders
}