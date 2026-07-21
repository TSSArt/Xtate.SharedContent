# Xtate.SharedContent

[![NuGet](https://img.shields.io/nuget/v/Xtate.SharedContent.svg)](https://www.nuget.org/packages/Xtate.SharedContent)
[![License: AGPL-3.0-or-later](https://img.shields.io/badge/license-AGPL--3.0--or--later-blue.svg)](LICENSE)

Xtate.SharedContent is a build-time support package for Xtate repositories. It distributes shared source files as NuGet `contentFiles`, primarily compatibility attributes and annotations required when the same code targets modern .NET, .NET Standard 2.0, and .NET Framework 4.6.2.

This package is infrastructure for Xtate libraries rather than a general runtime API.

## Package contents

- Compiler compatibility attributes such as `CallerArgumentExpressionAttribute`, `CollectionBuilderAttribute`, and `IsExternalInit`.
- Nullable-analysis attributes for target frameworks that do not provide them.
- `Index` and `Range` compatibility implementations.
- Interpolated-string-handler and required-member compatibility attributes.
- Xtate IoC marker attributes.
- JetBrains annotation attributes used by the shared codebase.

The files are packaged from `Xtate.SharedContent/PackageContent/contentFiles/any/any/Properties` and compiled into consuming projects according to their conditional declarations.

## Installation

Xtate projects normally reference the package as a private build dependency:

```xml
<PackageReference Include="Xtate.SharedContent" PrivateAssets="all" />
```

Application projects generally do not need to reference it directly.

## Supported frameworks

The package project targets .NET 11, .NET 10, .NET 9, .NET 8, .NET Standard 2.0, and .NET Framework 4.6.2.

## Building from source

```shell
git clone https://github.com/TSSArt/Xtate.SharedContent.git
cd Xtate.SharedContent
dotnet restore
dotnet build Xtate.SharedContent.sln
dotnet pack Xtate.SharedContent/Xtate.SharedContent.csproj
```

There is currently no test project. Validate changes by packing the project and, when compatibility declarations change, building representative consuming Xtate projects for both modern and legacy target frameworks.

## Repository layout

| Path | Description |
| --- | --- |
| `Xtate.SharedContent/Xtate.SharedContent.csproj` | Multi-targeted package and NuSpec base-path configuration |
| `Xtate.SharedContent/Xtate.SharedContent.nuspec` | Package metadata |
| `Xtate.SharedContent/PackageContent` | Source files delivered to consuming projects |
| `.github/instructions` | Path-specific guidance for coding agents |
| `.github/workflows` | Publishing workflow |
| `.agents` | Repository guide for maintainers and coding agents |

## Contributing

Contributions are welcome. Read the [repository guide](.agents/AGENTS.md), follow `.editorconfig`, and keep every compatibility declaration guarded by the narrowest correct target-framework condition. Do not edit generated `bin` or `obj` output.

Use [GitHub Issues](https://github.com/TSSArt/Xtate.SharedContent/issues) for bug reports and feature requests.

## License

Xtate.SharedContent is licensed under the [GNU Affero General Public License v3.0 or later](LICENSE).
