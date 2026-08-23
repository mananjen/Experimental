# Experimental

A long-term experimental game-development project focused on building a **high-impact 2D / 2.5D pixel-art action game** with a hybrid **melee + ranged combat system**.

The visual and presentation target is inspired by modern cinematic pixel-art games such as **REPLACED**, but the project is intentionally scoped as a small, systems-first indie prototype rather than an attempt to reproduce AAA/large-studio production values.

The immediate goal is simple:

> Build a small combat sandbox that feels excellent to control before investing in final art, story, levels, or content.

---

## Project Status

**Phase:** Pre-production / technical scaffolding

**Current priority:** Establish a clean Unity project architecture that supports rapid experimentation with player movement and combat.

This repository should remain playable and understandable throughout development.

---

# Vision

The eventual game should combine:

- Responsive 2D movement
- Fast melee combat
- Firearms
- Dodging / mobility
- Strong hit reactions
- Hit-stop
- Knockback
- Camera feedback
- Particles and impact effects
- Cinematic lighting
- High-quality pixel art
- 2D gameplay with the possibility of 2.5D presentation
- Small but highly polished environments
- Strong atmosphere rather than large-scale content

The project should prioritize **game feel over feature count**.

A short, polished experience is preferable to a large unfinished game.

---

# Design Pillars

## 1. Combat must feel good before it looks good

Placeholder art is expected during prototyping.

Do not block gameplay work on finished sprites, animations, VFX, audio, or environments.

Initial player and enemy representations may be simple shapes.

---

## 2. Melee and ranged combat should complement each other

The eventual combat loop should allow combinations such as:

- Slash → slash → gunshot
- Launcher → shoot airborne enemy
- Dodge → counterattack
- Parry → punish
- Melee stagger → ranged follow-up

The player should eventually feel fluid switching between close-range and ranged attacks.

---

## 3. Feedback matters

Combat should eventually make heavy use of:

- Hit-stop
- Camera shake
- Enemy recoil
- Knockback
- Screen effects
- Impact VFX
- Weapon trails
- Muzzle flashes
- Sound cues
- Animation timing

These systems should be independently configurable where practical.

---

## 4. Keep scope small

Do **not** prematurely add:

- Open-world systems
- Procedural world generation
- Crafting
- Dialogue systems
- Skill trees
- Large inventories
- Networking
- Multiplayer
- Live services
- Large save systems
- Quest systems
- Complex UI frameworks

unless explicitly requested.

The project must first prove that movement and combat are fun.

---

# Technology

## Engine

**Unity 6.3 LTS**

Target platform initially:

- Windows PC

Possible future targets may include other desktop platforms.

---

## Rendering

Use:

**Universal Render Pipeline (URP) / Unity 2D Renderer**

The project may eventually use:

- 2D lights
- Normal-mapped sprites
- Bloom
- Post-processing
- Shader effects
- Fog
- Parallax
- 3D environmental geometry behind 2D gameplay

Do not require these systems for the first gameplay prototype.

---

## Language

**C#**

Prefer clear, idiomatic, maintainable C# over clever abstractions.

---

## Input

Use the **Unity Input System package**, not the legacy `Input.GetKey` API, unless explicitly requested otherwise.

Input handling should be separated from gameplay logic.

Expected initial controls:

| Action | Keyboard |
|---|---|
| Move | A / D |
| Jump | Space |
| Dash | Left Shift |
| Primary melee | Left Mouse Button |
| Fire weapon | Right Mouse Button |

Controller support can be added later.

---

# Initial Development Target

The first playable milestone is called:

## Combat Sandbox v0.1

One small test room.

The player should eventually be able to:

1. Move
2. Jump
3. Fall
4. Dash
5. Perform a basic melee attack
6. Fire a basic ranged weapon
7. Damage a simple enemy
8. Receive clear feedback when an attack lands

No final art is required.

---

# Development Phases

## Phase 0 — Project Scaffolding

Set up:

