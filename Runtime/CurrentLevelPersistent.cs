using System;
using SaveSystem;
using UnityEngine;
using Utils;

namespace Match3.Persistence
{
    [CreateAssetMenu(fileName = "CurrentLevelPersistent", menuName = "Match3/Persistent/CurrentLevelPersistent", order = 0)]
    public class CurrentLevelPersistent : ScriptableObjectSingleton<CurrentLevelPersistent>, IPersistent
    {
        [SerializeField] private int _currentLevelIndex;

        public int CurrentLevelIndex => _currentLevelIndex;

        public void IncrementLevelIndex(int max)
        {
            _currentLevelIndex++;
            _currentLevelIndex = Math.Min(max, _currentLevelIndex);
        }

        public string PersistentFileName => "crlvl";
        
        public void ResetToDefault()
        {
            Reset();
        }

        private void Reset()
        {
            _currentLevelIndex = 0;
        }

        public bool ReadPreviousVersion(string version, byte[] data)
        {
            return true;
        }
    }
}