using TMPro;
using UnityEngine;

namespace Match3.Persistence.UI
{
    public class CurrentLevelUi : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _label;

        private void Start()
        {
            UpdateLevelText();
        }

        private void UpdateLevelText()
        {
            int currentLevel = CurrentLevelPersistent.Instance.CurrentLevelIndex;
            _label.text = $"Lvl {currentLevel + 1}";
        }
    }
}