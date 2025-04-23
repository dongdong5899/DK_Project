using DKProject.Chapter;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DKProject.UI
{
    public class StageIndicator : MonoBehaviour
    {
        public StageSelectButton stageButtonPf;

        private List<StageSelectButton> _buttonList;

        public void OnSelectChapter(ChapterSO chapter, int chapterIndex)
        {
            if (_buttonList != null)
                _buttonList.ForEach(button => Destroy(button.gameObject));

            _buttonList = new List<StageSelectButton>();

            for(int i = 0; i < chapter.stageList.Count; i++)
            {
                StageSO stage = chapter.stageList[i];
                int stageIndex = i;

                StageSelectButton button = Instantiate(stageButtonPf, transform);
                button.OnClickEvent += () => OnSelectStage(chapterIndex, stageIndex);
                button.Init(stage);

                _buttonList.Add(button);
            }
        }

        public void OnSelectStage(int chapterIndex, int stageIndex)
        {
            ChapterManager.Instance.LoadStage(chapterIndex, stageIndex);
        }
    }
}
