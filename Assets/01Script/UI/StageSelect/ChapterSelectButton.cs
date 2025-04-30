using DKProject.Chapter;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using Button = DKProject.UI.Button;

namespace DKProject.UI
{
    public class ChapterSelectButton : Button
    {
        [SerializeField] private TextMeshProUGUI chapterText;
        [SerializeField] private Image chapterBG;

        public void Init(ChapterSO chapter)
        {
            chapterText.SetText(chapter.chapterName);
            chapterBG.sprite = chapter.chapterBGSprite;
        }
    }
}
