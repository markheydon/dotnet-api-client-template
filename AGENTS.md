# Agent Instructions

Repository-specific operating rules for AI coding agents.

## Core Context

Read before non-trivial changes:

- `GOALS.md`
- `SCOPE.md`
- `CONVENTIONS.md`
- `plan/API_HTTP_REFERENCE.md`
- `adr/` - ADR-0001 typed HTTP; ADR-0002 scope

## Language

UK English in documentation, comments, and user-facing text. Do not use the em dash (U+2014); see `CONVENTIONS.md` (Documentation).

## Tech Stack

- Library targets **.NET 8.0 and .NET 10.0** (`TargetFrameworks` on the client project).
- xUnit v3 with Microsoft.Testing.Platform; NSubstitute when mocks are required; built-in asserts only.
- `AddAcmeClient` + `IHttpClientFactory` per [ADR-0001](adr/adr-0001-typed-http-client-and-di.md).

## Skills

Project skills live in `.agents/skills/`.

| Skill | Use when |
|---|---|
| `extend-api-client` | Adding documented API operations (models, services, tests, docs) |
| `create-architectural-decision-record` | Creating or major-updating an ADR |
| `project-documentation` | Diátaxis and project-aware docs (README, `docs/`, NuGet readme, placement) |
| `code-review` | PR or branch review before merge (see `.cursor/commands/loop-code-review.md`) |
| `implementation-guardrails` | Non-trivial SDK work, refactors, analyzer/build fixes - root-cause and proportionality discipline |

### Optional stacks (add in the child repo)

See [TEMPLATE.md](TEMPLATE.md) for Dev Container extensions. Onboard **.NET Aspire** and **Spec Kit** using each project's current official documentation (not by copying skills from another repository).

## Task Routing

- **Code** (`src/`, `tests/`, `samples/`): `CONVENTIONS.md` and `extend-api-client` when adding API surface.
- **Documentation** (`**/*.md` except `adr/`): `project-documentation` skill.
- **ADRs** (`adr/*.md`): ADR skill only.

## Not Allowed Without Explicit Instruction

- Add or remove NuGet packages (except central versions in `Directory.Packages.props` when maintaining deps).
- Modify CI/CD behaviour.
- Commit secrets or API keys.

## Pull Request Workflow

Follow [plan/PULL_REQUEST_POLICY.md](plan/PULL_REQUEST_POLICY.md) and [`.github/PULL_REQUEST_TEMPLATE.md`](.github/PULL_REQUEST_TEMPLATE.md).

Before opening a PR:

```bash
dotnet format Repo.slnx --verify-no-changes
dotnet build Repo.slnx -c Release -warnaserror
dotnet test Repo.slnx -c Release --no-build
```

Title shape: `[Type] Imperative summary (#NNN)` with labels from [plan/LABEL_STRATEGY.md](plan/LABEL_STRATEGY.md).

All agent-authored pull requests require human review before merge.
