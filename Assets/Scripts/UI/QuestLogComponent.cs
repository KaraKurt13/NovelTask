using Assets.Scripts.Main;
using Assets.Scripts.Quests;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class QuestLogComponent : MonoBehaviour
    {
        [SerializeField] Transform _questsContainer;
        [SerializeField] GameObject _questPrefab;

        public void Draw()
        {
            UndrawQuests();

            var questChain = Find.QuestTracker.CurrentQuestChain;

            if (questChain == null) return;

            var currentQuest = questChain.CurrentQuest;
            Instantiate(_questPrefab, _questsContainer).GetComponent<QuestSubcomponent>().Draw(currentQuest);

            foreach (var quest in questChain.GetCompletedQuests())
            {
                var questObj = Instantiate(_questPrefab, _questsContainer).GetComponent<QuestSubcomponent>();
                questObj.Draw(quest);
            }
        }

        public void Undraw()
        {
            UndrawQuests();
        }

        private void UndrawQuests()
        {
            foreach (Transform quest in _questsContainer)
            {
                Destroy(quest.gameObject);
            }
        }
    }
}