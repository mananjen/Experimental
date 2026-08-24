# Design and Development Roadmap

## Vision

Experimental aims to become a short, highly polished 2D/2.5D pixel-art action
game built around responsive movement and a fluid hybrid of melee and ranged
combat.

The visual ambition is inspired by modern cinematic pixel-art games such as
*REPLACED*, while the production scope remains that of a small, systems-first
indie project. The goal is not to reproduce large-studio production values.

The guiding question for every addition is:

> Does this make the current playable prototype more fun, more understandable,
> or easier to iterate on?

If it does not, it probably does not belong in the project yet.

## Design pillars

### Game feel before feature count

Movement and combat must feel good before they look finished. Placeholder art,
simple shapes, and incomplete presentation are expected during prototyping.
Finished sprites, animations, VFX, audio, environments, and narrative must not
block gameplay iteration.

A short, polished experience is preferable to a large unfinished game.

### Complementary melee and ranged combat

The eventual combat loop should make transitions between close-range and
ranged attacks feel natural. Possible sequences include:

- Slash → slash → gunshot
- Launcher → shoot an airborne enemy
- Dodge → counterattack
- Parry → punish
- Melee stagger → ranged follow-up

These are directional examples, not requirements for the initial prototype.

### Strong, configurable feedback

Combat should eventually support independently tunable feedback such as:

- Hit-stop and animation timing
- Camera shake and other camera feedback
- Enemy recoil, stagger, and knockback
- Impact VFX, weapon trails, and muzzle flashes
- Screen effects and sound cues

### Deliberately small scope

Do not prematurely add open worlds, procedural generation, crafting, dialogue,
skill trees, large inventories, networking, multiplayer, live services, quest
systems, complex UI frameworks, or elaborate save systems.

The project must first prove that movement and combat are fun.

## Presentation direction

The first prototypes use 2D gameplay and the Universal Render Pipeline's 2D
Renderer. Later presentation may explore:

- Pixel-art characters and hand-authored animation
- 2D lights and normal-mapped sprites
- Bloom, fog, post-processing, and shader effects
- Parallax and cinematic camera systems
- 3D environmental geometry behind 2D gameplay
- Small, highly polished environments with a strong atmosphere

None of these are prerequisites for the first playable milestone.

## Combat Sandbox v0.1

The first playable target is one small test room in which the player can:

1. Move, jump, fall, and dash.
2. Perform a basic melee attack.
3. Fire a basic ranged weapon.
4. Damage a simple enemy.
5. Receive clear feedback when an attack lands.

No final art is required.

## Development phases

### Phase 0: Project scaffolding

- Establish useful folders and conventions.
- Confirm the Input System and Unity 2D Renderer configuration.
- Introduce assembly boundaries only when justified.
- Establish a minimal input layer and focused player components.
- Create a placeholder `CombatSandbox` scene when needed.

Do not over-engineer the foundation.

### Phase 1: Movement

- Horizontal movement with acceleration and deceleration
- Jumping, falling, and reliable ground detection
- Coyote time and jump buffering
- Dash behavior and cooldown
- Inspector-accessible movement tuning

### Phase 2: Melee combat

- Attack input and attack states
- Hitboxes and hurtboxes
- Damage, knockback, hit-stop, and basic enemy reaction
- Basic combo support after a single attack works well

### Phase 3: Ranged combat

- A basic firearm with a configurable fire rate
- A projectile or hitscan abstraction
- Damage and hooks for muzzle effects and recoil
- Ammunition only if it improves the game

Avoid complicated weapon inventories at this stage.

### Phase 4: Enemy prototype

Create one deterministic enemy that can idle, detect and approach the player,
attack, receive damage, stagger, and die. Language models and agent systems do
not belong in core combat AI during this phase.

### Phase 5: Polish

After the core loop feels good, add real animation, pixel art, weapon and impact
effects, camera tuning, lighting, audio, environment art, and post-processing.

## System direction

These guidelines describe likely solutions, not abstractions that must be
created in advance.

### Player composition

Prefer focused components over one controller that owns every system. A future
player may be composed from components such as:

```text
Player
├── PlayerInputReader
├── PlayerMotor
├── PlayerStateMachine
├── PlayerCombat
├── PlayerHealth
└── Rigidbody2D
```

Exact names may evolve with the implementation.

### State management

A lightweight finite state machine may become useful as player behavior grows.
Likely concepts include grounded, airborne, dash, hurt, and dead states, with
idle, run, jump, fall, and attack behavior beneath them.

Create only states required by current behavior. Avoid deeply coupled state
classes and speculative transitions.

### Input

Gameplay systems consume semantic actions such as `Move`, `JumpPressed`,
`DashPressed`, `AttackPressed`, and `FirePressed`. They should not query physical
keyboard keys directly.

This keeps gameplay logic independent of control bindings and supports future
controller input.

### Tunable gameplay values

Frequently adjusted values should be serialized rather than scattered as magic
numbers. Examples include speed, acceleration, jump force, coyote time, input
buffer durations, dash parameters, damage, knockback, and hit-stop duration.

Use ScriptableObjects when they clearly improve reuse or iteration. Do not build
an elaborate data framework before it is needed.

### Combat model

The combat model should eventually distinguish:

- **Hitbox:** an area capable of applying an attack.
- **Hurtbox:** an area capable of receiving an attack.
- **Attack data:** information such as damage, knockback, stun, hit-stop, hit
  direction, attack identity, and source.

The model should be capable of supporting melee attacks and projectiles without
forcing them into a large inheritance hierarchy.

## Player Movement v0.1 acceptance criteria

- [ ] The project opens without Unity console errors.
- [ ] Input System actions are wired correctly.
- [ ] The player moves left and right.
- [ ] Acceleration and deceleration are predictable.
- [ ] Jumping occurs only under intended conditions.
- [ ] Coyote time works.
- [ ] Jump buffering works.
- [ ] Falling transitions naturally.
- [ ] Dash works and cannot be spammed unintentionally.
- [ ] Dash speed, duration, and cooldown are configurable.
- [ ] Movement parameters are easy to tune.
- [ ] The code architecture remains understandable.
- [ ] No final art is required.
- [ ] The main branch contains no broken generated files.

Explicit non-goals include wall running, wall jumping, double jump, grappling,
stamina, inventories, character progression, equipment, dialogue, NPCs, bosses,
multiple weapons, save/load, and settings menus.

## Long-term possibilities

If the combat prototype succeeds, the project may explore boss encounters,
environmental storytelling, hybrid 2D/3D environments, more sophisticated
enemy behavior, AI-assisted development tools, and carefully scoped language-
model experiments for selected non-combat NPC behavior.

These are possibilities, not current commitments.
