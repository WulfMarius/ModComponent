using UnityEngine;

namespace ModComponentAPI
{
    public class ModFirstAidComponent : ModComponent
    {
        [Header("First Aid")]

        [Tooltip("Does affect like Antibiotics?")]
        public bool ProvidesAntibiotics;

        [Tooltip("Does affect like Painkiller?")]
        public bool KillsPain;

        [Tooltip("Does affect like Bandage?")]
        public bool AppliesBandage;

        [Tooltip("Does it clean wounds?")]
        public bool CleansWounds;

        [Tooltip("Time to use in-game seconds")]
        public float TimeToUseSeconds;

        [Tooltip("Use audio")]
        public string UseAudio;

        [Tooltip("unis per use")]
        public int UnitsPerUse;

        [HideInInspector]
        [Tooltip("Immediately HP retore. Unused")]
        public float HPIncrease;

        [HideInInspector]
        [Tooltip("Unesed at this moment")]
        public bool AppliesSutures;

        [HideInInspector]
        [Tooltip("Does affect like ... i don't like what. Unused ")]
        public bool StabalizesSprains;
        
    }

}
