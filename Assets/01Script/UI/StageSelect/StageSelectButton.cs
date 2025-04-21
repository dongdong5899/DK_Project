using DKProject.Stage;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Button = DKProject.UI.Button;

namespace DKProject.UI
{
    public class StageSelectButton : Button
    {
        [SerializeField] private TextMeshProUGUI _stageNameText;
        [SerializeField] private TextMeshProUGUI _combatText;
        [SerializeField] private Image _bgImage;                //TODO: ChangeBG

        public void Init(StageSO stage)
        {
            _stageNameText.SetText(stage.stageName);
            _combatText.SetText($"추천 전투력: {stage.recommendCombat}");
            //BG를 바꾸면 바꿔
        }
    }
}
