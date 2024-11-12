using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public abstract class QuestBase
    {
        protected abstract string _name { get; }

        protected abstract string _description { get; }

        protected abstract List<ExecutableActionBase> _onCompleteActions { get; set; }

        public bool IsCompleted { get; set; } = false;

        public abstract string GetName();

        public abstract string GetDescription();

        public virtual void OnComplete()
        {
            IsCompleted = true;
            Find.QuestUpdater.OnQuestUpdate();
            foreach (var action in _onCompleteActions)
            {
                action.Execute();
            }
        }

        public QuestBase(List<ExecutableActionBase> _onCompleteactions = null)
        {

        }
    }
}