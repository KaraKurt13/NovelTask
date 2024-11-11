using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestAdvanceAction : ExecutableActionBase
    {
        private int _advanceStep;

        public override void Execute()
        {
            Find.QuestTracker.TryAdvanceCurrentQuestChain(_advanceStep);
        }

        public QuestAdvanceAction(int advanceStep)
        {
            _advanceStep = advanceStep;
        }
    }
}