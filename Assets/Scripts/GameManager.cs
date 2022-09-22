using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    private List<List<GameObject>> _teams = new List<List<GameObject>>();
    public GameObject[] startPoints;

    public Timer timer;

    private void Start()
    {
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            _teams.Add(new List<GameObject>());
            for (int z = 0; z < PlayerAmounts.ZombieAmount; z++)
            {   
                //Calculates spawn angles of zombie players based on spawn points.
                float spawnAngle = (120f / PlayerAmounts.PlayerAmount) * i;
                Vector3 pos = startPoints[z].transform.position + 6 * new Vector3(Mathf.Cos(spawnAngle), 0f, Mathf.Sin(spawnAngle));
                
                GameObject thisTeam = Instantiate(prefabs[Random.Range(0,prefabs.Count)], pos, Quaternion.identity);
                _teams[i].Insert(z ,thisTeam);
            }
        }
    }

    void SwitchPlayer()
    {
        //start with player 1 from team 1
        //switch to player 1 from team 2 and so on..
        //once last team player 1 is reached, switch to player 2, team 1 and so on..
    }
}
