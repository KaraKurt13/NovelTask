using Assets.Scripts.Quests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class QuestSubcomponent : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _name, _description;

        [SerializeField] Image _fadeEffect;

        public void Draw(QuestBase relatedQuest)
        {
            _name.text = relatedQuest.GetName();
            _description.text = relatedQuest.GetDescription();
            if (relatedQuest.IsCompleted)
                _fadeEffect.enabled = true;
        }
    }
}