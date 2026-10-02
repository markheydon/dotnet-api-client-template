# Agent Instructions

## Core context

- `GOALS.md`, `SCOPE.md`, `CONVENTIONS.md`
- `plan/API_HTTP_REFERENCE.md`
- `adr/` — ADR-0001 typed HTTP; ADR-0002 scope

## Tech stack

- .NET 8.0 and .NET 10.0
- xUnit v3, NSubstitute when needed, built-in asserts only
- `AddAcmeClient` + `IHttpClientFactory` per [ADR-0001](adr/adr-0001-typed-http-client-and-di.md)

## Skills

| Skill | Use when |
|---|---|
| `extend-api-client` | Adding documented API operations |
| `create-architectural-decision-record` | ADR work |
| `project-documentation` | Consumer docs |
| `pr-address-review` | PR review threads |

## PR gates

```bash
dotnet format Repo.slnx --verify-no-changes
dotnet build Repo.slnx -c Release -warnaserror
dotnet test Repo.slnx -c Release --no-build
```

See [plan/PULL_REQUEST_POLICY.md](plan/PULL_REQUEST_POLICY.md).
