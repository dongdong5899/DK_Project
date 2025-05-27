using DKProject.Core;
using DKProject.SkillSystem;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DKProject
{
    public class GachaLevelPanel : MonoBehaviour
    {
        private TextMeshProUGUI _levelText;
        private Slider _expBar;

        private void Awake()
        {
            _levelText = GetComponentInChildren<TextMeshProUGUI>();
            _expBar = GetComponentInChildren<Slider>();

            GachaManager.Instance.OnChangeGachaLevel += UpdateLevelPanel;
        }

        private void UpdateLevelPanel(LevelData levelData)
        {
            _levelText.text = $"·¹º§ {levelData.level}  ({levelData.count}/{levelData.needCount})";
            //_expBar.value = levelData.count == 0 ? 0 : levelData.count / levelData.needCount;
            _expBar.value = levelData.count / levelData.needCount;
        }
    }
}
