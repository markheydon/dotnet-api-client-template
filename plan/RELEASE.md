# Release runbook

1. Set `<Version>` in `src/Acme.Client/Acme.Client.csproj`.
2. Merge to `main`.
3. Configure NuGet Trusted Publishing and `NUGET_USER` secret.
4. `git tag vX.Y.Z && git push origin vX.Y.Z`
5. Verify NuGet and GitHub Releases.

Tag must match csproj version (see `release.yml`).
