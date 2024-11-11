using Assets.Scripts.Items;
using Assets.Scripts.Quests;
using Assets.Scripts.UI;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameController : MonoBehaviour
    {
        public List<GameObject> Items = new();

        [SerializeField] GameObject _interactableItemPrefab;

        public void SpawnItem(ItemTypeEnum type)
        {
            
        }

        private void Awake()
        {
            Find.ScriptPlayer = Engine.GetService<IScriptPlayer>();
            Find.BackgroundManager = Engine.GetService<IBackgroundManager>();
            Find.UIManager = Engine.GetService<IUIManager>();
            Find.QuestTracker = FindAnyObjectByType<QuestTracker>();
            Find.MapComponent = FindAnyObjectByType<MapComponent>();
        }
    }
}