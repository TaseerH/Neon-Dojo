using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthControllerWall : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isPinkWall;
    public ParticleSystem destroyPinkWallEffect, destroyYellowWallEffect;
    public AudioSource destroyPinkWallSound, destroyYellowWallSound;

    //public HealthBar healthbar;

    void Start() {
        currentHealth = maxHealth;
        destroyPinkWallSound= GameObject.Find("MirrorBreakAudioSrc").GetComponent<AudioSource>();
        destroyYellowWallSound = GameObject.Find("MetalBreakAudioSrc").GetComponent<AudioSource>();

        //healthbar.setMaxHealth(maxHealth);
    }



    public void TakeDamage (int damage) {
        currentHealth -= damage;
        //healthbar.setHealth(currentHealth);

        if (currentHealth <= 0) {
            GameObject.Destroy(this.gameObject);
            if (isPinkWall)
            {
                destroyPinkWallSound.Play();
                Instantiate(destroyPinkWallEffect.gameObject, transform.position, transform.rotation);
                Destroy(destroyPinkWallEffect.gameObject);
            }
            else
            {
                destroyYellowWallSound.Play();
                Instantiate(destroyYellowWallEffect.gameObject, transform.position, transform.rotation);
                Destroy(destroyYellowWallEffect.gameObject);
            }
        }
    }
}
