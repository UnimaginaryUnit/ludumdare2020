﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Neat;
using static Neat.DSL;
using TMPro;

public class UIManager : UIBehaviour
{
    [SerializeField]
    private Transform root;
    protected override Transform GetRoot() => root;

    protected override void Start()
    {
        base.Start();
        GameManager.Instance.state.OnChanged += OnUpdate;
        GameManager.Instance.score.OnChanged += OnUpdate;
    }

    private void OnUpdate()
    {
        this.ReDraw();
    }

    protected override UINode Render()
    {
        var state = GameManager.Instance.state.Value;
        return Draw("Root",
            Do(() =>
            {
                switch (state)
                {
                    case GameManager.State.MainMenu:
                        return DrawMenu();
                    case GameManager.State.Playing:
                    case GameManager.State.GameOver:
                        return DrawGameUI();
                    //case GameManager.State.Credits:
                    //    break;
                    default:
                        return null;
                }
            })
        );
    }

    private UINode DrawMenu()
    {
        return Draw("MainMenu",
                Draw("Column",
                    DrawLeaf("Title"),
                    MenuButton.Draw("Start",
                        OnClick(_ => GameManager.Instance.state.Value = GameManager.State.Playing)
                    ),
                    MenuButton.Draw("Credits")
                ),
                DrawLeaf("LD")
            );
    }

    private UINode DrawGameUI()
    {
        return Draw("GameUI",
                DrawLeaf("Text (TMP)",
                    Set<TMP_Text>(t => t.text = "SCORE: " + GameManager.Instance.score.Value)
                )
            );
    }
}
