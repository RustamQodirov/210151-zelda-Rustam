

using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    public HealthBar healthBar;



    private int _currentHealth;

    private int CurrentHealth
    {
        get => this._currentHealth;
        set
        {
            
            this._currentHealth = value;
            
            if (CurrentHealth <= 0) // Did we die?
            {
                // Let onDeath event listeners know that we died. 
                this.onDeath.Invoke();
                GameManager.Instance.updateKills();
                // Destroy ourselves.
                Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        healthBar.SetMaxHealth(startingHealth);
        ResetHealthToStarting();
    }

    public void ResetHealthToStarting()
    {
        CurrentHealth = this.startingHealth;
    }

    public void ApplyDamage(int damage)
    {
        CurrentHealth -= damage;
        healthBar.SetHealth(this._currentHealth);
    }
}
