# 003: Create combat sandbox

## Purpose

Create the first playable Unity test space for developing and tuning player
movement.

## Changes and reasons

- Added the `CombatSandbox` scene as the dedicated gameplay prototyping area.
- Added placeholder player and ground sprites so movement can be developed and
  tested without depending on final art.
- Configured 2D colliders on the player and ground, plus a dynamic
  `Rigidbody2D` on the player, to establish the minimum physics interaction
  needed for movement work.
- Installed Unity's 2D feature set to provide the standard tools used by the
  prototype scene.
- Retained Unity's generated scene-template settings and automatic
  `SampleScene` serialization updates so the project remains consistent with
  the current Editor version.

## Files changed

- `game/Assets/Scenes/CombatSandbox.unity` — created with the placeholder
  player, ground, camera, and light
- `game/Assets/Scenes/CombatSandbox.unity.meta` — created by Unity for the new
  scene asset
- `game/Assets/Scenes/SampleScene.unity` — updated automatically by the Unity
  Editor without retaining the prototype objects
- `game/Packages/manifest.json` — added Unity's 2D feature package
- `game/Packages/packages-lock.json` — recorded the resolved 2D package
  dependencies
- `game/ProjectSettings/SceneTemplateSettings.json` — generated Unity scene
  template configuration
- `docs/changelog/003-create-combat-sandbox.md` — created as this development
  record

## Verification

- Confirmed the serialized `CombatSandbox` scene contains `Player` and `Ground`
  GameObjects with `BoxCollider2D` components.
- Confirmed the player has a dynamic `Rigidbody2D` with gravity, interpolation,
  continuous collision detection, and frozen Z rotation configured.
- Confirmed the placeholder objects are no longer present in `SampleScene`.
- Final Play Mode validation remains in Unity: confirm the player falls onto
  the ground and that the Console reports no errors.
