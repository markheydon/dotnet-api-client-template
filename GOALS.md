# Goals

**Project:** Acme.Client (rename after using this template)
**Owner:** (your name)
**Last updated:** (date)

---

## Why This Exists

Provide an unofficial .NET HTTP API client SDK: typed surface, DI registration, tests, NuGet packaging, and consumer documentation.

---

## Goals for v1.0

- **G1:** Cover the agreed v1 API surface (see `SCOPE.md` and `plan/API_HTTP_REFERENCE.md`).
- **G2:** Ship a stable NuGet package with clear consumer docs on GitHub Pages.

---

## Success Looks Like

- Consumers install via NuGet, call `AddYourProductClient`, and use resource services without hand-rolling HTTP.
- CI passes on every PR; releases publish via Trusted Publishing.

---

## Documentation audiences

| Channel | Audience |
|---------|----------|
| Root `README.md` | Contributors evaluating or cloning the template |
| `docs/` | Library integrators (GitHub Pages) |
| `src/*.Client/README.md` | NuGet.org package page readers |
| `plan/` | Maintainers (HTTP map, release, PR policy) |

---

## Revision History

| Date | Change | Reason |
|---|---|---|
| (date) | Initial draft from dotnet-api-client-template | New repository |
