# UI / DPI Guide

## Working rules

- Always open and edit WinForms UI on Windows Display Scale `100%` (`96 DPI`).
- Restart Visual Studio after changing Windows scale before touching any `.Designer.cs`.
- Only one developer should edit the same Form/UserControl at a time.
- Keep UI/layout changes in a separate commit from business/data changes.
- Prefer `Dock`, `Anchor`, `TableLayoutPanel`, `FlowLayoutPanel`, `SplitContainer`, `AutoScroll`, and `MinimumSize`.
- Avoid adding new hard-coded `Location` / `Size` unless there is no layout-container alternative.
- Do not change `Dispose()`, resource loading, or event-handler signatures inside designer files.

## Vietnamese text rules

- Prefer `Segoe UI` or another common Windows font with Vietnamese support.
- Set the font at the Form/container level when possible instead of overriding every child control.
- Use `AutoSize = true` for short labels, or increase container width/height when labels must align in a grid.
- Keep buttons at least tall enough for Vietnamese accents at `100%`, `125%`, and `150%` scale.
- For `DataGridView`, use `AutoSizeColumnsMode` or explicit column widths when Vietnamese headers are clipped.
- Do not shorten Vietnamese labels just to fit a broken layout; fix the layout container first.

## Current DPI policy

- App DPI mode is explicitly set to `SystemAware`.
- Do not enable `PerMonitorV2` until the main forms are stable and multi-monitor testing is done.
- Keep DPI configuration in one place only.
  Current source of truth: [Trung-tam-quan-ly-ngoai-ngu.csproj](/D:/Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu/Trung-tam-quan-ly-ngoai-ngu.csproj)

## Manual test checklist

1. Open the app at `100%`, `125%`, and `150%` Windows scale.
2. Test login form, account management, and common dialogs first.
3. Resize each main shell form and each module form.
4. Confirm no control overlap, clipped text, or hidden panel edges.
5. Open edited forms in Visual Studio Designer at `100%` scale.
6. Verify split containers, flow panels, and table layouts still reflow correctly.

## Rollback to SystemAware

Use this checklist if a future DPI experiment breaks layout:

1. Remove any `PerMonitorV2` setting from `Program.cs`, manifest, app config, or csproj.
2. Keep only one DPI setting and set it back to `SystemAware`.
3. Rebuild the solution.
4. Re-test at `100%`, `125%`, and `150%`.
5. Re-open edited forms in Designer to confirm design-time stability.
