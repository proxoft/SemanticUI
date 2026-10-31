dotnet pack FomanticUI.Resources/FomanticUI.Resources.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o ../../PackagesBuild
dotnet pack FomanticUI.Core/FomanticUI.Core.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o ../../PackagesBuild
dotnet pack FomanticUI.Blazor/FomanticUI.Blazor.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o ../../PackagesBuild
dotnet pack FomanticUI.TagHelpers/FomanticUI.TagHelpers.csproj -p:IncludeSymbols=true -p:SymbolPackageFormat=snupkg -o ../../PackagesBuild
