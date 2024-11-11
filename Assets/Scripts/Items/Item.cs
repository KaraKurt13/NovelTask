using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item
    {
        public string Name { get; }

        public ItemTypeEnum Type { get; }

        public Item(string name, ItemTypeEnum type)
        {
            Name = name;
            Type = type;
        }
    }
}