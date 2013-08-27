[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("ApplicationClaims","ApplicationIdentity","AuthorizationManager","ClaimsTransformationHttpModule","ClaimsTransformer","PolicyReader","ResourceAction","Security","SecurityLevel")

foreach ($tml in $templates){
	$outputPath = "Common\Security\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("SecurityElement")

foreach ($tml in $templates){
	$outputPath = "Configuration\Security\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("CoreSection.Security")

foreach ($tml in $templates){
	$outputPath = "Configuration\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("IUserService.Security", "IAuthenticationService")

foreach ($tml in $templates){
	$outputPath = "Interfaces\Service\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("UserService.Security", "AuthenticationService")

foreach ($tml in $templates){
	add-template $serviceProjectName $tml $tml -Force:$Force $TemplateFolders
}


