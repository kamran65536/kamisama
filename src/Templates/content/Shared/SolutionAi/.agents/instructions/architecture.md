# Architecture Instructions

Inspect the solution first. Keep contracts in Abstractions, implementations and web modules in Core, provider code in provider projects, reusable application composition in Bootstrap, and executable hosting in Server or AppHost projects.

Prefer provider-neutral bounded contexts. Add database support as a separate project and register only the provider selected by host configuration.
