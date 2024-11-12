using Assets.Scripts.Items;
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
            var quest1 = new NPCTalkQuest(CharacterEnum.Rebecca, new List<ExecutableActionBase>()
            {
                new LocationLockUpdateAction(LocationEnum.Bar, LocationStatus.Unlocked)
            });
            var quest2 = new MiniGameQuest(new List<ExecutableActionBase>()
            {
                new LocationLockUpdateAction(LocationEnum.Shop, LocationStatus.Unlocked),
            });
            var quest3 = new FindItemQuest(ItemTypeEnum.Vase, LocationEnum.Bar, new List<ExecutableActionBase>()
            {
                new LocationLockUpdateAction(LocationEnum.Shop, LocationStatus.Locked),
                new LocationScriptUpdateAction(LocationEnum.Bar,"Chapter4"),
                new LocationLockUpdateAction(LocationEnum.Basement, LocationStatus.Locked)
            });
            var quest4 = new LocationVisitQuest(LocationEnum.Bar, new List<ExecutableActionBase>()
            {
                new LocationLockUpdateAction(LocationEnum.Basement, LocationStatus.Unlocked),
                new LocationScriptUpdateAction(LocationEnum.Basement, "Chapter5")
            });

            var quest5 = new LocationVisitQuest(LocationEnum.Basement, new List<ExecutableActionBase>()
            {
                new LocationLockUpdateAction(LocationEnum.Shop, LocationStatus.Locked),
                new LocationLockUpdateAction(LocationEnum.Bar, LocationStatus.Unlocked)
            });

            var quests = new List<QuestBase>()
            {
                { new NPCTalkQuest(CharacterEnum.Rebecca) },
                { new MiniGameQuest(new List<ExecutableActionBase>(){ }) },
            };
            
            var questChain = new QuestChain(new List<QuestBase>
            {
                quest1,
                quest2,
                quest3,
                quest4,
                quest5
            }, 
            0);

            _questChains.Enqueue(questChain);
        }

        public void OnQuestChainComplete()
        {

        }
    }
}