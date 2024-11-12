using Assets.Scripts.Items;
using Assets.Scripts.Quests;
using Assets.Scripts.UI;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class GameController : MonoBehaviour
    {
        public List<GameObject> InteractableItems = new();

        public List<ItemTypeEnum> PlayerInventory = new();

        public void ClearScene()
        {
            Engine.GetService<ITextPrinterManager>().ResetService();
            Engine.GetService<ICharacterManager>().ResetService();
            foreach (var item in InteractableItems.ToList())
            {
                Destroy(item);
            }
        }

        private void Awake()
        {
            DataLibrary.Init();
            Find.GameController = this;
            Find.ScriptPlayer = Engine.GetService<IScriptPlayer>();
            Find.BackgroundManager = Engine.GetService<IBackgroundManager>();
            Find.UIManager = Engine.GetService<IUIManager>();
            Find.QuestTracker = FindAnyObjectByType<QuestTracker>();
            Find.MapComponent = FindAnyObjectByType<MapComponent>();
            Find.ItemsSpawner = FindAnyObjectByType<ItemsSpawner>();
            Find.QuestUpdater = FindAnyObjectByType<QuestUpdaterComponent>();
        }
    }
}