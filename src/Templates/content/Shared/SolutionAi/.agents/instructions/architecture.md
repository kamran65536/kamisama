# Architecture Instructions

Inspect the solution first. Keep bounded-context contracts in Abstractions, domain behavior and provider-neutral implementations in Core, provider code in provider projects, reusable application composition in Bootstrap, and executable hosting in Server or AppHost projects.

Bounded contexts must not reference one another. A panel owns its Abstractions contracts and DTOs, Client UI and adapters, Core orchestration, and Server APIs; panel Core may compose contracts from multiple bounded contexts without leaking their DTOs.

Prefer templates over hand-built project skeletons. Treat `agent/design/*.yaml` as reusable creation input and `agent/solution-map.yaml` as the maintained record of implemented architecture.
