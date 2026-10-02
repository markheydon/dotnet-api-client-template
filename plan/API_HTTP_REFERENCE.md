# HTTP API reference (maintainer)

Template reference for extending `Acme.Client`. Replace paths, envelopes, and auth with your upstream API.

## HTTP (`RestClient`)

- Resolve base URL from `AcmeClientOptions` / `HttpClient.BaseAddress` / `AcmeClient.DefaultBaseUrl`
- Build request URIs with `RestClient.BuildRequestUri` (uses resolved base, not only `HttpClient.BaseAddress`)
- Append `api_key` via `RestQuery` when configured (rename parameter if your API differs)
- Validate relative paths with `ApiPathValidation` before sending
- Reject duplicate `api_key` in caller-supplied query parameters
- `GetAsync<T>` deserialises with `AcmeJsonSerializerOptions`
- Map non-success HTTP to `AcmeApiException` with response body text
- Do not mutate `HttpClient.DefaultRequestHeaders`

## Tests

- `QueuedHttpMessageHandler` for unit tests
- JSON fixtures under `tests/.../TestSupport/Fixtures/` when responses are non-trivial

## Sample

- `samples/Acme.Console` — optional live smoke via `ACME_API_KEY`
