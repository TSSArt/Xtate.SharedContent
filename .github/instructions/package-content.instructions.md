---
applyTo: "Xtate.SharedContent/{Xtate.SharedContent.csproj,Xtate.SharedContent.nuspec,PackageContent/**/*}"
---

# Package-content instructions

## Package contract

- Keep the project file's NuSpec base path, physical files, metadata, and `contentFiles` package paths aligned.
- Preserve compile/build-action, copy, and flatten behavior unless the packaging contract intentionally changes.
- Keep package content under `PackageContent/contentFiles/any/any/Properties`.
- Remember that these files compile inside consumers, not as a conventional runtime API from this package.

## Compatibility

- Verify whether each target framework already supplies an equivalent declaration.
- Match framework namespaces and signatures exactly enough for source compatibility.
- Keep target guards minimal and avoid duplicate type definitions on modern targets.

## Verification

- Pack the project and inspect the `.nupkg` content paths and metadata.
- Build representative modern and legacy consuming projects after compatibility changes.
