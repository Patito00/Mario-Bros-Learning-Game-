using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    private static readonly Lazy<GameController> lazy = new Lazy<GameController>(() => new GameController());

    public static GameController Instance { get { return lazy.Value; } }

    [NonSerialized] public int points;
    [NonSerialized] public int lifes;

    private GameController() {
        points = 0;
        lifes = 3;
    }
}