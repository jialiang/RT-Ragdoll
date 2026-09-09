using UnityModManagerNet;

namespace RagdollTweaks;

// Where these values come from: Readme.md.
internal static class Defaults
{
    public const bool IsSuggestedInterpolationEnabled = true;
    public const int SuggestedSolverIterations = 6;
    public const int SuggestedSolverVelocityIterations = 1;
    public const float SuggestedMaxAngularVelocity = 7f;
}

public class Settings : UnityModManager.ModSettings
{
    [Draw("Smooth motion between physics steps  (game off, suggested on)")]
    public bool IsInterpolationEnabled = Defaults.IsSuggestedInterpolationEnabled;

    [Draw("Joint solver iterations  (game 0, suggested 6)", DrawType.Slider, Min = 0, Max = 20)]
    public int SolverIterations = Defaults.SuggestedSolverIterations;

    [Draw("Velocity solver iterations  (game 0, suggested 1)", DrawType.Slider, Min = 0, Max = 10)]
    public int SolverVelocityIterations = Defaults.SuggestedSolverVelocityIterations;

    [Draw(
        "Max bone spin, rad/s  (game 0, suggested 7)",
        DrawType.Slider,
        Min = 0,
        Max = 30,
        Precision = 1
    )]
    public float MaxAngularVelocity = Defaults.SuggestedMaxAngularVelocity;

    public override void Save(UnityModManager.ModEntry modEntry) => Save(this, modEntry);
}
