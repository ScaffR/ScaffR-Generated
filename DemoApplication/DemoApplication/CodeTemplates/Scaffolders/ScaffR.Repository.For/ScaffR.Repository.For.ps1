[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(   
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,     
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

$dataProject = Get-Project $dataProjectName

##############################################################
# Add Data Repository - ModelType
##############################################################
$outputPath = $ModelType + "Repository"
Add-TemplateWithModel $dataProjectName $outputPath Repository @{ Namespace = $rootNamespace; ClassName = $ModelType } -Force:$Force $TemplateFolders

##############################################################
# create repository interface for modeltype
##############################################################
$outputPath = "Interfaces\Data\I" + $ModelType + "Repository"
Add-TemplateWithModel $coreProjectName $outputPath IRepository @{ Namespace = $rootNamespace; ClassName = $ModelType } -Force:$Force $TemplateFolders

##############################################################
# Register the entity in the DbContext
##############################################################
$pluralName = Get-PluralizedWord $ModelType -culture en-us

$class = Get-ProjectType "DataContext" -Project $dataProjectName
$propertyToAdd = "public DbSet<" + $ModelType + "> " + $pluralName + "{ get; set; }"
$projPath = $dataProject.FullName.Replace($dataProjectName + '.csproj', 'DataContext.cs')
$checkForThis = "public DbSet<" + $ModelType + ">"
$propExists = $false
$file = $projPath
Get-Content $file | foreach-Object {  if($_.Contains($checkForThis)){ $propExists = $true }
}

if(!$propExists){	Add-ClassMember $class $propertyToAdd	}
