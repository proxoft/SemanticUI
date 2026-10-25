# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

Fomantic UI wrappers for ASP.NET Core, shipped as NuGet packages under the `Proxoft.FomanticUI.*` namespace: Blazor components and Razor tag helpers that render Fomantic UI markup (CSS class composition), plus an assembly that serves the Fomantic UI CSS/JS/fonts as embedded resources.

## Commands

All .NET code lives under `Source/`; the solution is `Source/FomanticUI.slnx`. SDK is pinned in `Source/global.json` (10.0.103), target framework is `net10.0`.

```bash
dotnet build Source/FomanticUI.slnx
dotnet run --project Source/FomanticUI.Blazor.Sample        # Blazor Server demo of every component
dotnet run --project Source/FomanticUI.TagHelpers.Sample    # Razor Pages demo of the tag helpers
```

- There is no test project yet (`Directory.Build.props` already declares `InternalsVisibleTo` for `*.Tests` / `Proxoft.FomanticUI.Tests`).
- `TreatWarningsAsErrors` is on for all projects — new warnings break the build.
- Library projects have `GeneratePackageOnBuild=true` and write output **outside the repo** to `../../../Builds/<Project>/<Configuration>` (relative to each project folder). Each library has its own `<Version>` in its csproj; bump it when changing a package.
- Package versions are managed centrally in `Source/Directory.Packages.props` (`PackageReference` entries in csproj files have no version).

## Architecture

Four library projects, layered:

- **FomanticUI.Core** — UI-framework-agnostic model: enums (`Color`, `Size`, `Position`, …) and `[Flags]` `*Decorations` enums, each with a `ToClass()` extension that maps the value to Fomantic UI CSS class names. `ClassTools` provides the helpers (`ToClass`, `ToClassIf`, `SetAsAttribute`) used everywhere to build class strings. All CSS-class knowledge belongs here so both front-ends share it.
- **FomanticUI.Blazor** — Razor components. Every component derives from `FomanticComponent` (or `ContainerFomanticComponent`, which adds `ChildContent`). The base builds the final class as `ui` + `Classes()` + `CssName` + `AfterCssNameClasses()` + user `CssClass`; subclasses override `Classes()` / `AfterCssNameClasses()` / `InitializeAttributes()` and typically render via `_Templates/DivTemplate.razor` (`<DivTemplate Component="this" />`). Unmatched attributes, `Tooltip`, `Title` and `OnClick` are handled by the base. `_Imports.razor` adds `using static` for common Core enums so consumers can write e.g. `Color="Red"`. Use `_Templates/AnchorTemplate.razor` for parts that render as `<a>` when given an `Href`. Components that only sometimes take the `ui` prefix (e.g. `ItemImage`, nested `Comments`) set `PrefixUiClass` in `OnParametersSet`. Don't name a component `Text`: Razor reads `<Text>` inside code blocks as its reserved `<text>` tag, which is why the Fomantic text element is `StyledText`.
- `[Parameter]` properties must be plain auto properties that the component never writes to (analyzer BL0007 is enforced via `TreatWarningsAsErrors`). Components that take both a settings record (`IconData`, `MessageData`, `*ButtonData`, `Tooltip`) and individual parameters declare the individual ones nullable and merge them over the record in `OnParametersSet` (`data with { Name = this.Name ?? data.Name, ... }`), so overrides win regardless of attribute order and shared records are never mutated. Tag helpers keep non-nullable properties (so `color="Red"` binds as an enum) and use `FomanticTagHelper.IsSet(context, nameof(Prop))` to tell whether an attribute was written.
- The project's scope is CSS-only Fomantic components with no JS interop (important for Blazor WebAssembly). Fomantic modules whose JS only computes markup are reimplemented in C#: `Calendar` and `Progress` keep their date/percent logic in Core (`CalendarPage`, `ProgressState`) and only render in Blazor. Modules that need real DOM measurement (dropdown, popup positioning, …) are not wrapped.
- **FomanticUI.TagHelpers** — the same component set as tag helpers (`<fui-label>`, `<fui-button>`, …). Base class `FomanticTagHelper(cssName, tagName, prefixUi)` uses the same class-composition order and overrides `Classes()`. Folder layout mirrors FomanticUI.Blazor.
- **FomanticUI.Resources** — Fomantic UI dist files (currently 2.9.4) under `fomantic/` embedded via `ManifestEmbeddedFileProvider`, exposed by `app.UseFomanticUiResources("/some-path")` (namespace `Microsoft.AspNetCore.Builder`). The page then links `/some-path/semantic.min.css`. Everything under `fomantic/` is embedded by a glob in the csproj; Fomantic keeps the upstream `semantic.*` file names. Flag and emoji icons in Fomantic CSS load SVGs from the jsDelivr CDN rather than from embedded assets.

When adding or changing a component, the usual touch points are: the decoration enum + `ToClass()` in Core, the Blazor component, the matching tag helper, and an example page in each sample app (Blazor sample: `Pages/<Category>/*View.razor` + `Shared/Sidebar.razor`; TagHelpers sample: `Pages/<Category>/*.cshtml` + `Pages/Shared/_SidebarPartial.cshtml`).
