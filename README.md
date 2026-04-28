# Calculator Pro

Modern Windows Forms calculator built with .NET 8 and C#.

## Highlights

- Borderless premium UI with a dark gradient shell
- Large high-contrast display with automatic font scaling
- Core calculator actions: add, subtract, multiply, divide
- Percent, sign toggle, backspace, and clear controls
- Smooth window dragging and rounded visual styling
- Full keyboard input support
- Division-by-zero error display with red highlighting

## Keyboard Shortcuts

| Key(s) | Action |
|--------|--------|
| `0` – `9`, numpad | Digit input |
| `.` | Decimal point |
| `+`, `-`, `*` / `Shift+8`, `/` | Arithmetic operators |
| `Enter` or `=` | Calculate result |
| `Escape` or `Delete` | Clear (C) |
| `Backspace` | Delete last digit |
| `Shift+5` (`%`) | Percent |

## Run

Open `CalculatorPro.sln` in Visual Studio 2022 or newer, or build from the command line:

```bash
dotnet build CalculatorPro.sln
```

## Deploy

### Self-contained single-file executable (Windows x64)

```bash
dotnet publish CalculatorPro/CalculatorPro.csproj \
  /p:PublishProfile=win-x64 \
  -c Release
```

The output is written to `publish/win-x64/CalculatorPro.exe` — a single portable executable that requires no .NET runtime installation on the target machine.

### Manual publish (any RID)

```bash
dotnet publish CalculatorPro/CalculatorPro.csproj \
  -c Release \
  -r win-x64 \
  --self-contained true \
  /p:PublishSingleFile=true \
  /p:IncludeNativeLibrariesForSelfExtract=true \
  -o publish/win-x64
```

## Notes

- Targets `net8.0-windows` — runs on Windows only.
- The app manifest enables **Per-Monitor DPI awareness** so it stays sharp on high-DPI displays.
