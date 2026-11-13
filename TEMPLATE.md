# API client template setup

Complete after **Use this template**.

Generic OSS repos (Blazor, non-packable tools) should start from [csharp-oss-template](https://github.com/markheydon/csharp-oss-template) instead.

## 1. Rename `Acme.Client`

| Find | Replace with |
|------|----------------|
| `Acme.Client` | `YourProduct.Client` |
| `AcmeClient` | `YourProductClient` |
| `AddAcmeClient` | `AddYourProductClient` |
| `AcmeClientOptions` | `YourProductClientOptions` |
| `api.example.com` | your API host |
| `ACME_API_KEY` | your env var name |

| Item | Action |
|------|--------|
| `Repo.slnx` | Rename to your solution (for example `YourProduct.slnx`) and update paths inside |
| `.github/workflows/*.yml` | Replace `Repo.slnx` with your solution file name |
| `.vscode/settings.json` | Set `dotnet.defaultSolution` to your solution file |
| `.cursor/commands/` | Replace `Repo.slnx` in command text if you use Cursor |
| `src/Acme.Client/` | Rename folder and `.csproj` |
| `tests/Acme.Client.Tests/` | Rename folder, `.csproj`, and project reference |
| `samples/Acme.Console/` | Rename if desired |
| `README.md`, `GOALS.md`, `SCOPE.md` | Product title and boundaries |
| `.github/ISSUE_TEMPLATE/config.yml` | Contact links to your repo |
| `SUPPORT.md`, `SECURITY.md` | Support routing and disclosure contact |
| `plan/PULL_REQUEST_POLICY.md` | Assignee and examples if they should not point at `markheydon` |

Rename workflow `grep` paths in `release.yml` when the assembly name changes.

## 2. Replace the example `Status` service

Implement real resource services using `RestClient.GetAsync<T>`. Use skill `extend-api-client`. Update `plan/API_HTTP_REFERENCE.md` and `docs/api-coverage.md`.

## 3. NuGet metadata

Edit `src/YourProduct.Client/YourProduct.Client.csproj`:

- `PackageId`, `Description`, `PackageProjectUrl` (consumer docs site)
- Pack readme: `src/YourProduct.Client/README.md` (not the repo root README)

Configure [NuGet Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package#trusted-publishing) and `NUGET_USER` secret before tagging.

## 4. GitHub Pages

Update `docs/_config.yml` (`title`, `baseurl`, `repository`) and consumer markdown. Point repository **About** website at the Pages URL.

## 5. ADRs

Keep [ADR-0001](adr/adr-0001-typed-http-client-and-di.md) (typed HTTP). Replace [ADR-0002](adr/adr-0002-api-client-scope.md) with your scope decision.

## 6. GitHub repository settings

- **About:** description, website (Pages URL), topics (`csharp`, `dotnet`, `nuget`, `api-client`, …).
- **Branch protection:** require CI on `main` if desired.
- **Secrets:** `NUGET_USER` for releases; optional keys for live smoke workflows.

## Optional: Documentation strategy

- In **`GOALS.md`** or **`SCOPE.md`**, state who each channel is for (contributors, library integrators).
- **`README.md`** remains the repository front door (evaluate, clone, build).
- **`docs/`** is the consumer site (GitHub Pages from `/docs` by default).
- **`plan/API_HTTP_REFERENCE.md`** is maintainer-only unless you publish it.
- Writing follows [`project-documentation`](.agents/skills/project-documentation/) and [placement guide](.agents/skills/project-documentation/references/document-placement.md).

## 7. Agents and tooling

| Path | Purpose |
|------|---------|
| `AGENTS.md` | Operating rules for coding agents |
| `.agents/skills/` | [Agent Skills](https://agentskills.io/specification) (`SKILL.md` per folder), including `extend-api-client` |

**Cursor (optional):** [`.cursor/rules/`](.cursor/rules/) and [`.cursor/commands/`](.cursor/commands/). Remove if unused.

**Dev Container (optional):** [`.devcontainer/devcontainer.json`](.devcontainer/devcontainer.json) includes `copilot-likes` and `cursor-cli`. Drop features you do not use.

Keep `AGENTS.md` aligned with your services and skills.

## 8. Dev Container and Codespaces

Default Dev Container targets .NET 10 with `github-cli`. Open in Codespaces or Dev Containers, then build/test per [AGENTS.md](AGENTS.md).

**Lock file:** first build may create `.devcontainer/devcontainer-lock.json`. Commit for Dependabot `devcontainers` updates, or gitignore it.

**HTTPS on WSL:** after `dotnet dev-certs https --trust` in the container, run `scripts/export-dev-cert-for-windows-host.sh` and import on the Windows host (output under `.local/`, gitignored).

### Optional: .NET Aspire / Spec Kit

Usually unnecessary for a thin SDK. If you add an AppHost or Spec Kit, extend the Dev Container per [csharp-oss-template `TEMPLATE.md`](https://github.com/markheydon/csharp-oss-template/blob/main/TEMPLATE.md) sections on Aspire and Spec Kit, using each project's current docs.

## 9. Using as a private repository

| Item | Notes |
|------|--------|
| Visibility | CI, Dev Container, and agent assets can stay as-is |
| `LICENSE` | Replace MIT when the code is not open source |
| NuGet | Trusted Publishing and package visibility on nuget.org are separate from repo visibility |
| Issue templates | Point `config.yml` at your private repo URLs |

## 10. First release

Bump `<Version>`, merge to `main`, `git tag v0.1.0-alpha.1 && git push origin v0.1.0-alpha.1`.

See [plan/RELEASE.md](plan/RELEASE.md).
