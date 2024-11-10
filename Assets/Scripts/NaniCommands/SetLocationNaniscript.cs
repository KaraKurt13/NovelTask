using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("setLocationScript")]
    public class SetLocationNaniscript : Command
    {
        [ParameterAlias("location")]
        public LocationEnum Location;

        [ParameterAlias("scriptName")]
        public StringParameter ScriptName;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.MapComponent.Locations[Location].SetScript(ScriptName);
            return UniTask.CompletedTask;
        }
    }
}