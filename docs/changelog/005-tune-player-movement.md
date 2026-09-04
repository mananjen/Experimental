# 005: Tune player movement

## Purpose

Make the prototype player's horizontal movement feel smoother and prepare the
combat sandbox for physics tuning.

## Changes and reasons

- Replaced the single movement-speed field with configurable maximum speed,
  acceleration, and deceleration values.
- Applied `Mathf.MoveTowards` in `FixedUpdate` so the player's horizontal
  velocity ramps up and comes to a controlled stop while preserving vertical
  physics.
- Added the movement component to the sandbox player with a maximum speed of
  5.
- Added the `trial` 2D physics material with friction 0.4 and no bounciness for
  continued collision tuning.

## Files changed

- `game/Assets/_Projects/Scripts/Player/PlayerMovement.cs` — added smooth
  horizontal acceleration and deceleration
- `game/Assets/Scenes/CombatSandbox.unity` — configured `PlayerMovement` on the
  sandbox player
- `game/Assets/_Projects/Scripts/Player/trial.physicsMaterial2D` — added the
  prototype physics material
- `game/Assets/_Projects/Scripts/Player/trial.physicsMaterial2D.meta` — added
  Unity asset metadata
- `docs/changelog/005-tune-player-movement.md` — created as this development
  record

## Verification

- Reviewed the staged patch to confirm the movement rate is applied in
  `FixedUpdate` and vertical velocity is preserved.
- Confirmed the sandbox scene serializes `PlayerMovement` with `moveSpeed`'s
  replacement value of 5 through the current `maxMoveSpeed` field.
- Unity Play Mode validation remains: confirm acceleration, stopping, and
  collision behavior in the `CombatSandbox` scene and check the Console for
  errors.