using System.Linq;
using BoardCores.Settings;
using Match3.Core.GameActions;
using Match3.Core.SerializableDictionaries;
using SaveSystem;
using UnityEngine;
using Utils;

namespace Match3.Persistence
{
    [CreateAssetMenu(fileName = "SkillsCountPersistent", menuName = "Match3/Persistent/SkillsCountPersistent", order = 0)]
    public class SkillsCountPersistent : ScriptableObjectSingleton<SkillsCountPersistent>, IPersistent
    {
        [SerializeField] private SkillCountDictionary _skillsCount;

        public static int GetSkillCount(Skill skill)
        {
            var dict = Instance._skillsCount;
            return dict.ContainsKey(skill) ? dict[skill] : 0;
        }

        public static void AddSkillCount(Skill skill, int count = 1)
        {
            var dict = Instance._skillsCount;
            if (dict.ContainsKey(skill))
                dict[skill] += count;
            else
                dict.Add(skill, count);
            
            Instance.Save();
        }
        
        public static void AddAllSkillsCount(int count)
        {
            var dict = Instance._skillsCount;
            foreach (var skill in dict.Keys.ToList())
            {
                AddSkillCount(skill, count);
            }
        }

        public static bool ConsumeSkill(Skill skill)
        {
            if (GetSkillCount(skill) > 0)
            {
                Instance._skillsCount[skill]--;
                return true;
            }

            return false;
        }
        
        public static bool ConsumeSkillAndSave(Skill skill)
        {
            bool consumed = ConsumeSkill(skill);
            Instance.Save();
            return consumed;
        }
        
        #region IPersistent

        public string PersistentFileName => "sklcount";
        
        public void ResetToDefault()
        {
            Reset();
        }

        private void Reset()
        {
            _skillsCount = SkillsDefaultCountSettings.GetDefaultCountsCopy();
        }

        public bool ReadPreviousVersion(string version, byte[] data)
        {
            return true;
        }   

        #endregion
    }
}