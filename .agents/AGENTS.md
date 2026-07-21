# Xtate.SharedContent repository guide

Use this guide as the first source of repository context. This repository packages shared source into consuming projects; seemingly small declarations can affect every Xtate library and target framework.

## Project purpose

Xtate.SharedContent is a NuGet `contentFiles` package containing compatibility and annotation source used across Xtate repositories.

| Path | Purpose |
| --- | --- |
| `Xtate.SharedContent/Xtate.SharedContent.csproj` | Multi-targeted package and NuSpec base-path configuration |
| `Xtate.SharedContent/Xtate.SharedContent.nuspec` | Package metadata |
| `Xtate.SharedContent/PackageContent/contentFiles/any/any/Properties` | Source injected into consuming projects |
| `Xtate.SharedContent.sln` | Repository solution |

The package project targets `net11.0`, `net10.0`, `net9.0`, `net8.0`, `netstandard2.0`, and `net462`. There is currently no test project.

## Architecture

The package does not provide a normal runtime assembly API. Files under `PackageContent/contentFiles` are delivered to and compiled by consumers. They include compiler/runtime compatibility attributes, nullable-analysis attributes, IoC marker attributes, `Index`/`Range` shims, and JetBrains annotations.

Conditional compilation is the primary compatibility boundary. A declaration must exist only on targets that do not already provide an equivalent framework type. Namespace, accessibility, signature, attribute usage, and conditional guards must match the intended framework contract.

## Code conventions and hazards

- Follow `.editorconfig`: tabs, nullable annotations, analyzer rules, and existing naming/style.
- Preserve AGPL headers and the style of adjacent package-content files.
- Use the narrowest correct target-framework or feature guard for each compatibility declaration.
- Do not introduce a duplicate framework type on modern targets.
- Keep namespaces and public signatures compatible with the corresponding framework or annotation API.
- Treat the project file's `NuspecBasePath`, the `.nuspec`, and `PackageContent` as a single packaging contract.
- Treat `Directory.Build.props` as generated and keep dependency versions in `Directory.Packages.props`.
- Never edit or commit `bin` and `obj` output.

Path-specific rules in `.github/instructions` take precedence for matching files.

## Build and validation

```powershell
dotnet restore
dotnet build Xtate.SharedContent.sln
dotnet pack Xtate.SharedContent/Xtate.SharedContent.csproj
```

Because there is no test project, inspect the produced package and build representative consuming Xtate projects for modern and legacy targets when changing package content or conditional declarations.

## Change checklist

1. Identify the framework versions that provide the equivalent declaration.
2. Verify namespace, signature, accessibility, and attribute metadata against the intended contract.
3. Pack and inspect the resulting `contentFiles` paths.
4. Build representative modern and legacy consumers when compatibility code changes.
5. Keep generated output and unrelated existing work untouched.
