using Assets.Scripts.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] Image _image;

        [SerializeField] Button _button;

        public int DataID;

        public void Activate()
        {
            var spawnData = Find.ItemsSpawner.ItemsSpawnData[DataID];
            _image.sprite = DataLibrary.ItemTypes[spawnData.Type].Sprite;
            _button.onClick.AddListener(PickUp);
        }

        public void PickUp()
        {
            var spawnData = Find.ItemsSpawner.ItemsSpawnData[DataID];
            spawnData.IsTaken = true;
            // add to player inv
            Destroy(this.gameObject);
        }
    }
}