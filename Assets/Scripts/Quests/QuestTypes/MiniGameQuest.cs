using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class MiniGameQuest : QuestBase
    {
        protected override string _name => Engine.GetService<ITextManager>().GetRecordValue("Type.MiniGame.Name", "Quests");

        protected override string _description => Engine.GetService<ITextManager>().GetRecordValue("Type.MiniGame.Description", "Quests");

        protected override List<ExecutableActionBase> _onCompleteActions { get; set; } = new();

        public override string GetName()
        {
            return _name;
        }

        public override string GetDescription()
        {
            return _description;
        }

        public MiniGameQuest(List<ExecutableActionBase> actions = null)
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