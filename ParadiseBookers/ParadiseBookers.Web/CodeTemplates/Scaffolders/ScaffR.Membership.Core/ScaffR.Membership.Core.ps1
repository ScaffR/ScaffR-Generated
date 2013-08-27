[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

Add-Template $coreProjectName "Model\User.Membership" "User.Membership" -Force:$Force $TemplateFolders

Add-Domain "Model\Role" "Role" -Force:$Force $TemplateFolders
Add-Domain "Model\UserRole" "UserRole" -Force:$Force $TemplateFolders
Add-Domain "Model\UserEmail" "UserEmail" -Force:$Force $TemplateFolders

 $templates = 
 	@(	"UserCreated", `
		"UserLockedOut", `
		"UserLoggedIn", `
		"UserLoggedOut", `
		"UserActivity")

foreach ($tml in $templates){
	$outputPath = "Common\Membership\Events\$tml"
	Add-Template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@(	"MembershipManager" )

foreach ($tml in $templates){
	$outputPath = "Common\Membership\$tml"
	Add-Template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@(	"MembershipElement" )

foreach ($tml in $templates){
	$outputPath = "Configuration\Membership\$tml"
	Add-Template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@(	"CoreSection.Membership" )

foreach ($tml in $templates){
	$outputPath = "Configuration\$tml"
	Add-Template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}