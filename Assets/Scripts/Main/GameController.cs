using Assets.Scripts.Items;
using Assets.Scripts.Quests;
using Assets.Scripts.UI;
using DTT.MinigameMemory;
using Naninovel;
using Naninovel.UI;
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

        public MemoryGameSettings MemoryGameSettings;

        public async void ClearScene()
        {
            await Engine.GetService<ITextPrinterManager>().GetActor("Dialogue").ChangeVisibilityAsync(false, 0);
            Engine.GetService<ICharacterManager>().ResetService();
            foreach (var item in InteractableItems.ToList())
            {
                Destroy(item);
                InteractableItems.Remove(item);
            }
        }

        private void Awake()
        {
            Engine.OnInitializationFinished += Init;
        }

        private void OnDestroy()
        {
            Engine.OnInitializationFinished -= Init;
        }

        private void Init()
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
            Find.MemoryGameManager = FindAnyObjectByType<MemoryGameManager>();
            Debug.Log(Find.ItemsSpawner + " _ " + Find.MemoryGameManager);
        }
    }
}