using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using Assets.Scripts.UI;
using DTT.Utils.Extensions;
using Naninovel;
using Naninovel.UI;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public void UpdateMap()
        {
            foreach (var location in _locationsSubcomponents)
            {
                location.UpdateLocationStatus();
            }
        }

        public async void LoadLocation(LocationEnum location)
        {
            var loc = Locations[location];
            var actor = Find.BackgroundManager.GetActor("Main");
            var map = Find.UIManager.GetUI("MapUI");
            var toolbar = Find.UIManager.GetUI("Toolbar");

            Engine.GetService<ITextPrinterManager>().ResetService();
            Engine.GetService<ICharacterManager>().ResetService();

            if (!loc.CurrentStoryScript.IsNullOrEmpty())
                await Find.ScriptPlayer.PreloadAndPlayAsync(loc.CurrentStoryScript);

            await ToggleMap(false);
            await actor.ChangeAppearanceAsync(location.ToString(), 0);
        }

        public async void ReturnToMap()
        {
            await ToggleMap(true);
        }

        private void Awake()
        {
            InitLocations();
        }

        private async UniTask ToggleMap(bool isActive)
        {
            var map = Find.UIManager.GetUI("MapUI");
            var toolbar = Find.UIManager.GetUI("Toolbar");

            foreach (var location in _locationsSubcomponents)
            {
                location.UpdateLocationStatus();
            }

            await map.ChangeVisibilityAsync(isActive);
            await toolbar.ChangeVisibilityAsync(!isActive);
        }

        private void InitLocations()
        {
            Locations = new()
            {
                { 
                    LocationEnum.Basement,
                    new Location("Basement", LocationStatus.Unlocked, "")
                },
                {
                    LocationEnum.Bar,
                    new Location("Bar", LocationStatus.Locked, "")
                },
                {
                    LocationEnum.Shop,
                    new Location("Shop", LocationStatus.Locked, "")
                }
            };

            foreach (var  location in _locationsSubcomponents)
            {
                var locationType = location.LocationType;
                location.RelatedLocation = Locations[locationType];
                location.Activate();
            }
        }
    }
}