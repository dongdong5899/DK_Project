using DKProject.Core;
using Doryu.JBSave;
using System;
using System.Numerics;
using UnityEngine;

namespace DKProject.Chapter
{
    [Serializable]
    public class ChapterSave : ISavable<ChapterSave>
    {
        public int chapterProgress;
        public int currentStage;

        public bool OnLoadData(ChapterSave classData)
        {
            if (classData == null) return false;
            chapterProgress = classData.chapterProgress;
            return true;
        }

        public void OnSaveData(string savedFileName)
        {
        
        }

        public void ResetData()
        {
            chapterProgress = 0;
            currentStage = 0;
        }
    }
}
