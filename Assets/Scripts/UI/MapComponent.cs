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
    public class MapComponent : ComponentBase
    {
        public Dictionary<LocationEnum, Location> Locations = new();

        [SerializeField] List<LocationSubcomponent> _locationsSubcomponents;

        [SerializeField] Button _backButton;

        private LocationEnum _previousLocation;

        public override void Draw()
        {
            Find.GameController.ClearScene();
            UpdateMap();
            Find.UIManager.GetUI("Toolbar").Hide();
        }

        public override void Undraw()
        {
        }

        public override void Refresh()
        {
        }

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
            if (loc.Status == LocationStatus.Locked) return;

            var actor = Find.BackgroundManager.GetActor("Main");

            if (!loc.CurrentStoryScript.IsNullOrEmpty())
                await Find.ScriptPlayer.PreloadAndPlayAsync(loc.CurrentStoryScript);

            await actor.ChangeAppearanceAsync(location.ToString(), 0);
            Find.UIManager.GetUI("MapUI").Hide();
            Find.UIManager.GetUI("Toolbar").Show();
            _previousLocation = location;
        }

        public void LoadPreviousLocation()
        {
            Debug.Log(_previousLocation);
            if (_previousLocation == LocationEnum.None)
                return;
            LoadLocation(_previousLocation);
        }

        private void Awake()
        {
            InitLocations();
            _backButton.onClick.AddListener(LoadPreviousLocation);
        }

        private void InitLocations()
        {
            Locations = new()
            {
                { 
                    LocationEnum.Basement,
                    new Location(LocationEnum.Basement, LocationStatus.Unlocked, "")
                },
                {
                    LocationEnum.Bar,
                    new Location(LocationEnum.Bar, LocationStatus.Locked, "")
                },
                {
                    LocationEnum.Shop,
                    new Location(LocationEnum.Shop, LocationStatus.Locked, "")
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