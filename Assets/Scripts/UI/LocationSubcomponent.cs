using Assets.Scripts.Locations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LocationSubcomponent : MonoBehaviour
    {
        public LocationEnum LocationType;

        public Location RelatedLocation { get; set; }

        public Button Button;

        [SerializeField] GameObject _lockImage, _glowImage;

        [SerializeField] TextMeshProUGUI _nameText;

        public void UpdateLocationStatus()
        {
            var status = RelatedLocation.Status;
            if (status == LocationStatus.Locked)
                LockLocation();
            else
                UnlockLocation();
        }

        public void Activate()
        {
            UpdateLocationStatus();
            _nameText.text = RelatedLocation.Name;
        }

        private void LockLocation()
        {
            _lockImage.SetActive(true);
            _glowImage.SetActive(false);
        }

        private void UnlockLocation()
        {
            _lockImage.SetActive(false);
            _glowImage.SetActive(true);
        }
    }
}