# Rehoukrel Template

A `dotnet new` template package for bootstrapping event-driven .NET microservice
solutions. The product is the template, not any one application built from it.
It exists so lab and portfolio projects start from a consistent, opinionated
architecture (Clean Architecture, DDD, CQRS, Result pattern, EF Core, auth)
instead of being re-derived each time.

## Language

### The product

**Template Package**:
The single NuGet package containing every template shipped by this repo.
_Avoid_: "the template" when more than one is meant

**Baseline Template**:
The template that scaffolds a new solution — host orchestration, shared kernel,
cross-cutting wiring — but no business capability.
_Avoid_: root template, starter, skeleton

**Module Template**:
The template that scaffolds one new Service into an existing solution created by
the Baseline Template.
_Avoid_: feature template, service generator

**Topology**:
Whether a generated solution deploys as independent services or a single host.
Chosen once, at scaffold time; not switchable at runtime.
_Avoid_: architecture, deployment mode

### Generated solutions

**Service**:
One independently deployable unit with exclusive ownership of its own database.
The unit the Module Template emits.
_Avoid_: module, microservice, app, component

**Contracts**:
A Service's dependency-free public surface — the only artifact other Services are
permitted to reference.
_Avoid_: shared, common, DTOs

**Domain Event**:
A fact raised by an aggregate, private to its owning Service, handled in-process
within the originating transaction.
_Avoid_: event (unqualified)

**Integration Event**:
A versioned business fact published across the Service boundary after commit, via
the outbox, carrying primitives only.
_Avoid_: event (unqualified), message

## Relationships

- A **Template Package** ships one **Baseline Template** and one **Module Template**
- A **Baseline Template** produces a solution of exactly one **Topology**
- A **Module Template** adds one **Service** to a solution
- A **Service** owns exactly one database and publishes zero or more **Integration Events**
- A **Service** exposes exactly one **Contracts** assembly
- A **Domain Event** may be mapped to an **Integration Event**; never the reverse
- A **Service** may reference another **Service**'s **Contracts**, and nothing else of it

## Example dialogue

> **Dev:** "Reporting needs the invoice total when Billing marks it paid — can it subscribe to `InvoicePaid`?"
> **Architect:** "`InvoicePaid` is a **Domain Event**. It lives in Billing's domain and carries `Money`. Subscribing means referencing Billing's domain assembly, which breaks the boundary. Billing maps it to an `InvoicePaidV1` **Integration Event** in its **Contracts**, publishes after commit, and Reporting consumes that."
> **Dev:** "So the same fact exists twice?"
> **Architect:** "Same fact, two audiences. One refactors freely, one is a published contract."

## Flagged ambiguities

- "module" was used for both a folder inside one deployable and an independently
  deployable unit — resolved: the generated unit is a **Service**; "module" is
  reserved for the **Module Template**'s name only.
- "event" was used for both in-process and cross-boundary facts — resolved:
  **Domain Event** and **Integration Event** are distinct concepts with distinct
  types, transaction semantics, and change cadence.
