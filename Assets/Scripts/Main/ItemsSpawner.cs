using Assets.Scripts.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class ItemsSpawner : MonoBehaviour
    {
        public Dictionary<int, ItemSpawnData> ItemsSpawnData = new();

        [SerializeField] GameObject _interactableItemPrefab;
        private Canvas _interactableObjectsCanvas;

        public void SpawnItem(int spawnDataID)
        {
            if (!ItemsSpawnData.TryGetValue(spawnDataID, out ItemSpawnData itemSpawnData))
            {
                throw new Exception($"Item with {spawnDataID} not found!");
            }

            if (itemSpawnData.IsTaken) return;
            var item = Instantiate(_interactableItemPrefab, new Vector3(itemSpawnData.X, itemSpawnData.Y), Quaternion.identity, _interactableObjectsCanvas.transform)
                .GetComponent<InteractableItem>();
            item.gameObject.transform.localScale = Vector3.one * itemSpawnData.Scale;
            item.DataID = spawnDataID;
            item.Activate();
            Find.GameController.Items.Add(item.gameObject);
        }
        private void Awake()
        {
            InitData();
        }

        private void InitData()
        {
            _interactableObjectsCanvas = GameObject.Find("InteractableObjectsCanvas").GetComponent<Canvas>();
            ItemsSpawnData.Add(0, new ItemSpawnData(0, 500f, 500f, ItemTypeEnum.Vase, 3f));
        }
    }
}