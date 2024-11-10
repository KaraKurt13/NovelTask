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