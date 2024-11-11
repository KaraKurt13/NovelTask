using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public class ItemSpawnData
    {
        public int ID { get; }

        public float X { get; }

        public float Y { get; }

        public float Scale { get; }

        public ItemTypeEnum Type { get; }

        public bool IsTaken { get; set; } = false;

        public ItemSpawnData(int id, float x, float y, ItemTypeEnum type, float scale = 1f)
        {
            ID = id;
            X = x;
            Y = y;
            Type = type;
            Scale = scale;
        }
    }
}