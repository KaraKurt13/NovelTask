using Assets.Scripts.Quests;
using Assets.Scripts.UI;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public static class Find
    {
        public static IScriptManager ScriptManager { get; set; }

        public static IBackgroundManager BackgroundManager { get; set; }

        public static QuestTracker QuestTracker { get; set; }

        public static MapComponent MapComponent { get; set; }
    }
}