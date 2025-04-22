using DKProject.Stage;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class StageIndicator : MonoBehaviour
    {
        public StageSelectButton stageButtonPf;
        private List<StageSelectButton> buttonList;

        public void OnSelectChapter(ChapterSO chapter)
        {
            if (buttonList != null)
                buttonList.ForEach(button => Destroy(button.gameObject));

            buttonList = new List<StageSelectButton>();

            chapter.stageList.ForEach(stage =>
            {
                StageSelectButton button = Instantiate(stageButtonPf, transform);
                button.OnClickEvent += () => OnSelectStage(stage);
                button.Init(stage);

                buttonList.Add(button);
            });
        }

        public void OnSelectStage(StageSO stage)
        {

        }
    }
}
