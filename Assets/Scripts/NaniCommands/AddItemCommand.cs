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
    [CommandAlias("addItem")]
    public class AddItemCommand : Command
    {
        [ParameterAlias("itemType")]
        public StringParameter ItemType;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(ItemType, true, out ItemTypeEnum itemType))
            {
                throw new Exception($"Invalid location value: {ItemType}");
            }

            Find.GameController.PlayerInventory.Add(itemType);
            return UniTask.CompletedTask;
        }
    }
}