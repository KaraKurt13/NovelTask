using Assets.Scripts.Locations;
using Assets.Scripts.UI;
using Naninovel.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class MapComponent : MonoBehaviour
    {
        public Dictionary<LocationEnum, Location> Locations = new();

        [SerializeField] List<LocationSubcomponent> _locationsSubcomponents;

        [SerializeField] Button _backButton;

        private LocationEnum _currentLocation;

        public void LoadLocation(LocationEnum location)
        {

        }

        private void Awake()
        {
            InitLocations();
        }

        private void InitLocations()
        {
            Locations = new()
            {
                { 
                    LocationEnum.Location1,
                    new Location("Location1", LocationStatus.Unlocked, "")
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

            foreach (var  location in _locationsSubcomponents)
            {
                var locationType = location.LocationType;
                location.RelatedLocation = Locations[locationType];
                location.Activate();
            }
        }

        private void OnEnable()
        {
            _backButton.interactable = _currentLocation != LocationEnum.None ? true : false;
        }
    }
}