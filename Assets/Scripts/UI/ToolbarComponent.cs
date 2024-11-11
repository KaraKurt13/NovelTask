using Assets.Scripts.Main;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ToolbarComponent : MonoBehaviour
    {
        [SerializeField] Button _mapButton, _inventoryButton, _questLogButton;

        private void Awake()
        {
            _mapButton.onClick.AddListener(() => Find.UIManager.GetUI("MapUI").Show());
            _questLogButton.onClick.AddListener(() => Find.UIManager.GetUI("QuestLog").Show());
        }
    }
}