using Assets.Scripts.Items;
using Assets.Scripts.Main;
using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("spawnItem")]
    public class ItemSpawnCommand : Command
    {
        public StringParameter ItemType { get; set; }

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(ItemType, true, out ItemTypeEnum itemType))
            {
                throw new Exception($"Item type {ItemType} not found!");
            }

            Find.GameController.SpawnItem(itemType);
            return UniTask.CompletedTask;
        }
    }
}