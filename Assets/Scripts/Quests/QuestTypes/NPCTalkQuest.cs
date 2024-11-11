using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class NPCTalkQuest : QuestBase
    {
        protected override string _name => "Talking with {0}";

        protected override string _description => "You need to talk to {0}";

        protected override List<ExecutableActionBase> _onCompleteActions { get; set; } = new();

        private CharacterEnum _targetNPC;

        public override string GetDescription()
        {
            return string.Format(_description, _targetNPC.ToString());
        }

        public override string GetName()
        {
            return string.Format(_name, _targetNPC.ToString());
        }

        public NPCTalkQuest(CharacterEnum targetNPC, List<ExecutableActionBase> actions = null)
        {
            _targetNPC = targetNPC;
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    _onCompleteActions.Add(action);
                }
            }
        }
    }
}
