﻿using Harmony;
using ModComponentAPI;
using UnityEngine;

using static PlayerAnimation;

namespace ModComponentMapper
{
    [HarmonyPatch(typeof(PlayerManager), "PutOnClothingItem")]
    internal class PlayerManager_PutOnClothingItem
    {
        internal static void Postfix(GearItem gi)
        {
            ModClothingComponent modClothingComponent = ModUtils.GetComponent<ModClothingComponent>(gi);
            modClothingComponent?.OnPutOn?.Invoke();
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "RestoreOriginalTint")]
    internal class PlayerManager_RestoreOriginalTint
    {
        internal static void Postfix(PlayerManager __instance, GameObject go)
        {
            Object.Destroy(go.GetComponent<RestoreMaterialQueue>());
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "StoreOriginalTint")]
    internal class PlayerManager_StoreOriginalTint
    {
        internal static void Prefix(PlayerManager __instance, GameObject go)
        {
            go.AddComponent<RestoreMaterialQueue>();
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "TakeOffClothingItem")]
    internal class PlayerManager_TakeOffClothingItem
    {
        internal static void Postfix(GearItem gi)
        {
            ModClothingComponent modClothingComponent = ModUtils.GetComponent<ModClothingComponent>(gi);
            modClothingComponent?.OnTakeOff?.Invoke();
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "UnequipItemInHandsInternal")]
    internal class PlayerManager_UnequipItemInHandsInternalPatch
    {
        internal static void Postfix(PlayerManager __instance)
        {
            GearEquipper.Unequip(ModUtils.GetEquippableModComponent(__instance.m_ItemInHands));
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "UnequipItemInHandsSkipAnimation")]
    internal class PlayerManager_UnequipItemInHandsSkipAnimation
    {
        internal static void Prefix(PlayerManager __instance)
        {
            GearEquipper.OnUnequipped(ModUtils.GetEquippableModComponent(__instance.m_ItemInHands));
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "EquipItem")]
    internal class PlayerManagerEquipItemPatch
    {
        internal static void Prefix(PlayerManager __instance, GearItem gi)
        {
            EquippableModComponent equippable = ModUtils.GetEquippableModComponent(__instance.m_ItemInHands);
            if (equippable != null)
            {
                __instance.UnequipItemInHands();
            }
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "OnEquipItemBegin")]
    internal class PlayerManagerOnEquipItemBeginPatch
    {
        internal static void Postfix(PlayerManager __instance)
        {
            GearEquipper.Equip(ModUtils.GetEquippableModComponent(__instance.m_ItemInHands));
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "SetControlMode")]
    internal class PlayerManagerSetControlModePatch
    {
        private static PlayerControlMode lastMode;

        internal static void Postfix(PlayerManager __instance, PlayerControlMode mode)
        {
            if (mode == lastMode)
            {
                return;
            }

            lastMode = mode;

            EquippableModComponent equippable = ModUtils.GetEquippableModComponent(__instance.m_ItemInHands);
            if (equippable != null)
            {
                equippable.OnControlModeChangedWhileEquipped?.Invoke();
            }
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "UseInventoryItem")]
    internal class PlayerManagerUseInventoryItemPatch
    {
        internal static bool Prefix(PlayerManager __instance, GearItem gi)
        {
            if (ModUtils.GetComponent<FirstPersonItem>(gi) != null)
            {
                return true;
            }

            if (ModUtils.GetEquippableModComponent(gi) == null)
            {
                return true;
            }

            var currentGi = __instance.m_ItemInHands;
            if (currentGi != null)
            {
                __instance.UnequipItemInHands();
            }

            if (gi != currentGi)
            {
                __instance.EquipItem(gi, false);
            }

            return false;
        }
    }

    [HarmonyPatch(typeof(PlayerManager), "InteractiveObjectsProcessAltFire")]
    internal class PlayerManager_InteractiveObjectsProcessAltFire
    {
        internal static bool Prefix(PlayerManager __instance)
        {
            AlternativeAction alternativeAction = ModUtils.GetComponent<AlternativeAction>(__instance.m_InteractiveObjectUnderCrosshair);
            if (alternativeAction == null)
            {
                return true;
            }

            alternativeAction.Execute();
            return false;
        }
    }
}