using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerSelector playerSelector;

    public List<List<GameObject>> teams;

    private void Start()
    {
        teams.Add(new List<GameObject>());
    }

    public void SpawnManager()
    {
        //spawn objects randomly around the world
        //based on the player amount up to 4 "worms".
    }
}
