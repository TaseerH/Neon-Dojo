using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerTower : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;

    public GameObject GameOver;

    void Start() {
        currentHealth = maxHealth;
        healthbar.setMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int damage) {
        currentHealth -= damage;
        healthbar.setHealth(currentHealth);

        if (currentHealth <= 0) {
            GameOver.SetActive(true);
            Time.timeScale = 0;
            GameObject.Destroy(gameObject, 0.5f);
        }
    }
}
