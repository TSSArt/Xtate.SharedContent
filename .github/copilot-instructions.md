# Xtate.SharedContent Copilot instructions

## Repository at a glance

Xtate.SharedContent is a NuGet `contentFiles` package. Source under `Xtate.SharedContent/PackageContent/contentFiles/any/any/Properties` is injected into and compiled by consuming Xtate projects. There is no test project.

Read [`.agents/AGENTS.md`](../.agents/AGENTS.md) for architecture and hazards. Apply every matching file in [`.github/instructions`](instructions); those rules are more specific than this guide.

## Working approach

1. Identify which target frameworks already provide the declaration being changed.
2. Compare namespace, accessibility, signature, attribute usage, and conditional compilation with the intended framework contract.
3. Keep the project file's NuSpec base path, the `.nuspec`, and physical package paths aligned.
4. Pack and inspect the package after changes.
5. Build representative modern and legacy consumers for compatibility changes.

## Build and validate

```powershell
dotnet restore
dotnet build Xtate.SharedContent.sln
dotnet pack Xtate.SharedContent/Xtate.SharedContent.csproj
```

The package project targets `net11.0`, `net10.0`, `net9.0`, `net8.0`, `netstandard2.0`, and `net462`.

## Shared coding rules

- Follow `.editorconfig`; C# uses tabs, nullable annotations, analyzers, and existing file style.
- Match the AGPL header and nearby compatibility declarations.
- Use the narrowest correct target-framework or feature guard.
- Do not define a framework type on targets that already provide it.
- Keep namespaces and public signatures compatible with the corresponding framework or annotation API.
- Treat `Directory.Build.props` as generated and keep dependency versions in `Directory.Packages.props`.
- Never edit or commit `bin`, `obj`, or package output.

## Packaging guardrails

- Package content belongs under `PackageContent/contentFiles/any/any/Properties`.
- Content files are compiled by consumers; avoid runtime initialization or package-local assumptions.
- Preserve the package's existing content-file build action, copy behavior, and folder layout.
- Keep conditional declarations self-contained so all target frameworks compile.
- When changing the `.nuspec`, inspect the produced `.nupkg` rather than assuming layout.

## Documentation

Update README or repository guidance when package purpose, content categories, supported targets, build commands, or validation expectations change.

## Before finishing

Confirm compatibility guards, signatures, package layout, generated-output safety, representative consumer validation, and task-scoped changes.
