using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerWall : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //public HealthBar healthbar;

    void Start() {
        currentHealth = maxHealth;
        //healthbar.setMaxHealth(maxHealth);
    }

    

    public void TakeDamage (int damage) {
        currentHealth -= damage;
        //healthbar.setHealth(currentHealth);

        if (currentHealth <= 0) {
            GameObject.Destroy(this.gameObject);
        }
    }
}
