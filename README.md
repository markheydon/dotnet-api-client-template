# .NET API client SDK template

GitHub template for unofficial **HTTP API client** packages: typed `HttpClient`, `AddAcmeClient`, `RestClient` invariants, NuGet readme beside the `.csproj`, GitHub Pages docs, sample console, and Trusted Publishing release workflow.

**Generic OSS repo (Blazor, libraries without NuGet)?** Use [csharp-oss-template](https://github.com/markheydon/csharp-oss-template).

**Setup:** [TEMPLATE.md](TEMPLATE.md)

## Quick start

In a dev environment with the .NET 10 SDK (and .NET 8 for multi-target builds), or inside the [Dev Container](.devcontainer/devcontainer.json):

```bash
dotnet build Repo.slnx -c Release -warnaserror
dotnet test Repo.slnx -c Release --no-build
```

## Repository layout

| Path | Purpose |
|------|---------|
| `GOALS.md`, `SCOPE.md`, `CONVENTIONS.md` | Product and coding context for humans and agents |
| `AGENTS.md` | Operating rules for coding agents |
| `.agents/skills/` | Agent Skills (`SKILL.md` per folder); `extend-api-client` for new API operations |
| `.cursor/rules/`, `.cursor/commands/` | Optional Cursor-specific rules and commands |
| `.devcontainer/` | Dev Container for local VS Code / GitHub Codespaces |
| `src/Acme.Client/` | Packable SDK (`net8.0` + `net10.0`) |
| `samples/Acme.Console/` | Optional live smoke sample |
| `docs/` | Consumer documentation (GitHub Pages) |
| `plan/` | Maintainer HTTP map, release, and PR policy |
| `adr/` | Architectural decision records |

Private repositories can use the same layout; see [TEMPLATE.md](TEMPLATE.md) (section 9).

## Reference implementation

[dns-check-dotnet](https://github.com/markheydon/dns-check-dotnet) - production client built from these patterns.

## Licence

MIT - see [LICENSE](LICENSE).
