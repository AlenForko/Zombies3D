using System.Collections;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;

    public HealthBar healthBar;
    public bool isDead;

    public Animator animator;

    public int teamNumber;
    public int zombieNumber;

    private Movement _movement;
    private AudioSource _source;
    [SerializeField]private AudioClip[] _audioHurtClips, _audioDeathClips;
    private void Start()
    {
        _currentHealth = _maxHealth;
        _movement = GetComponent<Movement>();
        healthBar.SetMaxHealth(_maxHealth);
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_currentHealth <= 0)
        {
            StartCoroutine(Death());
        }

        if (Input.GetKey(KeyCode.F11))
        {
            _currentHealth = _maxHealth;
            healthBar.SetHealth(_currentHealth);
        }
    }

    public void TakeDamage()
    {
        _currentHealth -= Shooting.weaponDamage;
        
        healthBar.SetHealth(_currentHealth);
        animator.Play("Z_damage");
        HitSounds();
    }
    
    IEnumerator Death()
    {
        isDead = true;
        animator.Play("Z_death_A");
        DeathSounds();
        yield return new WaitForSeconds(2f);

        for (int i = 0; i < GameManager.teams.Count; i++)
        {
            GameManager.teams[i].Remove(this.gameObject);
            GameManager._movement[i].Remove(_movement);
        }

        GameManager.CheckTeamCount();
        if (GameManager.currentPlayerFromTeam[teamNumber] > 0)
        {
            GameManager.currentPlayerFromTeam[teamNumber]--;
        }
        Destroy(gameObject);
    }

    void HitSounds()
    {
        AudioClip clip = _audioHurtClips[Random.Range(0, _audioHurtClips.Length)];
        _source.PlayOneShot(clip);
    }

    void DeathSounds()
    {
        AudioClip deathclip = _audioDeathClips[Random.Range(0, _audioDeathClips.Length)];
        _source.PlayOneShot(deathclip);
    }
}
