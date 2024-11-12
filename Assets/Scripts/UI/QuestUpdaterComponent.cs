using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class QuestUpdaterComponent : MonoBehaviour
    {
        [SerializeField] GameObject _messagePrefab;
        [SerializeField] Transform _container;

        public void OnQuestChainAdd()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText("New quest started!");
        }

        public void OnQuestUpdate()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText("Quest update!");
        }

        public void OnQuestChainFinish()
        {
            var message = Instantiate(_messagePrefab, _container).GetComponent<QuestMessageSubcomponent>();
            message.SetText("Quest finished!");
        }
    }
}