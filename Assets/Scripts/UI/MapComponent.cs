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

        private LocationEnum _currentLocation;

        public override void Draw()
        {
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
            Find.GameController.ClearScene();

            var loc = Locations[location];
            var actor = Find.BackgroundManager.GetActor("Main");

            if (!loc.CurrentStoryScript.IsNullOrEmpty())
                await Find.ScriptPlayer.PreloadAndPlayAsync(loc.CurrentStoryScript);

            await actor.ChangeAppearanceAsync(location.ToString(), 0);
            Find.UIManager.GetUI("MapUI").Hide();
            Find.UIManager.GetUI("Toolbar").Show();
            ;        }

        private void Awake()
        {
            InitLocations();
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