using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        
        healthBar.SetHealth(currentHealth);
    }
}
