using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class LocationUpdateAction : OnQuestCompleteActionBase
    {
        private LocationEnum _location;

        private LocationStatus _newStatus;

        public override void Execute()
        {
            var map = Find.MapComponent;
            map.Locations[_location].SetLocationStatus(_newStatus);
            map.UpdateMap();
        }

        public LocationUpdateAction(LocationEnum location, LocationStatus newStatus)
        {
            _location = location;
            _newStatus = newStatus;
        }
    }
}