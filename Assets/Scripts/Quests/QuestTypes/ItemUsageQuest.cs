using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class ItemUsageQuest : QuestBase
    {
        protected override string _name => "{0} usage.";

        protected override string _description => "Use {0} from your inventory.";

        protected override List<OnQuestCompleteActionBase> _onCompleteActions { get; set; } = new();

        public override string GetDescription()
        {
            return string.Format(_description);
        }

        public override string GetName()
        {
            return string.Format(_name);
        }

        public ItemUsageQuest(List<OnQuestCompleteActionBase> actions = null)
        {
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