using HarmonyLib;
using Il2Cpp;
using Il2CppInterop.Runtime.Injection;
using Il2CppTLD.Gear;
using Il2CppTLD.IntBackedUnit;
using MelonLoader;

namespace WeightTweaks
{
    [HarmonyPatch(typeof(GearItem), nameof(GearItem.GetItemWeightKG), new Type[] { typeof(bool) })]
    internal class GearItem_GetItemWeightKG
    {
        private static void Postfix(GearItem __instance, ref ItemWeight __result)
        {
            float retour = WeightTweaks.ModifyWeight(__instance, __result.ToQuantity(1));

            __result = ItemWeight.FromKilograms(retour);
        }
    }

    [HarmonyPatch(typeof(GearItem), nameof(GearItem.GetItemWeightKG), new Type[] { typeof(float), typeof(bool) })]
    internal class GearItem_GetItemWeightKG_Stack
    {
        private static void Postfix(GearItem __instance, ref ItemWeight __result)
        {
            float retour = WeightTweaks.ModifyWeight(__instance, __result.ToQuantity(1));

            __result = ItemWeight.FromKilograms(retour);
        }
    }

    [HarmonyPatch(typeof(PlayerManager), nameof(PlayerManager.UpdateCarryingBuff))]
    internal class PlayerManager_UpdateCarryingBuff
    {
        private static void Prefix(PlayerManager __instance)
        {
            GameManager.GetPlayerManagerComponent().m_ClothingWeightWhenWornModifier = Settings.options.clothingWornWeightMod;
        }
    }
}
