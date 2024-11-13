using Assets.Scripts.Locations;
using Assets.Scripts.Main;
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

        [SerializeField] Button _button;

        [SerializeField] GameObject _lockImage, _glowImage;

        [SerializeField] TextMeshProUGUI _nameText;

        public void UpdateLocationStatus()
        {
            _nameText.text = RelatedLocation.Name;
            var isLocked = RelatedLocation.Status == LocationStatus.Locked;
            ChangeLocationLock(isLocked);
        }

        public void Activate()
        {
            UpdateLocationStatus();
            _nameText.text = RelatedLocation.Name;
            _button.onClick.AddListener(() => Find.MapComponent.LoadLocation(LocationType));
        }

        private void ChangeLocationLock(bool isLocked)
        {
            _lockImage.SetActive(isLocked);
            _glowImage.SetActive(!isLocked);
            _button.interactable = !isLocked;
        }
    }
}