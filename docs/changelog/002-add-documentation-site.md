# 002: Add documentation website

## Purpose

Publish the Markdown documentation as a small, automatically updated website
without turning documentation maintenance into a substantial parallel project.

## Changes and reasons

- Added a minimal MkDocs configuration using its built-in theme to avoid custom
  frontend code and unnecessary maintenance.
- Added a pinned documentation dependency so local and automated builds use the
  same MkDocs version.
- Added a documentation home page that directs readers to the design, changelog,
  and repository setup information.
- Added a GitHub Pages workflow that builds and deploys documentation after
  relevant changes reach `main`.
- Configured the Python action to use `requirements-docs.txt` as its pip cache
  dependency file. The non-default filename must be provided explicitly or the
  workflow fails during Python setup before MkDocs can run.
- Linked the published site from the repository README.
- Ignored generated site output so compiled HTML is never committed.

## Files changed

- `.gitignore` — updated to ignore generated documentation output
- `README.md` — updated with the documentation website link
- `docs/index.md` — created as the documentation website home page
- `mkdocs.yml` — created with the site metadata and built-in theme
- `requirements-docs.txt` — created with the pinned MkDocs dependency
- `.github/workflows/docs.yml` — created to build and deploy GitHub Pages
- `docs/changelog/002-add-documentation-site.md` — created as this record

## Verification

- Confirmed the workflow uses GitHub's supported Pages artifact and deployment
  actions.
- Confirmed the workflow runs for documentation configuration and content
  changes on `main`, and can also be started manually.
- Confirmed a local strict MkDocs build completes successfully.
- Confirmed the workflow's pip cache points to the repository's actual
  documentation dependency file.
- GitHub Pages must be configured to use **GitHub Actions** as its publishing
  source before the first deployment.
