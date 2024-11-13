using Assets.Scripts.Main;
using Naninovel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("startMemoryGame")]
    public class StartMemoryGameCommand : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            return Engine.GetService<MemoryGameService>().StartMemoryGameAsync();
        }
    }
}