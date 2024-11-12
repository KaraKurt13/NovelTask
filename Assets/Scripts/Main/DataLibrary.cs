using Assets.Scripts.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public static class DataLibrary
    {
        public static Dictionary<ItemTypeEnum, ItemType> ItemTypes = new();

        private static bool _isInitialized = false;

        public static void Init()
        {
            if (_isInitialized) return;

            foreach (ItemTypeEnum itemType in Enum.GetValues(typeof(ItemTypeEnum)))
            {
                var itemName = itemType.ToString();
                var itemSprite = Resources.Load<Sprite>($"Sprites/{itemName}");
                var type = new ItemType(itemType, itemSprite);
                ItemTypes.Add(itemType, type);
            }

            _isInitialized = true;
        }
    }
}