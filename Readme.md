# Ragdoll Tweaks

![Preview screenshot](https://github.com/jialiang/RT-Ragdoll/blob/master/preview.png?raw=true)

Allow physics parameters to be configured for the game Warhammer 40,000: Rogue Trader.

This mod was created to fix the issue of enemy ragdolls jittering when they die.

Default values of this mod mainly follow what Owlcat set for their next game Dark Heresy:

| Property                   | Rogue Trader     | Dark Heresy      | This mod      |
| -------------------------- | ---------------- | ---------------- | ------------- |
| `solverIterations`         | 0                | 6                | 6             |
| `solverVelocityIterations` | 0                | 1                | 1             |
| `maxAngularVelocity`       | 0f               | 7f               | 7f            |
| `interpolation`            | not set (`None`) | not set (`None`) | `Interpolate` |

## Installation

0. Run the game at least once.
1. Download and install [Unity Mod Manager](https://www.nexusmods.com/site/mods/21) (0.25.0 or newer).
2. Build using `dotnet build -c Release`. Requires .NET SDK 8.0 or newer.

If installing a prebuilt copy, make sure `RagdollTweaks.dll` and `Info.json` are at

```
%USERPROFILE%\AppData\LocalLow\Owlcat Games\Warhammer 40000 Rogue Trader\UnityModManager\RagdollTweaks
```

Changes apply to the next enemy that dies, so there is no need to restart the
game or reload a save after moving a slider.

## Formatting

To format all `.cs` and `.csproj` files in the repo, run `dotnet csharpier format .`.
