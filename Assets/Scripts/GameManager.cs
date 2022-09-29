using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private GameObject playerPrefabs;
    [SerializeField] private CameraMovement _cameraMovement;
    private List<List<GameObject>> _teams = new List<List<GameObject>>();
    public GameObject[] startPoints;
    public GameObject currentPlayer;
    private int currentTeam = 0;
    private List<int> currentPlayerFromTeam = new List<int>();
    private List<List<Movement>> _movement = new List<List<Movement>>();
    private List<List<Shooting>> _shooting = new List<List<Shooting>>();
    public TeamInfo teamInfo;
    private void Start()
    {
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            _teams.Add(new List<GameObject>());
            _movement.Add(new List<Movement>());
            _shooting.Add(new List<Shooting>());
            currentPlayerFromTeam.Add(0);
            for (int z = 0; z < PlayerAmounts.ZombieAmount; z++)
            {
                //Calculates spawn angles of zombie players based on spawn points.
                float spawnAngle = (120f / PlayerAmounts.PlayerAmount) * z;
                Vector3 pos = startPoints[i].transform.position +
                              3 * new Vector3(Mathf.Cos(spawnAngle), 0f, Mathf.Sin(spawnAngle));

                GameObject player = Instantiate(playerPrefabs, pos, startPoints[i].transform.rotation);
                GameObject thisTeam = Instantiate(prefabs[Random.Range(0, prefabs.Count)], pos,
                    startPoints[i].transform.rotation);

                thisTeam.transform.SetParent(player.transform);
                _teams[i].Add(player);
                _movement[i].Add(player.GetComponent<Movement>());
                _shooting[i].Add(player.GetComponent<Shooting>());
                player.GetComponent<TeamInfo>().playerInfo.text = "Zombie " + (z + 1);
                player.GetComponent<TeamInfo>().teamInfo.text = "Team " + (i + 1);
            }
        }

        currentPlayer = _teams[0][0];
        _cameraMovement.SetCamera();
        currentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>().enabled = true;
        currentPlayer.GetComponent<Movement>().enabled = true;
    }

    public void GoToNextPlayer()
    {
        var shoot = currentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>();
        shoot.enabled = false;
        shoot.hasShot = false;
        _movement[currentTeam][currentPlayerFromTeam[currentTeam]].enabled = false;
        NextPlayerInTeam();
        NextTeam();
        _cameraMovement.SetCamera();
        _movement[currentTeam][currentPlayerFromTeam[currentTeam]].enabled = true;
        shoot.enabled = true;
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