- Folder structure
- Assembly boundaries only if justified
- Input abstraction
- Player component structure
- Basic gameplay interfaces
- Development conventions
- Placeholder `CombatSandbox` scene structure

Do not over-engineer.

---

## Phase 1 — Movement

Implement:

- Horizontal movement
- Acceleration / deceleration
- Jumping
- Falling
- Ground detection
- Coyote time
- Jump buffering
- Dash
- Dash cooldown
- Basic movement tuning

Movement should be parameterized so values can be tuned without rewriting code.

---

## Phase 2 — Melee Combat

Implement:

- Attack input
- Attack states
- Hitboxes
- Hurtboxes
- Damage
- Knockback
- Hit-stop
- Basic combo support
- Enemy hit reaction

Start with one attack before implementing a combo chain.

---

## Phase 3 — Ranged Combat

Implement:

- Basic firearm
- Fire rate
- Projectile or hitscan abstraction
- Damage
- Muzzle event hooks
- Recoil hooks
- Ammo only if it improves gameplay

Do not add complicated weapon inventory systems yet.

---

## Phase 4 — Enemy Prototype

Implement one simple enemy capable of:

- Idle
- Detect player
- Approach player
- Attack
- Take damage
- Be staggered
- Die

Traditional deterministic game AI should be used initially.

Do not introduce language models or agent systems into core combat AI during this phase.

---

## Phase 5 — Polish

Only after the core loop feels good:

- Pixel-art character
- Real animation
- Weapon effects
- Impact VFX
- Camera tuning
- Lighting
- Audio
- Environmental art
- Post-processing

---

# Recommended Repository Structure

```text
Experimental/
├── Assets/
│   ├── Art/
│   │   ├── Characters/
│   │   ├── Environments/
│   │   ├── UI/
│   │   └── Placeholder/
│   │
│   ├── Audio/
│   │   ├── Music/
│   │   └── SFX/
│   │
│   ├── Materials/
│   │
│   ├── Prefabs/
│   │   ├── Player/
│   │   ├── Enemies/
│   │   ├── Combat/
│   │   └── Environment/
│   │
│   ├── Scenes/
│   │   └── CombatSandbox.unity
│   │
│   ├── Scripts/
│   │   ├── Core/
│   │   ├── Input/
│   │   ├── Player/
│   │   │   ├── Movement/
│   │   │   ├── Combat/
│   │   │   └── States/
│   │   ├── Combat/
│   │   ├── Weapons/
│   │   ├── Enemies/
│   │   ├── Camera/
│   │   └── Utilities/
│   │
│   ├── ScriptableObjects/
│   ├── Settings/
│   └── VFX/
│
├── Packages/
├── ProjectSettings/
├── .gitignore
└── README.md
```

This structure is a guideline, not a reason to create empty abstractions.

Only create folders that are useful for the current phase.

---

# Architecture Guidelines

## Prefer composition over giant controllers

Avoid a single `PlayerController.cs` containing every system.

Prefer focused components such as:

```text
Player
├── PlayerInputReader
├── PlayerMotor
├── PlayerStateMachine
├── PlayerCombat
├── PlayerHealth
└── Rigidbody2D
```

Exact names may evolve.

---

## Player State Machine

Player behavior will likely benefit from a lightweight finite state machine.

Likely states include:

```text
Grounded
├── Idle
├── Run
└── Attack

Airborne
├── Jump
└── Fall

Dash
Hurt
Dead
```

Do not create every future state immediately.

Build only the states currently required.

Avoid deeply coupled state classes.

---

## Input

Gameplay systems should consume semantic actions such as:

```csharp
Move
JumpPressed
DashPressed
AttackPressed
FirePressed
```

They should not directly query keyboard keys.

This keeps the gameplay code independent of physical controls.

---

## Tunable Gameplay Values

Values that are frequently tuned should not be scattered as magic numbers.

Examples:

