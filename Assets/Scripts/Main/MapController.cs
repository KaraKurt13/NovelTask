using Assets.Scripts.Locations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class MapController : MonoBehaviour
    {
        public Dictionary<LocationEnum, Location> Locations = new();

        public void LoadLocation(LocationEnum location)
        {

        }

        private void InitLocations()
        {
            Locations = new()
            {
                { 
                    LocationEnum.Location1,
                    new Location("Location1", LocationStatus.Locked, "")
                },
                {
                    LocationEnum.Location2,
                    new Location("Location2", LocationStatus.Locked, "")
                },
                {
                    LocationEnum.Location3,
                    new Location("Location3", LocationStatus.Locked, "")
                }
            };

        }
    }
}