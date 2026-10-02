---
title: Typed HTTP client and dependency injection
status: accepted
date: 2026-10-02
deciders: (your name)
tags: ["architecture", "http", "dependency-injection"]
---

# ADR-0001: Typed HTTP client and dependency injection

## Context

Libraries that call HTTP APIs should use `IHttpClientFactory` and typed clients, not `new HttpClient()` in public constructors. Consumers include hosted apps (DI), console tools, and unit tests (injected `HttpClient` with a test handler).

## Decision

- Register **`AcmeClient`** via `AddAcmeClient`, calling `AddHttpClient<AcmeClient>()`.
- Configure **`AcmeClientOptions`** in the extension callback (plain type, not `IOptions<T>` on the public surface).
- Public construction for tests: `AcmeClient(HttpClient, string? apiKey)`.
- Do not implement `IDisposable` on the client for DI registrations; the factory owns `HttpClient` lifetime.
- Configure resilience on the `IHttpClientBuilder` returned from `AddAcmeClient`, not inside the SDK.

## Consequences

- Aligns with Microsoft guidance on `HttpClient` lifetime.
- Console samples use a small `ServiceCollection` or manual `HttpClient`.
- Depends on `Microsoft.Extensions.Http`.

## References

- [CONVENTIONS.md](../CONVENTIONS.md)
- [plan/API_HTTP_REFERENCE.md](../plan/API_HTTP_REFERENCE.md)
