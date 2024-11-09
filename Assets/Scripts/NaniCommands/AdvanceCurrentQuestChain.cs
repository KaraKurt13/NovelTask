using Naninovel;
using Naninovel.Commands;
using UnityEngine;
using System.Reflection;
using System.Threading;
using Assets.Scripts.Quests;

[CommandAlias("advanceQuestChain")]
public class AdvanceCurrentQuestChain : Command
{
    public override UniTask ExecuteAsync(AsyncToken asyncToken = default)
    {
        var questTracker = GameObject.FindAnyObjectByType<QuestTracker>();
        if (questTracker != null)
        {
            questTracker.AdvanceCurrentQuestChain();
        }

        return UniTask.CompletedTask;
    }
}
