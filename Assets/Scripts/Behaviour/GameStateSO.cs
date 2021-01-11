using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "SO/GameState")]
public class GameStateSO : ScriptableObject
{
    private int points = 0;

    public int Points { get => points; set => points = value; }
}
