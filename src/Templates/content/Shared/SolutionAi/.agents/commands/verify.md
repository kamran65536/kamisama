# Verify

Run `dotnet build` on the narrowest affected `.slnx` or project. Verify `agent/solution-map.yaml` against the `.slnx` and project references, inspect configuration for unresolved or secret values, confirm APIs enforce authorization independently of UI, and check bounded-context and panel reference isolation.
