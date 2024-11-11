using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class LocationScriptUpdateAction : OnQuestCompleteActionBase
    {
        private LocationEnum _location;

        private string _scriptName;

        public LocationScriptUpdateAction(LocationEnum location, string scriptName)
        {
            _location = location;
            _scriptName = scriptName;
        }

        public override void Execute()
        {
            var location = Find.MapComponent.Locations[_location];
            location.SetScript(_scriptName);
        }
    }
}