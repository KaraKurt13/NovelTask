using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class ItemType
    {
        public string Name { get; }

        public Sprite Sprite { get; }

        public ItemTypeEnum Type { get; }

        public ItemType(string name, ItemTypeEnum type, Sprite sprite)
        {
            Name = name;
            Type = type;
            Sprite = sprite;
        }
    }
}