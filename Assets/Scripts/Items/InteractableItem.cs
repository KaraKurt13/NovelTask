using Assets.Scripts.Main;
using Assets.Scripts.Quests;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Items
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] Image _image;

        [SerializeField] Button _button;

        private ExecutableActionBase OnUse;

        public int DataID { get; set; }

        public void Activate()
        {
            var spawnData = Find.ItemsSpawner.ItemsSpawnData[DataID];
            _image.sprite = DataLibrary.ItemTypes[spawnData.Type].Sprite;
            _button.onClick.AddListener(PickUp);
            OnUse = spawnData.OnUseAction;
        }

        public void PickUp()
        {
            var spawnData = Find.ItemsSpawner.ItemsSpawnData[DataID];
            spawnData.IsTaken = true;
            // add to player inv
            OnUse?.Execute();
            Destroy(this.gameObject);
        }
    }
}