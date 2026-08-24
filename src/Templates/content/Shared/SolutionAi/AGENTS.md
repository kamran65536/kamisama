# Agent Router

Inspect the `.slnx`, project references, package versions, and existing conventions before editing. Route work through:

- Architecture and isolation: `.agents/instructions/architecture.md`
- Reusable design input: `agent/design/*.yaml`
- Implemented source of truth: `agent/solution-map.yaml`, verified against code
- Template-first scaffolding: `.agents/skills/solution-scaffolding/SKILL.md`
- KamiSama APIs, when installed: `.agents/skills/kamisama-libraries/SKILL.md`
- YAML design, when installed: `.agents/skills/kamisama-solution-designer/SKILL.md`
- Capability planning and verification: `.agents/prompts/add-capability.md` and `.agents/commands/verify.md`

Keep bounded contexts provider-neutral and unaware of each other. Keep each panel's contracts, DTOs, orchestration, APIs, and UI isolated; panel Core may compose bounded-context contracts.

Update `agent/solution-map.yaml` after implemented changes. Build the narrowest affected target, secure APIs independently of UI, and keep secrets out of tracked configuration.
