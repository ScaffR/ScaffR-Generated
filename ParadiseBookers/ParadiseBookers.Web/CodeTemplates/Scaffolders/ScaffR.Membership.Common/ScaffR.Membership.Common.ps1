[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

#scaffold scaffr.frontend.for User
#scaffold scaffr.frontend.for Role
#scaffold scaffr.frontend.for UserRole
#scaffold scaffr.frontend.for Person
#scaffold scaffr.frontend.for UserEmail

Register-ActionFilter "new AuthorizeAttribute()"

Register-NinjectDependency "IUserService" "UserService"
Register-NinjectDependency "IUserEmailService" "UserEmailService"
Register-NinjectDependency "IAuthenticationService" "AuthenticationService"

Register-ActionFilter "new Filters.UserContextFilter()"
