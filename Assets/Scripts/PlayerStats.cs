using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public bool isDead;

    public Animator animator;

    public int teamNumber;
    public int zombieNumber;
    
    private void Start()
    {
        currentHealth = maxHealth;
        
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        
        healthBar.SetHealth(currentHealth);
    }
    
    IEnumerator Death()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        yield return new WaitForSeconds(3f);

        //_gameManager.RemovePlayerFromTeam(teamNumber);
        //_gameManager.teams[teamNumber].Find(this.gameObject);
        GameManager.teams[teamNumber].Remove(this.gameObject);
        Destroy(gameObject);
    }
}
