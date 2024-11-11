using Assets.Scripts.Locations;
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

        private Queue<QuestChain> _questChains = new();

        private void Start()
        {
            InitQuests();
        }

        public void TryStartNewQuestChain(int chainID)
        {
            if (CurrentQuestChain != null || CurrentQuestChain?.ID == chainID) return;

            var questChain = _questChains.Dequeue();
            CurrentQuestChain = questChain;
            CurrentQuestChain.OnStart();
        }

        public void TryAdvanceCurrentQuestChain(int stepID)
        {
            if (CurrentQuestChain?.Step >= stepID) return;
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
            var quest1 = new NPCTalkQuest(CharacterEnum.Rebecca, new List<OnQuestCompleteActionBase>()
            {
                new LocationUpdateAction(LocationEnum.Bar, LocationStatus.Unlocked)
            });
            var quest2 = new MiniGameQuest(new List<OnQuestCompleteActionBase>()
            {
                new ItemRewardAction(),
                new LocationUpdateAction(LocationEnum.Shop, LocationStatus.Unlocked),

            });
            var quest3 = new LocationVisitQuest(LocationEnum.Bar);
            var quest4 = new LocationVisitQuest(LocationEnum.Basement);

            var quests = new List<QuestBase>()
            {
                { new NPCTalkQuest(CharacterEnum.Rebecca) },
                { new MiniGameQuest(new List<OnQuestCompleteActionBase>(){ }) },
            };
            
            var questChain = new QuestChain(new List<QuestBase>
            {
                quest1,
                quest2,
                quest3,
                quest4
            }, 
            0);

            _questChains.Enqueue(questChain);
        }

        public void OnQuestChainComplete()
        {

        }
    }
}