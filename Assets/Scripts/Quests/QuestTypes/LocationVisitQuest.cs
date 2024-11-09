using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class LocationVisitQuest : QuestBase
    {
        protected override string _name => "Visiting {0}";

        protected override string _description => "You need to visit {0}";

        protected override OnQuestCompleteActionBase _onCompleteAction { get; set; }

        private LocationEnum _targetLocation;

        public override string GetName()
        {
            return string.Format(_name, _targetLocation.ToString());
        }

        public override string GetDescription()
        {
            return string.Format(_description, _targetLocation.ToString());
        }

        public LocationVisitQuest(LocationEnum targetLocation)
        {
            _targetLocation = targetLocation;
        }
    }
}