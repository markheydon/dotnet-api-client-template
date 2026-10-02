---
name: extend-api-client
description: Extend an HTTP API client SDK — models, RestClient, services, tests, sample console, and docs. Use when adding new documented API operations to a project generated from dotnet-api-client-template.
---

# Extend API client

Follow [plan/API_HTTP_REFERENCE.md](../../plan/API_HTTP_REFERENCE.md) for HTTP invariants.

## Steps

1. Read upstream API documentation.
2. Add models and response wrappers with `JsonPropertyName`.
3. Implement service methods calling `RestClient.GetAsync<T>`.
4. Add `QueuedHttpMessageHandler` tests and JSON fixtures.
5. Update sample console and `docs/api-coverage.md`.
6. Run PR gates from [AGENTS.md](../../AGENTS.md).

## Guardrails

- UK English in docs and XML comments.
- Never log or commit secrets.
- No undocumented write APIs without scope change (ADR-0002).
