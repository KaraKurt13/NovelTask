using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using System.Reflection;
using System.Threading;
using Assets.Scripts.Quests;
using Assets.Scripts.Main;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("advanceQuestChain")]
    public class AdvanceCurrentQuestChain : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.QuestTracker.AdvanceCurrentQuestChain();
            return UniTask.CompletedTask;
        }
    }
}