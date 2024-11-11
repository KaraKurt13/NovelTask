using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using System.Reflection;
using System.Threading;
using Assets.Scripts.Quests;
using Assets.Scripts.Main;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("tryAdvanceQuestChain")]
    public class AdvanceCurrentQuestChain : Command
    {
        [ParameterAlias("stepID")]
        public IntegerParameter StepID;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.QuestTracker.TryAdvanceCurrentQuestChain(StepID.Value);
            return UniTask.CompletedTask;
        }
    }
}