using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryItemSubcomponent : MonoBehaviour
    {
        [SerializeField] Image _itemIcon;

        public void SetSprite(Sprite sprite)
        {
            _itemIcon.enabled = true;
            _itemIcon.sprite = sprite;
        }
    }
}