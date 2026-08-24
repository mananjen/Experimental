# Repository Instructions for Coding Agents

## Scope and priorities

This repository contains a Unity game under `game/`, space for a future backend
under `backend/`, and project documentation under `docs/`.

Work incrementally. Do not attempt to build the entire game or implement future
systems that were not requested. The current product direction and phased
roadmap are documented in `docs/DESIGN.md`.

## Before changing code

1. Inspect the existing repository and relevant files.
2. Confirm the smallest coherent implementation for the request.
3. Reuse existing systems and avoid duplicate abstractions.
4. State the intended approach before substantial changes.
5. Preserve unrelated user changes in the working tree.

## Repository boundaries

- Treat `game/` as the Unity project root.
- Keep Unity assets and code under `game/Assets/`.
- Commit `game/Packages/` and `game/ProjectSettings/`.
- Do not commit generated Unity caches, build outputs, IDE project files, or
  personal editor state covered by `.gitignore`.
- Keep backend code under `backend/` and durable documentation under `docs/`.

## C# and architecture

- Write clear, idiomatic, maintainable C#.
- Use descriptive names and focused classes and methods.
- Prefer composition to giant controllers and unnecessary inheritance.
- Avoid static global state, singleton-heavy designs, speculative abstractions,
  dependency-injection frameworks, and design-pattern ceremony unless a current
  requirement clearly justifies them.
- Keep Unity-specific dependencies near Unity-facing code when practical.
- Avoid adding third-party packages without a current, concrete need.
- Explain the reason for important patterns introduced for learning purposes.

Use private serialized fields for Inspector configuration when public access is
not otherwise required:

```csharp
[SerializeField] private float moveSpeed;
```

Cache component references where appropriate. Use Unity lifecycle methods
intentionally, respect the physics update model for physics-related movement,
and avoid repeated component lookups in hot update loops.

Comments should explain why a decision exists rather than narrating obvious
code.

## Input and gameplay configuration

- Use Unity's Input System package rather than the legacy `Input.GetKey` API.
- Separate physical input bindings from gameplay behavior.
- Expose frequently tuned gameplay values through serialized configuration.
- Use ScriptableObjects only where they materially improve reuse or iteration.

## Unity asset safety

Do not casually hand-author or heavily edit `.unity`, `.prefab`, `.asset`, or
`.meta` files as raw YAML. Unity assets are fragile when produced outside the
Editor.

Prefer C# scripts, Editor-safe automation, and clear setup instructions. If a
scene or prefab must be configured manually, document the required hierarchy,
components, fields, layers, and tags. Create Editor scripts when automation is
both useful and maintainable.

Never omit or discard Unity `.meta` files for assets intended to be committed.

## Verification

This is currently a personal prototype. Keep verification proportional to the
risk and scope of the change; do not build extensive test infrastructure unless
the user requests it or the project later requires stronger guarantees.

- Run quick, relevant automated checks when they already exist or are cheap to
  add.
- Report what was actually tested.
- For gameplay changes, confirm that the project compiles and test the affected
  behavior in Unity when the Editor is available.
- If Unity testing is unavailable, make conservative changes and clearly list
  the remaining Editor validation.
- Do not claim that gameplay behavior was verified when it was not played.
- Prefer confidence that the affected behavior is not broken over exhaustive
  coverage. Revisit this policy if the project becomes larger, collaborative,
  public, or commercially serious.

## Git workflow

- Divide work into small, focused chunks that are easy to understand and
  review. A chunk should represent one coherent purpose.
- Do not create commits. The user owns the repository history and must review
  and commit every chunk.
- At the end of each chunk, present:
  1. Every file created, updated, moved, or deleted.
  2. A short, precise reason for each change.
  3. What was verified and any validation that remains.
  4. Exact commands that stage and commit only that chunk.
- Do not begin another chunk until the current chunk has been presented for
  review, unless the user explicitly asks for multiple chunks at once.
- Use meaningful feature branches for substantial systems when requested.
- Prefer commit messages that describe one completed change.
- Never add generated `Library`, `Temp`, `Obj`, `Logs`, `UserSettings`, solution,
  or C# project files.

## Changelog

Every completed chunk must include a Markdown changelog entry under
`docs/changelog/`.

- Name entries with a three-digit, zero-padded sequence number and a short
  kebab-case description, for example
  `docs/changelog/001-initial-scaffolding.md`.
- Use the next available sequence number; never renumber existing entries.
- Record the chunk's purpose, the reason behind each material change, and a
  complete list of files created, updated, moved, or deleted.
- Include verification performed and any remaining manual validation.
- Keep entries concise and factual. The changelog records development history;
  it does not replace user-facing documentation or Git commit messages.

## Initial project work

When scaffolding a newly initialized checkout:

1. Confirm the Unity version and existing URP/2D Renderer configuration.
2. Confirm the Input System package and actions.
3. Create only folders needed for the current phase.
4. Establish namespaces and assembly boundaries only when useful.
5. Build the smallest input and movement foundation needed for the milestone.
6. Document any Unity Editor setup that remains.

Do not preemptively implement finished combat, enemy AI, inventories, quests,
save systems, dialogue, procedural generation, final art, or final UI.
