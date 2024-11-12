using Assets.Scripts.Main;
using Assets.Scripts.UI;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryComponent : ComponentBase
    {
        [SerializeField] Transform _itemsContainer;

        [SerializeField] GameObject _itemPrefab;

        [SerializeField] Button _exitButton;

        private void Awake()
        {
            _exitButton.onClick.AddListener(() => Find.UIManager.GetUI("InventoryUI").Hide());
        }

        public override void Draw()
        {
            UndrawItems();
            DrawItems();
        }

        public override void Refresh()
        {
            UndrawItems();
            DrawItems();
        }

        public override void Undraw()
        {
            UndrawItems();
        }

        private void DrawItems()
        {
            var items = Find.GameController.PlayerInventory;
            for (int i = 0; i < 9; i++)
            {
                var itemObj = Instantiate(_itemPrefab, _itemsContainer).GetComponent<InventoryItemSubcomponent>();
                if (items.ElementAtOrDefault(i) != Items.ItemTypeEnum.None)
                {
                    var itemType = items[i];
                    var sprite = DataLibrary.ItemTypes[itemType].Sprite;
                    itemObj.SetSprite(sprite);
                }
            }
        }

        private void UndrawItems()
        {
            foreach (Transform item in _itemsContainer)
            {
                Destroy(item.gameObject);

            }
        }
    }
}