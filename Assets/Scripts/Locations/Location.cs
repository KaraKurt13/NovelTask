using Assets.Scripts.Main;
using DTT.Utils.Extensions;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Locations
{
    public class Location
    {
        public string Name { get; }

        public LocationStatus Status { get; private set; }

        public string CurrentStoryScript { get; private set; }

        public void OnEnter()
        {
            if (CurrentStoryScript != string.Empty)
            {
                Find.ScriptManager.LoadScriptAsync(CurrentStoryScript);
            }
        }

        public void SetScript(string script)
        {
            CurrentStoryScript = script;
        }

        public Location(string name, LocationStatus status, string currentStoryScript)
        {
            Name = name;
            Status = status;
            CurrentStoryScript = currentStoryScript;
        }
    }
}