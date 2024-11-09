using Assets.Scripts.Locations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class LocationSubcomponent : MonoBehaviour
    {
        public LocationEnum Location { get; }

        [SerializeField] Image _statusImage;
    }
}