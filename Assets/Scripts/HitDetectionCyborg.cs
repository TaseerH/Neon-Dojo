using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionCyborg : MonoBehaviour
{
    public HealthControllerTower tower;
    public HealthController BulletShooter;
    public HealthControllerWall MetalWall;
    public ParticleSystem bulletShooterDieEffect;
    private Transform bulletShooterTransform;
    public AudioSource bulletShooterDieSound;

    private void LateUpdate()
    {
        tower = GameObject.Find("Tower").GetComponent<HealthControllerTower>();
        bulletShooterDieSound = GameObject.Find("EnemyDieAudioSrc").GetComponent<AudioSource>();
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Collision with tower");
            tower.TakeDamage(10);
            Destroy(this.gameObject, 0.01f);
        }
        if (collision.gameObject.CompareTag("BulletShooter"))
        {
            Debug.Log("Collision with BulletShooter");
            BulletShooter = collision.gameObject.GetComponent<HealthController>();
            bulletShooterTransform = collision.gameObject.GetComponent<Transform>();
            Debug.Log("Found Enemy Health Controller");
            BulletShooter.TakeDamage(100);
            
            bulletShooterDieSound.Play();
            
            Debug.Log("bullet shooter dead");
            //Destroy(bulletShooterDieEffect.gameObject);
            Destroy(this.gameObject, 0.05f);
        }
        if (collision.gameObject.CompareTag("MetalWall"))
        {
            Debug.Log("Collision with MetalWall");
            MetalWall = collision.gameObject.GetComponent<HealthControllerWall>();
            MetalWall.TakeDamage(10);
            Destroy(this.gameObject, 0.01f);
        }

    }
}
