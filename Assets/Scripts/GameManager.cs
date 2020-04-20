﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float HighScore { get; private set; } = 0f;

    public enum State 
    {
        MainMenu,
        Playing,
        GameOver,
        Credits,
        Tutorial
    }

    public enum GameMode
    {
        Barrels,
        Drones
    }

    public ReactiveProperty<State> state = new ReactiveProperty<State>(State.MainMenu);

    public ReactiveProperty<int> score = new ReactiveProperty<int>(0);

    [HideInInspector]
    public float distance = 0f;

    public ReactiveProperty<GameMode> gameMode = new ReactiveProperty<GameMode>(GameMode.Barrels);

    [SerializeField]
    private float barrelsLength = 20f;

    private float lastGameModeChange = 0;

    [SerializeField]
    private int startSpawn = 2;
    [SerializeField]
    private int spawnStep = 2;

    [HideInInspector]
    public int toSpawn;

    private void Start()
    {
        HighScore = PlayerPrefs.GetFloat("HighScore", 0f);
        toSpawn = startSpawn - spawnStep;
    }

    private void Update()
    {
        if (state.Value == State.Playing)
        {
            distance += SpeedManager.Instance.Speed * Time.deltaTime;
            score.Value = Mathf.FloorToInt(distance * 10);

            if (gameMode.Value == GameMode.Barrels)
            {
                if (Time.time > lastGameModeChange + barrelsLength)
                {
                    lastGameModeChange = Time.time;
                    toSpawn += spawnStep;
                    gameMode.Value = GameMode.Drones;
                }
            }
        }
    }

    public void SetGameMode(GameMode gameMode)
    {
        lastGameModeChange = Time.time;
        this.gameMode.Value = gameMode;
    }
}
