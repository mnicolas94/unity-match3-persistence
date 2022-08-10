using Match3.Core.SerializableDictionaries;
using UnityEngine;
using Utils;

namespace BoardCores.Settings
{
    [CreateAssetMenu(fileName = "SkillsDefaultCountSettings", menuName = "Match3/Settings/SkillsDefaultCountSettings")]
    public class SkillsDefaultCountSettings : ScriptableObjectSingleton<SkillsDefaultCountSettings>
    {
        [SerializeField] private SkillCountDictionary _defaultSkillsCount;

        public static SkillCountDictionary GetDefaultCountsCopy()
        {
            var copy = new SkillCountDictionary();
            if (Instance != null)
                copy.CopyFrom(Instance._defaultSkillsCount);
            return copy;
        }
    }
}