using UnityEngine;

namespace ModComponentAPI
{
    public class ModFirstAidComponent : ModComponent
    {
        [Header ("First Aid")]
        [Tooltip("Immediately HP retore")]
        public float HPIncrease;
        [Tooltip("Does affect like Antibiotics?")]
        public bool ProvidesAntibiotics;
        [Tooltip("Does affect like Painkiller?")]
        public bool KillsPain;
        [Tooltip("Does affect like Bandage?")]
        public bool AppliesBandage;
        [Tooltip("Does affect like Bandage?")]
        public bool AppliesSutures;
        [Tooltip("Does affect like Bandage?")]
        public bool StabalizesSprains;
        [Tooltip("Does it clean wounds?")]
        public bool CleansWounds;
        [Tooltip("Time to use in-game seconds")]
        public float TimeToUseSeconds;
        [Tooltip("Use audio")]
        public string UseAudio;
        [Tooltip("unis per use")]
        public int UnitsPerUse;
    }

}