```text
Move speed
Acceleration
Deceleration
Jump force
Coyote time
Jump buffer duration
Dash speed
Dash duration
Dash cooldown
Attack damage
Knockback
Hit-stop duration
```

Prefer serialized configuration.

Use ScriptableObjects where they clearly improve reuse or iteration, but do not create an elaborate data framework before it is needed.

---

## Combat Model

The combat architecture should eventually distinguish:

### Hitbox

An area capable of applying an attack.

### Hurtbox

An area capable of receiving an attack.

### Attack Data

Information associated with a hit, potentially including:

```text
Damage
Knockback
Hit-stop
Stun
Hit direction
Attack ID
Source
```

Aim for a combat system that can later support both melee attacks and projectiles.

---

# Coding Standards

## General

- Use descriptive names.
- Keep classes focused.
- Prefer small methods.
- Avoid unnecessary inheritance.
- Avoid static global state unless clearly justified.
- Avoid premature dependency injection frameworks.
- Avoid unnecessary design-pattern ceremony.
- Avoid speculative systems built for hypothetical future requirements.
- Prefer readable code over clever code.

---

## Unity

Prefer:

```csharp
[SerializeField] private float moveSpeed;
```

over making fields public solely for Inspector access.

Cache component references when appropriate.

Use Unity lifecycle methods intentionally.

Physics-related movement should respect Unity's physics update model.

Do not repeatedly call expensive component lookups inside hot update loops without reason.

---

## Comments

Comments should explain **why**, not restate obvious code.

Good:

```csharp
// Allows jump input shortly before landing to still trigger,
// making platforming feel more responsive.
```

Bad:

```csharp
// Set velocity.
rb.linearVelocity = velocity;
```

---

# Git Workflow

The `main` branch should remain reasonably stable.

Use feature branches for meaningful systems.

Examples:

```text
feature/project-scaffolding
feature/player-movement
feature/player-dash
feature/melee-combat
feature/ranged-combat
feature/enemy-basic
```

Prefer small, focused commits.

Example:

```text
Add player input abstraction

Implement horizontal player movement

Add configurable jump buffering

Add initial dash state
```

Avoid enormous commits such as:

```text
Implement entire combat system
```

---

# Files That Must Not Be Committed

Unity-generated cache/build files must remain ignored.

Examples include:

```text
Library/
Temp/
Obj/
Logs/
Build/
Builds/
UserSettings/
```

Do not commit generated IDE files such as:

```text
*.csproj
*.sln
```

unless there is a specific reason.

---

# AI Development Instructions

This section is intended for **Codex, Claude, ChatGPT, or other coding agents working in this repository**.

## Core Rule

**Do not attempt to build the entire game.**

Work incrementally.

The current goal is to create a clean foundation for the next playable milestone.

---

## Before Making Changes

When given a substantial task:

1. Inspect the repository.
2. Understand the existing architecture.
3. Identify the smallest coherent implementation.
4. Reuse existing systems where appropriate.
5. Avoid creating duplicate abstractions.
6. Briefly state the intended approach before large changes.

---

## When Writing Code

Agents should:

- Produce production-quality C#.
- Keep code understandable to a developer learning Unity.
- Prefer explicit architecture over hidden magic.
- Keep systems independently testable where reasonable.
- Keep Unity-specific dependencies close to Unity-facing code.
- Avoid unnecessary third-party dependencies.
- Avoid adding packages unless they clearly solve a current requirement.
- Avoid giant manager classes.
- Avoid singleton-heavy architectures.
- Avoid implementing future systems that were not requested.

---

## IMPORTANT: Do Not Hand-Author Fragile Unity Assets Without Need

Do **not** casually generate or heavily modify:

```text
*.unity
*.prefab
*.asset
*.meta
```

as raw YAML unless explicitly requested and there is a strong reason.

Unity-generated assets can be fragile when created outside the Editor.

Prefer providing:

- C# scripts
- folder structure
- configuration guidance
- Editor-safe setup instructions

If a scene or prefab must be created manually in Unity, document the required hierarchy/components clearly.

