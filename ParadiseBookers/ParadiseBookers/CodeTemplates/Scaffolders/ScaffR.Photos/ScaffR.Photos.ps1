[T4Scaffolding.Scaffolder(Description = "WC.Payments - Generic Payment Provider")][CmdletBinding()]
param(
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("ImageHelper", `
		"Photo", `
		"PhotoList", `
		"PhotoManager", `
		"PhotoProvider", `
		"PhotoRequest", `
		"PhotoResize", `
		"PhotoThumbnail")

foreach ($tml in $templates){
	$outputPath = "Common\Photos\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@(	"PhotoConfigurationElement", `
		"PhotoProviderCollection", `
		"PhotoResizeCollection", `
		"PhotoResizeElement")

foreach ($tml in $templates){
	$outputPath = "Configuration\Photos\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@(	"CoreSection.Photos")

foreach ($tml in $templates){
	$outputPath = "Configuration\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}