# Versioning Policy

**Project:** Acme.Client
**Last updated:** (date)

---

## Overview

[Semantic Versioning 2.0.0](https://semver.org/) for public releases. Package version is set in `src/Acme.Client/Acme.Client.csproj` and must match the release tag (see [plan/RELEASE.md](plan/RELEASE.md)).

---

## Publishing

Tags `v*.*.*` trigger [release.yml](.github/workflows/release.yml): build, pack, GitHub Release, and NuGet publish via Trusted Publishing.

---

## Revision History

| Date | Change | Reason |
|---|---|---|
| (date) | Initial draft from dotnet-api-client-template | New repository |
