using UnityEngine;

namespace ModComponentAPI
{
    public class ModEvolveComponent : MonoBehaviour
    {
        [Header("Evolve Item")]

        [Tooltip("Name of item to become. If This is a new item")]
        public GameObject GearItemToBecome;

        [Tooltip("In game gear item name to become. Start with GEAR_")]
        public string GearItemName;

        [Tooltip("Start evolve percent")]
        [Range(0f, 100f)]
        public int StartEvolvePercent;

        [Tooltip("Days to evolve to new item")]
        public float TimeToEvolveGameDays;

        [Tooltip("Evolve only indoors")]
        public bool RequireIndoors;

    }
}