Editor scripts may be created when automation is useful and maintainable.

---

## Do Not Assume Code Works Because It Compiles

Gameplay changes require Unity testing.

If working from a machine without Unity installed:

- make code changes conservatively;
- note what must be validated inside Unity;
- do not claim gameplay behavior has been verified;
- avoid large untestable changes.

---

## Explain Important Architecture

This project is also being used to **learn game development**.

When introducing an important pattern, briefly explain why it exists.

Examples:

- State machines
- Input buffering
- Coyote time
- Hitbox / hurtbox separation
- ScriptableObject configuration
- Physics update timing

Do not bury all architectural decisions inside generated code.

---

# Current Agent Task: Initial Scaffolding

If this repository has just been initialized, the first coding agent should **inspect the repo first**, then scaffold only what is safe and useful.

Recommended initial work:

1. Confirm this is a Unity 6 project.
2. Confirm URP / 2D Renderer setup if already initialized.
3. Ensure `.gitignore` is appropriate for Unity.
4. Create the high-level project folders if they do not exist.
5. Establish namespaces if useful.
6. Create the minimal input layer architecture.
7. Create initial player movement component skeletons.
8. Create a lightweight player state-machine foundation only if movement implementation requires it.
9. Add configuration structures for movement tuning.
10. Document any Unity Editor setup still required.

Do **not** yet implement:

- finished combat
- enemy AI
- inventories
- quests
- save systems
- dialogue
- procedural generation
- final art
- final UI

---

# First Concrete Milestone

The next real milestone is:

## Player Movement v0.1

A placeholder player in `CombatSandbox` should be able to:

- Move left and right
- Accelerate and decelerate smoothly
- Jump
- Fall
- Use coyote time
- Use jump buffering
- Dash
- Respect the ground and walls

The implementation should expose tuning values so gameplay can be adjusted quickly.

The target is not realism.

The target is **responsive controls**.

---

# Definition of Done — Player Movement v0.1

The milestone is complete when:

- [ ] Project opens without Unity console errors.
- [ ] Input System actions are correctly wired.
- [ ] Player can move left and right.
- [ ] Player accelerates and decelerates predictably.
- [ ] Player can jump only under intended conditions.
- [ ] Coyote time works.
- [ ] Jump buffering works.
- [ ] Player transitions naturally into falling.
- [ ] Dash works.
- [ ] Dash has configurable speed/distance/duration.
- [ ] Dash cannot be spammed unintentionally.
- [ ] Movement parameters are easily tunable.
- [ ] Code architecture is understandable.
- [ ] No final art is required.
- [ ] `main` remains free of broken generated files.

---

# Non-Goals for v0.1

Do not implement these unless explicitly requested:

- Wall running
- Wall jumping
- Double jump
- Grappling hook
- Stamina
- Inventory
- Skill trees
- Character progression
- Equipment
- Dialogue
- NPCs
- Bosses
- Multiple weapons
- Save/load
- Settings menus

---

# Development Philosophy

The project should evolve through this loop:

```text
Implement a small mechanic
        ↓
Play it
        ↓
Tune it
        ↓
Understand why it works or fails
        ↓
Refactor only when needed
        ↓
Add the next mechanic
```

Not:

```text
Design every future system
        ↓
Generate thousands of lines of code
        ↓
Try to assemble a game afterward
```

---

# Long-Term Direction

If the core combat prototype succeeds, the project may eventually explore:

- Hand-authored pixel animation
- Advanced 2D lighting
- Hybrid 2D / 3D environments
- Cinematic camera systems
- Boss encounters
- Environmental storytelling
- More sophisticated enemy behavior
- AI-assisted development tooling
- Carefully scoped language-model experiments for selected non-combat NPC behavior

These are future possibilities, not current requirements.

---

# Guiding Question

Whenever adding a new system, ask:

> Does this make the current playable prototype more fun, more understandable, or easier to iterate on?

If the answer is no, it probably does not belong in the project yet.
