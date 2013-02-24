[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

 $templates = 
 	@("AuthenticationStatus", `
		"ChangePasswordStatus", `
		"CreateUserStatus")

foreach ($tml in $templates){
	$outputPath = "Common\Membership\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("IUserService.Membership")

foreach ($tml in $templates){
	$outputPath = "Interfaces\Service\$tml"
	add-template $coreProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

 $templates = 
 	@("UserService.Membership")

foreach ($tml in $templates){
	$outputPath = $tml
	add-template $serviceProjectName $outputPath $tml -Force:$Force $TemplateFolders
}

scaffold scaffr.backend.for Role
scaffold scaffr.backend.for UserRole
scaffold scaffr.backend.for UserEmail

Add-Template $dataProjectName "Seeders\MembershipDataSeeder" "MembershipDataSeeder" -Force:$Force $TemplateFolders

add-migration "Membership Added" -Project $dataProjectName
update-database -Project $dataProjectName

Add-CodeToMethod (Get-Project $dataProjectName).Name "\Migrations\" "Configuration.cs" "Configuration" "Seed" "new Seeders.MembershipDataSeeder().Seed(context);"

#update-database -ProjectName $dataProjectName


