using UnityEngine;

namespace ModComponentAPI
{
    public enum ScentCategory
    {
        RAW_MEAT,
        RAW_FISH,
        COOKED_MEAT,
        COOKED_FISH,
        GUTS,
        QUARTER,
    }

    public class ModScentComponent: MonoBehaviour
    {
        [Tooltip("How scent this item. Scentrangecategory affect on wildlife detectione range")]
        public ScentCategory scentRangeCategory = ScentCategory.RAW_MEAT;

        public float GetScentIntensity()
        {
            switch (this.scentRangeCategory)
            {
                case ScentCategory.RAW_MEAT:
                    return 15f;
                case ScentCategory.RAW_FISH:
                    return 10f;
                case ScentCategory.COOKED_MEAT:
                    return 5f;
                case ScentCategory.COOKED_FISH:
                    return 5f;
                case ScentCategory.GUTS:
                    return 20f;
                case ScentCategory.QUARTER:
                    return 50f;
                default:
                    Debug.Log("Unknown scent range cateogry: " + this.scentRangeCategory.ToString());
                    return 0f;
            }
        }

    }
}
