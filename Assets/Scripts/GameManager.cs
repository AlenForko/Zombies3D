using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private GameObject playerPrefabs;
    [SerializeField] private CameraMovement _cameraMovement;
   
    private PlayerStats _playerStats;
    public GameObject[] startPoints;
    public static GameObject currentPlayer; 
    public static int _currentTeam;
    public static bool playerSwitched;

    public static List<int> currentPlayerFromTeam;
    public static List<List<Movement>> _movement;
    public static List<List<GameObject>> teams;

    private void Start()
    {
        PauseMenu.gameIsPaused = false;
        _currentTeam = 0;
        currentPlayerFromTeam = new List<int>();
        _movement = new List<List<Movement>>();
        teams = new List<List<GameObject>>();
        
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            teams.Add(new List<GameObject>());
            _movement.Add(new List<Movement>()); 
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
                teams[i].Add(player);
                _movement[i].Add(player.GetComponent<Movement>());
                player.GetComponent<PlayerStats>().teamNumber = i;
                player.GetComponent<PlayerStats>().zombieNumber = z;
                
                player.GetComponent<TeamInfo>().playerInfo.text = "Zombie " + (z + 1);
                player.GetComponent<TeamInfo>().teamInfo.text = "Team " + (i + 1);
                
                player.GetComponent<Movement>().animator = player.GetComponentInChildren<Animator>();
                player.GetComponent<PlayerStats>().animator = player.GetComponentInChildren<Animator>();
            }        
        }
        currentPlayer = teams[0][0];
        _cameraMovement.SetCamera();
        currentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>().enabled = true;
        currentPlayer.GetComponent<Movement>().enabled = true;
    }

    private void Update()
    {
        //Move to calling only on death of Zombie
        if (teams.Count == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GoToNextPlayer()
    {
        //Disable components for current player.
        Shooting shoot = currentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>();
        shoot.enabled = false; 
        shoot.hasShot = false;

        Movement currentMovement = _movement[_currentTeam][currentPlayerFromTeam[_currentTeam]];
        currentMovement.enabled = false;
        currentMovement.animator.SetBool("isMoving", false);
        playerSwitched = false;
         
        //Change player.
        NextPlayerInTeam();
        NextTeam();

        //Enable components for next player.
        _cameraMovement.SetCamera(); 
        _movement[_currentTeam][currentPlayerFromTeam[_currentTeam]].enabled = true;
        _movement[_currentTeam][currentPlayerFromTeam[_currentTeam]].animator.SetBool("isMoving", true);
        var shooting = currentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>();
        shooting.enabled = true;
        playerSwitched = true;
    }

    void NextTeam()
    {
        _currentTeam++;

        if (_currentTeam >= teams.Count)
        {
            _currentTeam %= teams.Count;
        }
        
        currentPlayer = teams[_currentTeam][currentPlayerFromTeam[_currentTeam]];
    }

    void NextPlayerInTeam()
    {
        currentPlayerFromTeam[_currentTeam]++;

        if (currentPlayerFromTeam[_currentTeam] >= teams[_currentTeam].Count)
        {
            currentPlayerFromTeam[_currentTeam] %= teams[_currentTeam].Count;
        }
        
        currentPlayer = teams[_currentTeam][currentPlayerFromTeam[_currentTeam]];
    }

    public static void CheckTeamCount()
    {
        for (int i = 0; i < teams.Count; i++)
        {
            if (teams[i].Count==0)
            {
                teams.RemoveAt(i);
                _movement.RemoveAt(i);
                _currentTeam--;
                if (_currentTeam < 0)
                {
                    _currentTeam = 0;
                }
            }
        }
    }
}