using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ToolbarComponent : MonoBehaviour
    {
        [SerializeField] Button _mapButton, _inventoryButton;

        private void Awake()
        {
            _mapButton.onClick.AddListener(() => Find.MapComponent.ReturnToMap());
        }
    }
}