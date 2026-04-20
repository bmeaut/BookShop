$configuration=$args[0]

if( $configuration -eq $null ) {
    $configuration="Debug"
}

write-host $configuration

dotnet tool restore
dotnet nswag run blazorclient.json /variables:Configuration="$configuration"

if ($LASTEXITCODE -ne 0) {
    Write-Error "NSwag generation failed!" -ErrorAction Stop
}

dotnet makeGenericAgain -f "../ApiClient.cs"
