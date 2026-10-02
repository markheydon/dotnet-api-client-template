# API client template setup

After **Use this template**:

## 1. Rename `Acme.Client`

| Find | Replace with |
|------|----------------|
| `Acme.Client` | `YourProduct.Client` |
| `AcmeClient` | `YourProductClient` |
| `AddAcmeClient` | `AddYourProductClient` |
| `AcmeClientOptions` | `YourProductClientOptions` |
| `api.example.com` | your API host |
| `ACME_API_KEY` | your env var name |

Rename folders, `.csproj`, solution paths, and workflow `grep` paths in `release.yml`.

## 2. Replace the example `Status` service

Implement real resource services (`Groups`, `Invoices`, …) using `RestClient.GetAsync<T>`. Update `plan/API_HTTP_REFERENCE.md` and `docs/api-coverage.md`.

## 3. NuGet metadata

Edit `src/YourProduct.Client/YourProduct.Client.csproj`:

- `PackageId`, `Description`, `PackageProjectUrl` (consumer docs site)
- Pack readme: `src/YourProduct.Client/README.md` (not the repo root README)

Configure [NuGet Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package#trusted-publishing) and `NUGET_USER` secret before tagging.

## 4. GitHub Pages

Update `docs/_config.yml` (`title`, `baseurl`, `repository`) and consumer markdown. Point repository **About** website at the Pages URL.

## 5. ADRs

Keep [ADR-0001](adr/adr-0001-typed-http-client-and-di.md) (typed HTTP). Replace [ADR-0002](adr/adr-0002-api-client-scope.md) with your scope decision.

## 6. Cursor

Use skill `extend-api-client` when adding upstream operations. Keep `AGENTS.md` aligned with your services.

## 7. First release

Bump `<Version>`, merge to `main`, `git tag v0.1.0-alpha.1 && git push origin v0.1.0-alpha.1`.

See [plan/RELEASE.md](plan/RELEASE.md).
