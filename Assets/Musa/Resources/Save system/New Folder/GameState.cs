using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameState", menuName = "ScriptableObject/GameState", order = 1)]
public class GameState : ScriptableObject
{
    public string playerSpawnLoaction = "";
}
