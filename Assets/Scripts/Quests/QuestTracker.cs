using Assets.Scripts.Quests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class QuestTracker : MonoBehaviour
    {
        public QuestChain CurrentQuestChain { get; private set; }

        public List<QuestChain> CompletedQuests { get; private set; } = new();

        private List<QuestChain> _questChains = new();

        private void Start()
        {
            InitQuests();
        }

        public void AdvanceCurrentQuestChain()
        {
            Debug.Log("advanced!");
            if (CurrentQuestChain == null) return;

            CurrentQuestChain.Advance();
            if (CurrentQuestChain.IsCompleted)
            {
                CompletedQuests.Add(CurrentQuestChain);
                CurrentQuestChain = null;
                OnQuestChainComplete();
            }
        }

        private void InitQuests()
        {
        }

        public void OnQuestChainComplete()
        {

        }
    }
}