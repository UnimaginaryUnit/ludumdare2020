﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Neat;
using static Neat.DSL;

public class UIManager : UIBehaviour
{
    [SerializeField]
    private Transform root;
    protected override Transform GetRoot() => root;

    private void OnUpdate()
    {
        this.ReDraw();
    }

    protected override UINode Render()
    {
        return Draw("Root",
            DrawMenu()
        );
    }

    private UINode DrawMenu()
    {
        if (GameManager.Instance.state != GameManager.State.MainMenu)
        {
            return null;
        }

        return Draw("MainMenu",
                DrawLeaf("Title"),
                DrawLeaf("Start", OnClick(_ => GameManager.Instance.Play())),
                DrawLeaf("Credits"),
                DrawLeaf("LD")
            );
    }
}
