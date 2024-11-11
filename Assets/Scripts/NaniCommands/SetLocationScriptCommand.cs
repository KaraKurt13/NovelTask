using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("setLocationScript")]
    public class SetLocationScriptCommand : Command
    {
        [ParameterAlias("location")]
        public StringParameter Location;

        [ParameterAlias("scriptName")]
        public StringParameter ScriptName;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(Location, true, out LocationEnum locationEnum))
            {
                throw new Exception($"Invalid location value: {Location}");
            }
            Find.MapComponent.Locations[locationEnum].SetScript(ScriptName);
            return UniTask.CompletedTask;
        }
    }
}