using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isPinkEnemy;
    public ParticleSystem laserShooterDieEffect;
    public ParticleSystem bulletShooterDieEffect;
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
            
            if(isPinkEnemy)
            {
                Instantiate(laserShooterDieEffect.gameObject, new Vector3(transform.position.x, 5, transform.position.z), transform.rotation);
                laserShooterDieEffect.Play();
                Debug.Log("Laser Shooter Dead");
                //Destroy(laserShooterDieEffect.gameObject, 0.5f);
            } else
            {
                Instantiate(bulletShooterDieEffect.gameObject, new Vector3(transform.position.x, 5, transform.position.z), transform.rotation);
                bulletShooterDieEffect.Play();
                Debug.Log("Bullet Shooter Dead");
                //Destroy(bulletShooterDieEffect.gameObject, 0.5f);
            }

            GameObject.Destroy(gameObject, 0.1f);
        }
    }
}
