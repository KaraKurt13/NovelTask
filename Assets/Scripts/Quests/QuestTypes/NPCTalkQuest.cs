using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class NPCTalkQuest : QuestBase
    {
        protected override string _name => "Talking with {0}";

        protected override string _description => "You need to talk to {0}";

        protected override OnQuestCompleteActionBase _onCompleteAction { get; set; }

        private CharacterEnum _targetNPC;

        public override string GetDescription()
        {
            return string.Format(_description, _targetNPC.ToString());
        }

        public override string GetName()
        {
            return string.Format(_name, _targetNPC.ToString());
        }

        public NPCTalkQuest(CharacterEnum targetNPC, OnQuestCompleteActionBase action = null)
        {
            _targetNPC = targetNPC;
            _onCompleteAction = action;
        }
    }
}
