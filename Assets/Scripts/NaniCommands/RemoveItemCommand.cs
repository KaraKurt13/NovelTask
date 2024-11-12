using Assets.Scripts.Items;
using Assets.Scripts.Locations;
using Assets.Scripts.Main;
using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("removeItem")]
    public class RemoveItemCommand : Command
    {
        [ParameterAlias("itemType")]
        public StringParameter ItemType;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(ItemType, true, out ItemTypeEnum itemType))
            {
                throw new Exception($"Invalid location value: {ItemType}");
            }
            if (!Find.GameController.PlayerInventory.Contains(itemType))
            {
                Debug.LogWarning($"Item {itemType} cannod be found in player inventory!");
            }
            else
                Find.GameController.PlayerInventory.Remove(itemType);
            return UniTask.CompletedTask;
        }
    }
}
