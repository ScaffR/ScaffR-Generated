[T4Scaffolding.Scaffolder()][CmdletBinding()]
param(        
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

function AddTemplate($template, $output, $name, $path, $templateFolder){
	Add-Template $identityModelProjectName $output $template -Force:$Force $templateFolder
}
$templatefolder

function Recurse($path){
 $fc = new-object -com scripting.filesystemobject
  $folder = $fc.getfolder($path)

  foreach ($i in $folder.files) {

    $name = $i.name.replace('.cs.t4', '')
	$path = $i.path.replace($templatefolder, '').replace('.cs.t4', '')

	addtemplate $name $path $name $path $folder.path
  }

  foreach ($i in $folder.subfolders) {
    Recurse($i.path)
  }
}

foreach ($fld in $TemplateFolders){
	$templatefolder = $fld + "\"
	recurse $fld
}