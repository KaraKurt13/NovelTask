using Assets.Scripts.Main;
using Naninovel;
using UnityEngine;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("tryStartQuestChain")]
    public class StartQuestChainCommand : Command
    {
        [ParameterAlias("id")]
        public IntegerParameter ID;

        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.QuestTracker.TryStartNewQuestChain(ID.Value);
            return UniTask.CompletedTask;
        }
    }
}