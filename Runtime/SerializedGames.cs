using System.Collections.Generic;
using Match3.Core.GameSerialization;
using SaveSystem;
using UnityEngine;
using Utils;
using Utils.Attributes;

namespace Match3.Persistence
{
    [CreateAssetMenu(fileName = "SerializedGames", menuName = "Match3/Persistent/SerializedGames", order = 0)]
    public class SerializedGames : ScriptableObjectSingleton<SerializedGames>, IPersistent
    {
        [SerializeField] private int _maxCount;
        [SerializeField, ToStringLabel] private List<SerializableGame> _games;

        #region IPersistent implementation

        public string PersistentFileName => "games";
        
        public void ResetToDefault()
        {
            _games.Clear();
        }

        public bool ReadPreviousVersion(string version, byte[] data)
        {
            return true;
        }

        #endregion

        public void Add(SerializableGame item)
        {
            if (_games.Count < _maxCount)
                _games.Add(item);
        }

        public void Clear()
        {
            _games.Clear();
        }

        public bool Contains(SerializableGame item)
        {
            return _games.Contains(item);
        }

        public bool Remove(SerializableGame item)
        {
            return _games.Remove(item);
        }

        public int Count => _games.Count;
    }
}