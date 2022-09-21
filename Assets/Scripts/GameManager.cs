using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    public List<List<GameObject>> teams = new List<List<GameObject>>();

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Debug.Log("Running Start");
            for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
            {
                teams.Add(new List<GameObject>());
                for (int z = 0; z < PlayerAmounts.ZombieAmount; z++)
                {
                    Debug.Log(("Running z"));
                    GameObject thisTeam = Instantiate(prefabs[Random.Range(0,prefabs.Count)], Vector3.zero, Quaternion.identity);
                    teams[i].Insert(z,thisTeam);
                }
                
            }
    }

    public void SpawnManager()
    {
        //spawn objects randomly around the world
        //based on the player amount up to 4 "worms".
    }

}
