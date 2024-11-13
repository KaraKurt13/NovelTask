using Assets.Scripts.Locations;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class QuestUpdaterComponent : MonoBehaviour
    {
        [SerializeField] GameObject _messagePrefab;
        [SerializeField] Transform _container;

        private string _newQuestText => Engine.GetService<ITextManager>().GetRecordValue("Notification.New", "Quests");
        private string _updateQuestText => Engine.GetService<ITextManager>().GetRecordValue("Notification.Update", "Quests");
        private string _finishQuestText => Engine.GetService<ITextManager>().GetRecordValue("Notification.Finish", "Quests");

        public void OnQuestChainAdd()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText(_newQuestText);
        }

        public void OnQuestUpdate()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText(_updateQuestText);
        }

        public void OnQuestChainFinish()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText(_finishQuestText);
        }
    }
}