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
        QUARTER
    }

    public class ModScentComponent: MonoBehaviour
    {
        [Tooltip("How scent this item. Scentrangecategory affect on wildlife detectione range")]
        public ScentCategory scentRangeCategory = ScentCategory.RAW_MEAT;

    }
}
