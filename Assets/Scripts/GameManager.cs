using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private GameObject playerPrefabs;
    [SerializeField] CameraMovement _cameraMovement;
    private List<List<GameObject>> _teams = new List<List<GameObject>>();
    public GameObject[] startPoints;
    public GameObject currentPlayer;
    private int currentTeam = 0;
    private List<int> currentPlayerFromTeam = new List<int>();


    private List<List<Movement>> killme = new List<List<Movement>>();


    private Color ds;
    private void Start()
    {
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            _teams.Add(new List<GameObject>());
            killme.Add(new List<Movement>());
            currentPlayerFromTeam.Add(0);
            //ds = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            for (int z = 0; z < PlayerAmounts.ZombieAmount; z++)
            {

                //Calculates spawn angles of zombie players based on spawn points.
                float spawnAngle = (120f / PlayerAmounts.PlayerAmount) * z;
                Vector3 pos = startPoints[i].transform.position + 6 * new Vector3(Mathf.Cos(spawnAngle), 0f, Mathf.Sin(spawnAngle));
                
                GameObject player = Instantiate(playerPrefabs, pos, Quaternion.identity);
                GameObject thisTeam = Instantiate(prefabs[Random.Range(0, prefabs.Count)], pos, Quaternion.identity);
                
                thisTeam.transform.SetParent(player.transform);
                //player.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = ds;
                _teams[i].Add(player);
                
                killme[i].Add(player.GetComponent<Movement>());
                
            }
        }

        currentPlayer = _teams[0][0];
        _cameraMovement.SetCamera();
        currentPlayer.transform.GetChild(0).GetComponent<Shooting>().enabled = true;
        currentPlayer.GetComponent<Movement>().enabled = true;
        
    }

    public void GoToNextPlayer()
    {
        currentPlayer.transform.GetChild(0).GetComponent<Shooting>().enabled = false;
        killme[currentTeam][currentPlayerFromTeam[currentTeam]].enabled = false;
        NextPlayerInTeam();
        NextTeam();
        _cameraMovement.SetCamera();
        killme[currentTeam][currentPlayerFromTeam[currentTeam]].enabled = true;
        currentPlayer.transform.GetChild(0).GetComponent<Shooting>().enabled = true;
    }


    void NextTeam()
    {
        currentTeam++;
        
        if (currentTeam == PlayerAmounts.PlayerAmount)
        {
            currentTeam %= PlayerAmounts.PlayerAmount;
        }
        currentPlayer = _teams[currentTeam][currentPlayerFromTeam[currentTeam]];
    }
     void NextPlayerInTeam()
     {
         
         currentPlayerFromTeam[currentTeam]++;
         
         if (currentPlayerFromTeam[currentTeam] == PlayerAmounts.ZombieAmount)
         {
             currentPlayerFromTeam[currentTeam] %= PlayerAmounts.ZombieAmount;
         } 
         currentPlayer = _teams[currentTeam][currentPlayerFromTeam[currentTeam]];
     }

}
