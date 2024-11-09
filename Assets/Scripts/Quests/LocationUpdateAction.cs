using Assets.Scripts.Locations;
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
            // Set new status for location
        }

        public LocationUpdateAction(LocationEnum location, LocationStatus newStatus)
        {
            _location = location;
            _newStatus = newStatus;
        }
    }
}