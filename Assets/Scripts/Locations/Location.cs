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
        public string Name => Engine.GetService<ITextManager>().GetRecordValue(LocationEnum.ToString(), "Locations");

        public LocationStatus Status { get; private set; }

        public string CurrentStoryScript { get; private set; }

        public LocationEnum LocationEnum { get; private set; }

        public void SetScript(string script)
        {
            CurrentStoryScript = script;
        }

        public void SetLocationStatus(LocationStatus status)
        {
            Status = status;
            Find.MapComponent.UpdateMap();
        }

        public Location(LocationEnum locationEnum, LocationStatus status, string currentStoryScript)
        {
            LocationEnum = locationEnum;
            Status = status;
            CurrentStoryScript = currentStoryScript;
        }
    }
}