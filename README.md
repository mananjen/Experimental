# Experimental

Experimental is a long-term game-development project focused on a high-impact
2D/2.5D pixel-art action game with complementary melee and ranged combat.

The immediate goal is a small combat sandbox that feels excellent to control.
Final art, story, levels, and broader content come later.

## Project status

- **Phase:** Pre-production and technical scaffolding
- **Current milestone:** Player Movement v0.1
- **Engine:** Unity 6.3 LTS (`6000.3.22f1`)
- **Rendering:** Universal Render Pipeline with the Unity 2D Renderer
- **Initial platform:** Windows PC

## Repository structure

```text
Experimental/
├── game/                 # Unity project root
│   ├── Assets/
│   ├── Packages/
│   └── ProjectSettings/
├── backend/              # Reserved for future backend/LLM experiments
├── docs/
│   └── DESIGN.md         # Vision, scope, systems, and roadmap
├── AGENTS.md             # Instructions for coding agents
├── README.md
└── .gitignore
```

`game/` is intentionally the Unity project root rather than the repository
root. This keeps Unity-specific files isolated from future backend code and
project documentation.

## Opening the project

1. Install Unity Hub.
2. Install Unity Editor `6000.3.22f1`, or a compatible Unity 6.3 LTS release.
3. In Unity Hub, choose **Add > Add project from disk**.
4. Select the `game/` directory, not the repository root.
5. Allow Unity to restore packages and generate its local cache.

The generated `Library`, `Temp`, `Logs`, `UserSettings`, solution, and C#
project files are intentionally excluded from Git.

## Current milestone: Player Movement v0.1

A placeholder player in a `CombatSandbox` scene should be able to:

- Move left and right with configurable acceleration and deceleration
- Jump and fall
- Use coyote time and jump buffering
- Dash with configurable speed, duration, and cooldown
- Respect the ground and walls

The target is responsive control, not realism. No final art is required.

## Initial controls

| Action | Keyboard and mouse |
|---|---|
| Move | A / D |
| Jump | Space |
| Dash | Left Shift |
| Primary melee | Left Mouse Button |
| Fire weapon | Right Mouse Button |

The project uses Unity's Input System package. Controller support may be added
later.

## Documentation

- [Design and roadmap](docs/DESIGN.md)
- [Contributor and coding-agent instructions](AGENTS.md)

## Development principle

Build one small mechanic, play it, tune it, understand it, and refactor only
when needed. Game feel takes priority over feature count.
