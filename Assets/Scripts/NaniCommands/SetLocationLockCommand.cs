using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using Naninovel;
using System;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("setLocationLock")]
    public class SetLocationLockCommand : Command
    {
        [ParameterAlias("location")]
        public StringParameter Location;

        [ParameterAlias("lockStatus")]
        public StringParameter LockStatus;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(Location, true, out LocationEnum locationEnum))
            {
                throw new Exception($"Invalid location value: {Location}");
            }

            if (!Enum.TryParse(LockStatus, true, out LocationStatus statusEnum))
            {
                throw new Exception($"Invalid location status: {LockStatus}");
            }

            Find.MapComponent.Locations[locationEnum].SetLocationStatus(statusEnum);
            return UniTask.CompletedTask;
        }
    }
}