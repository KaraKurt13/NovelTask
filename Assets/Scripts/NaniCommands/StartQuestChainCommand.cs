using Assets.Scripts.Main;
using Naninovel;

namespace Assets.Scripts.Nanicommands
{
    [CommandAlias("startQuestChain")]
    public class StartQuestChainCommand : Command
    {
        public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            Find.QuestTracker.StartNewQuestChain();
            return UniTask.CompletedTask;
        }
    }
}