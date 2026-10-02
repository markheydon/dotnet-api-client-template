---
title: Example API client scope
status: accepted
date: 2026-10-02
deciders: (your name)
---

# ADR-0002: Public API scope

## Context

Replace this ADR with your product boundaries (read-only vs write, auth model, unofficial disclaimer, etc.).

## Decision

- Document which upstream operations the package exposes.
- Keep the public surface honest relative to official API documentation.
- Do not add undocumented write APIs without an explicit scope change.

## Consequences

- Consumers trust the package description and ADRs.
- New operations require updates to `docs/api-coverage.md` and tests.
