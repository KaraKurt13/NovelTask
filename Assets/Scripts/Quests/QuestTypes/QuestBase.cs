using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public abstract class QuestBase
    {
        protected abstract string _name { get; }

        protected abstract string _description { get; }

        protected abstract OnQuestCompleteActionBase _onCompleteAction { get; set; }

        public abstract string GetName();

        public abstract string GetDescription();

        public virtual void OnComplete()
        {
            _onCompleteAction?.Execute();
        }
    }
}