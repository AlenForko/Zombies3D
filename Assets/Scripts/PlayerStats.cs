using System.Collections;
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

    public Movement movement;
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
        animator.SetTrigger("isHit");
    }
    
    IEnumerator Death()
    {
        isDead = true;
        animator.SetBool("isDead", isDead);
        yield return new WaitForSeconds(5f);

        for (int i = 0; i < GameManager.teams.Count; i++)
        {
            GameManager.teams[i].Remove(this.gameObject);
            GameManager._movement[i].Remove(movement);
        }

        GameManager.CheckTeamCount();
        if (GameManager.currentPlayerFromTeam[teamNumber] > 0)
        {
            GameManager.currentPlayerFromTeam[teamNumber]--;
        }
        Destroy(gameObject);
    }
}
