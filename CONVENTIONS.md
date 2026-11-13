> Coding and design conventions for this repository.

# Conventions

**Project:** Acme.Client
**Last updated:** (date)

When in doubt, follow this file. Significant architecture changes need an ADR.

---

## Project Structure

```
src/
└── Acme.Client/

tests/
└── Acme.Client.Tests/

samples/
└── Acme.Console/

docs/
```

Consumer-facing guides for GitHub Pages live under `docs/`. The packed NuGet readme is `src/Acme.Client/README.md`.

---

## Target framework

- Shipped SDK **`net8.0;net10.0`** on `Acme.Client`; pin the SDK band in `global.json` with `rollForward: latestPatch`.
- CI installs .NET 8 and 10 SDKs so both targets build.
- Sample and test projects target `net10.0` unless you need otherwise.

---

## C# patterns

- **Async/await** for I/O; propagate `CancellationToken` on public async APIs.
- Do not use `.Result`, `.Wait()`, or sync-over-async.
- **Nullable reference types** enabled (`Directory.Build.props`).
- **Treat warnings as errors** in all projects.
- **XML documentation** on public API members.
- **`JsonPropertyName`** on serialised model properties.
- **HTTP:** typed client via `AddAcmeClient` and `IHttpClientFactory` - see [ADR-0001](adr/adr-0001-typed-http-client-and-di.md). Do not `new HttpClient()` inside the library.
- Do not add NuGet packages or change architecture without an ADR and explicit instruction.

---

## Testing

- **xUnit v3** with Microsoft.Testing.Platform.
- **NSubstitute** when mocks are required.
- **Built-in `Assert` only** - no FluentAssertions, Shouldly, Moq, NUnit, or MSTest.
- Test classes: `[ClassName]Tests`. Test methods: `Method_State_Expected`.

---

## Documentation

- UK English in docs and comments.
- Do not use the em dash (Unicode U+2014) in user-facing text, code comments, or documentation in product scope (`src/`, `tests/`, `samples/`, `docs/`, `adr/`, and related root markdown). Use spaced ASCII hyphen ` - ` for prose breaks; use a single `-` for empty or missing UI values (for example table placeholders).
- **README.md** (repo root): template and contributors.
- **`docs/`**: consumer guides (GitHub Pages).
- **`src/.../README.md`**: NuGet package readme.
- **`plan/API_HTTP_REFERENCE.md`**: maintainer endpoint map (not published to Pages by default).
- See `.agents/skills/project-documentation/` for placement detail.
