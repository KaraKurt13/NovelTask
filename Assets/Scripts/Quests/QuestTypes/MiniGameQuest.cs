using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class MiniGameQuest : QuestBase
    {
        protected override string _name => "Minigame time!";

        protected override string _description => "Play minigame";

        protected override OnQuestCompleteActionBase _onCompleteAction { get; set; }

        public override string GetName()
        {
            return _name;
        }

        public override string GetDescription()
        {
            return _description;
        }
    }
}