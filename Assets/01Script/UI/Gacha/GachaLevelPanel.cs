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

        private void Start()
        {
            GachaManager.Instance.OnChangeGachaLevel += UpdateLevelPanel;
        }

        private void UpdateLevelPanel(LevelData levelData)
        {
            _levelText.text = $"·¹º§ {_levelText}  ({levelData.count}/{levelData.needCount})";
            _expBar.value = levelData.needCount / levelData.count;
        }
    }
}
