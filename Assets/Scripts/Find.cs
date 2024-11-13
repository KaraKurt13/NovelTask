using Assets.Scripts.Quests;
using Assets.Scripts.UI;
using DTT.MinigameMemory;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public static class Find
    {
        public static IScriptPlayer ScriptPlayer { get; set; }

        public static IBackgroundManager BackgroundManager { get; set; }

        public static IUIManager UIManager { get; set; }

        public static QuestTracker QuestTracker { get; set; }

        public static MapComponent MapComponent { get; set; }

        public static GameController GameController { get; set; }

        public static ItemsSpawner ItemsSpawner { get; set; }

        public static QuestUpdaterComponent QuestUpdater { get; set; }

        public static MemoryGameManager MemoryGameManager { get; set; }
    }
}