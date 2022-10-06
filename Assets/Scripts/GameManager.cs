using System.Collections.Generic;
using Player;
using UI;
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
    
    public static GameObject CurrentPlayer; 
    public static int CurrentTeam;
    public static bool PlayerSwitched;
    public static List<int> CurrentPlayerFromTeam;
    public static List<List<Movement>> Movement;
    public static List<List<GameObject>> Teams;

    private void Start()
    {
        PauseMenu.GameIsPaused = false;
        CurrentTeam = 0;
        CurrentPlayerFromTeam = new List<int>();
        Movement = new List<List<Movement>>();
        Teams = new List<List<GameObject>>();
        
        //Checks for how many players are playing.
        for (int i = 0; i < PlayerAmounts.PlayerAmount; i++)
        {
            Teams.Add(new List<GameObject>());
            Movement.Add(new List<Movement>()); 
            CurrentPlayerFromTeam.Add(0);
            
            //Checks for zombies that the player has chosen and adds components to them.
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
                Teams[i].Add(player);
                Movement[i].Add(player.GetComponent<Movement>());
                
                player.GetComponent<PlayerStats>().teamNumber = i;
                player.GetComponent<PlayerStats>().zombieNumber = z;
                
                player.GetComponent<TeamInfo>().playerInfo.text = "Zombie " + (z + 1);
                player.GetComponent<TeamInfo>().teamInfo.text = "Team " + (i + 1);
                
                player.GetComponent<Movement>().animator = player.GetComponentInChildren<Animator>();
                player.GetComponent<PlayerStats>().animator = player.GetComponentInChildren<Animator>();
            }        
        }
        //Sets player 1 from team 1 as default.
        CurrentPlayer = Teams[0][0];
        _cameraMovement.SetCamera();
        CurrentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>().enabled = true;
        CurrentPlayer.GetComponent<Movement>().enabled = true;
    }

    private void Update()
    {
        //Move to winning scene when only 1 team left.
        if (Teams.Count == 1)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void GoToNextPlayer()
    {
        //Disable components for current player.
        Shooting shoot = CurrentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>();
        shoot.enabled = false; 
        shoot.hasShot = false;

        Movement currentMovement = Movement[CurrentTeam][CurrentPlayerFromTeam[CurrentTeam]];
        currentMovement.enabled = false;
        currentMovement.animator.SetBool("isMoving", false);
        PlayerSwitched = false;
         
        //Change player.
        NextPlayerInTeam();
        NextTeam();

        //Enable components for next player.
        _cameraMovement.SetCamera(); 
        Movement[CurrentTeam][CurrentPlayerFromTeam[CurrentTeam]].enabled = true;
        Movement[CurrentTeam][CurrentPlayerFromTeam[CurrentTeam]].animator.SetBool("isMoving", true);
        var shooting = CurrentPlayer.transform.GetChild(0).GetChild(2).GetComponent<Shooting>();
        shooting.enabled = true;
        PlayerSwitched = true;
    }

    void NextTeam()
    {
        CurrentTeam++;
        
        if (CurrentTeam >= Teams.Count)
        {
            CurrentTeam %= Teams.Count;
        }
        
        CurrentPlayer = Teams[CurrentTeam][CurrentPlayerFromTeam[CurrentTeam]];
    }

    void NextPlayerInTeam()
    {
        CurrentPlayerFromTeam[CurrentTeam]++;

        if (CurrentPlayerFromTeam[CurrentTeam] >= Teams[CurrentTeam].Count)
        {
            CurrentPlayerFromTeam[CurrentTeam] %= Teams[CurrentTeam].Count;
        }
        
        CurrentPlayer = Teams[CurrentTeam][CurrentPlayerFromTeam[CurrentTeam]];
    }

    public static void CheckTeamCount()
    {
        for (int i = 0; i < Teams.Count; i++)
        {
            if (Teams[i].Count==0)
            {
                Teams.RemoveAt(i);
                Movement.RemoveAt(i);
                CurrentTeam--;
                if (CurrentTeam < 0)
                {
                    CurrentTeam = 0;
                }
            }
        }
    }
}