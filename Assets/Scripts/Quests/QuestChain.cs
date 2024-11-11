using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestChain
    {
        private Queue<QuestBase> _questsChane = new();

        private Stack<QuestBase> _completedQuests = new();

        public QuestBase CurrentQuest;

        public int Step;

        public int ID;

        public bool IsCompleted = false;

        public void OnStart()
        {
            CurrentQuest = _questsChane.Dequeue();
            Step = 0;
        }

        public void Advance()
        {
            Step++;
            CurrentQuest.OnComplete();
            _completedQuests.Push(CurrentQuest);
            if (!_questsChane.TryDequeue(out var quest))
            {
                Debug.Log("Quest chain completed!");
                IsCompleted = true;
                return;
            }
            CurrentQuest = quest;
        }

        private void Complete()
        {

        }

        public IEnumerable<QuestBase> GetCompletedQuests()
        {
            foreach (var quest in _completedQuests)
            {
                yield return quest;
            }
        }
        
        public QuestChain(List<QuestBase> quests, int ID)
        {
            foreach (var quest in quests)
            {
                _questsChane.Enqueue(quest);
            }
        }
    }
}