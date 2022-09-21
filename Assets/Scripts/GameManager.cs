using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    public List<List<GameObject>> teams = new List<List<GameObject>>();

    private void Start()
    {
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            teams.Add(new List<GameObject>());
            for (int z = 0; z < PlayerAmounts.ZombieAmount; z++) 
            {
                GameObject thisTeam = Instantiate(prefabs[Random.Range(0,prefabs.Count)], Vector3.zero, Quaternion.identity);
                teams[i].Insert(z,thisTeam);
            }
        }
    }
}
