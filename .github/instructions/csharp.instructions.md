---
applyTo: "Xtate.SharedContent/PackageContent/**/*.cs"
---

# C# package-content instructions

## Style and compatibility

- Follow `.editorconfig`: tabs, nullable annotations, analyzer rules, using order, and existing naming conventions.
- Match the AGPL header and style in adjacent package-content files.
- Use the narrowest correct target-framework or feature guard.
- Do not declare a framework type on targets that already provide it.

## Contract fidelity

- Match the intended framework or annotation namespace, accessibility, signature, attribute usage, and behavior.
- Keep compatibility declarations self-contained and safe when compiled into consuming projects.
- Avoid runtime initialization and assumptions about the package's own assembly.

## Generated and dependency files

- Do not edit `bin`, `obj`, or package output.
- Treat generated build-property files as generated and keep dependency versions in `Directory.Packages.props`.

## Verification

- Pack and inspect the content-file layout.
- Build representative modern and legacy consuming projects when compatibility declarations change.
