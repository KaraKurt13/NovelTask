using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public abstract class QuestBase
    {
        protected abstract string _name { get; }

        protected abstract string _description { get; }

        protected abstract List<OnQuestCompleteActionBase> _onCompleteActions { get; set; }

        public abstract string GetName();

        public abstract string GetDescription();

        public virtual void OnComplete()
        {
            foreach (var action in _onCompleteActions)
            {
                action.Execute();
            }
        }

        public QuestBase(List<OnQuestCompleteActionBase> _onCompleteactions = null)
        {

        }
    }
}