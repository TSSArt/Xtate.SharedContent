---
applyTo: ".github/workflows/**/*.{yml,yaml}"
---

# GitHub Actions instructions

## Preserve workflow intent

- Keep `publish.yml` triggered by version tags and manual dispatch.
- Preserve version calculation, restore, build, pack, and publication ordering.
- Keep package output paths and the existing `--no-restore` / `--no-build` chaining.
- Do not add a test step unless a test project is introduced.

## Security and compatibility

- Keep permissions minimal and secrets scoped to publication steps.
- Reuse existing secret names and package feeds; never add plaintext credentials.
- Preserve the .NET SDK setup needed by the multi-targeted package.
- Pin actions to explicit major versions consistent with the repository.

## Verification

- Validate YAML syntax and expressions.
- Check that package paths, triggers, permissions, and publication destinations still match the intended release flow.
