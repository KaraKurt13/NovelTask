using Assets.Scripts.Locations;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Quests
{
    public class LocationVisitQuest : QuestBase
    {
        protected override string _name => Engine.GetService<ITextManager>().GetRecordValue("Type.LocationVisit.Name", "Quests");

        protected override string _description => Engine.GetService<ITextManager>().GetRecordValue("Type.LocationVisit.Description", "Quests");

        protected override List<ExecutableActionBase> _onCompleteActions { get; set; } = new();

        private LocationEnum _targetLocation;

        public override string GetName()
        {
            return string.Format(_name, _targetLocation.ToString());
        }

        public override string GetDescription()
        {
            return string.Format(_description, _targetLocation.ToString());
        }

        public LocationVisitQuest(LocationEnum targetLocation, List<ExecutableActionBase> actions = null)
        {
            _targetLocation = targetLocation;
            if (actions != null)
            {
                foreach (var action in actions)
                {
                    _onCompleteActions.Add(action);
                }
            }
        }
    }
}