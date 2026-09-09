using HarmonyLib;
using Kingmaker.Visual.CharactersRigidbody;
using UnityEngine;

namespace RagdollTweaks;

// The game writes these solver settings once, when the unit view is built,
// and never touches them again. It does move the bones on every ragdoll
// cycle, just never their solver configuration. Re-applying on each death
// means a settings change shows up on the next kill without reloading.
[HarmonyPatch(
    typeof(RigidbodyCreatureController),
    nameof(RigidbodyCreatureController.StartRagdoll)
)]
internal static class StartRagdollPatch
{
    private static void Postfix(RigidbodyCreatureController __instance)
    {
        if (!Main.IsEnabled)
        {
            return;
        }

        Settings settings = Main.Settings;

        // StartRagdoll appends the unit's weapons to RigidBones just before
        // this runs, so dropped guns get the same treatment as the skeleton.
        foreach (Rigidbody bone in __instance.RigidBones)
        {
            if (bone == null)
            {
                continue;
            }

            bone.interpolation = settings.IsInterpolationEnabled
                ? RigidbodyInterpolation.Interpolate
                : RigidbodyInterpolation.None;

            bone.solverIterations = settings.SolverIterations;
            bone.solverVelocityIterations = settings.SolverVelocityIterations;
            bone.maxAngularVelocity = settings.MaxAngularVelocity;
        }
    }
}
