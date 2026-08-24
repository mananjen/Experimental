# 001: Initial scaffolding

## Purpose

Establish the initial repository and Unity project foundation before the first
project-development commit. This entry intentionally groups all current
scaffolding into one chunk.

## Changes and reasons

- Established `game/` as the Unity project root so Unity files remain isolated
  from future backend code and repository-level documentation.
- Reserved `backend/` for possible backend and language-model experiments.
- Added Unity-aware ignore rules scoped to `game/` so generated caches, builds,
  IDE files, and personal settings are not committed.
- Reworked the root README into a concise project introduction and setup guide.
- Moved the detailed vision, scope, roadmap, and architecture direction into
  `docs/DESIGN.md` so the README remains approachable.
- Added `AGENTS.md` for repository-specific implementation, review, Git, Unity
  asset safety, and verification guidance.
- Adopted small, reviewable work chunks while reserving all commits for the
  user.
- Chose lightweight, risk-based verification appropriate for a personal
  prototype, with stronger testing deferred until the project's scope or stakes
  increase.

## Files changed

- `.gitignore` — created for the monorepo and Unity project layout
- `README.md` — updated with the current layout and concise onboarding content
- `AGENTS.md` — created with contributor and coding-agent instructions
- `docs/DESIGN.md` — created with design and development direction
- `docs/changelog/001-initial-scaffolding.md` — created as this record
- `backend/.gitkeep` — created to retain the reserved backend directory
- `game/.vsconfig` — generated Unity/Visual Studio setup configuration
- `game/Assets/` — Unity-created starter assets and associated metadata
- `game/Packages/` — Unity package manifest and lock file
- `game/ProjectSettings/` — Unity-created project configuration

Generated and ignored Unity caches and IDE files are deliberately excluded from
this list because they are not part of the commit.

## Verification

- Confirmed `game/` contains `Assets`, `Packages`, and `ProjectSettings`, making
  it a valid Unity project root.
- Confirmed Unity-generated caches and IDE project files are ignored.
- Confirmed source assets, `.meta` files, package manifests, project settings,
  documentation, and `.vsconfig` remain trackable.
- Confirmed README documentation links resolve.
- No gameplay code was added, so gameplay testing is not required for this
  scaffolding chunk.
