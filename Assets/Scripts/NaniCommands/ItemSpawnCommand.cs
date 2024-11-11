using Assets.Scripts.Items;
using Assets.Scripts.Main;
using Naninovel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("trySpawnItem")]
    public class ItemSpawnCommand : Command
    {
        [ParameterAlias("ID")]
        public int ID;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.ItemsSpawner.SpawnItem(ID);
            return UniTask.CompletedTask;
        }
    }
}