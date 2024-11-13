using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Naninovel;
using DTT.MinigameMemory;
using Assets.Scripts.Main;
using System;
using System.Threading.Tasks;
using UnityEditor;

[InitializeAtRuntime]
public class MemoryGameService : IEngineService
{
    private MemoryGameManager _memoryGameManager;

    private TaskCompletionSource<bool> _gameCompletionSource;

    public void DestroyService()
    {
        if (_memoryGameManager != null)
        {
            _memoryGameManager.Finish -= OnGameFinish;
        }
    }

    public UniTask InitializeServiceAsync()
    {
        return UniTask.CompletedTask;
    }

    public void ResetService() { }

    public async UniTask StartMemoryGameAsync()
    {
        var gameSettings = Find.GameController.MemoryGameSettings;
        _gameCompletionSource = new TaskCompletionSource<bool>();
        _memoryGameManager = Find.MemoryGameManager;

        _memoryGameManager.Finish += OnGameFinish;
        _memoryGameManager.StartGame(gameSettings);
        Find.UIManager.GetUI("MemoryGame").Show();

        await _gameCompletionSource.Task;

        Find.UIManager.GetUI("MemoryGame").Hide();
    }

    private void OnGameFinish(MemoryGameResults results)
    {
        if (_gameCompletionSource != null)
        {
            _gameCompletionSource.SetResult(true);
            _gameCompletionSource = null;
        }
    }
}
