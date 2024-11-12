using Assets.Scripts.Locations;
using Assets.Scripts.Quests;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class ItemType
    {
        public string Name => Engine.GetService<ITextManager>().GetRecordValue(Type.ToString(), "Locations");

        public Sprite Sprite { get; }

        public ItemTypeEnum Type { get; }

        public ItemType(ItemTypeEnum type, Sprite sprite)
        {
            Type = type;
            Sprite = sprite;
        }
    }
}