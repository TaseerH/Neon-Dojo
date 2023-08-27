using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerTower : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthbar;
    public ParticleSystem towerDieEffect;
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
            GameObject.Destroy(gameObject, 0.5f);
            
            Instantiate(towerDieEffect.gameObject, new Vector3(transform.position.x, 15, transform.position.z), transform.rotation);
            towerDieEffect.Play();
            Debug.Log("Tower Dead");

            GameOver.SetActive(true);
            Time.timeScale = 0;

        }
    }


    
}
