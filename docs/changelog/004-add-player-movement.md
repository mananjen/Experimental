# 004: Add player movement

## Purpose

Add simple left-right player movement for the movement prototype.

## Changes and reasons

- Added `PlayerMovement` to read A/D and left/right arrow input through Unity's
  Input System.
- Applied the configured horizontal movement speed to the player's
  `Rigidbody2D` while preserving vertical velocity for physics-based movement.
- Exposed `moveSpeed` in the Inspector so movement can be tuned during
  prototyping.

## Files changed

- `game/Assets/_Projects/Scripts/Player/PlayerMovement.cs` — added the simple
  left-right movement implementation
- `docs/changelog/004-add-player-movement.md` — created as this development
  record

## Verification

- Reviewed the script to confirm it uses the Input System and updates physics
  velocity in `FixedUpdate`.
- Unity Play Mode validation remains: confirm keyboard movement works on the
  player and that the Console reports no errors.
