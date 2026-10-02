# .NET API client SDK template

GitHub template for unofficial **HTTP API client** packages: typed `HttpClient`, `AddAcmeClient`, `RestClient` invariants, NuGet readme beside the `.csproj`, GitHub Pages docs, sample console, and Trusted Publishing release workflow.

**Generic OSS repo (Blazor, libraries without NuGet)?** Use [csharp-oss-template](https://github.com/markheydon/csharp-oss-template).

**Setup:** [TEMPLATE.md](TEMPLATE.md)

## Quick start

```bash
dotnet build Repo.slnx -c Release -warnaserror
dotnet test Repo.slnx -c Release --no-build
```

## Reference implementation

[dns-check-dotnet](https://github.com/markheydon/dns-check-dotnet) — production client built from these patterns.

## Licence

MIT — see [LICENSE](LICENSE).
