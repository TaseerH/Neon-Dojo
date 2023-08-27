using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionSoldier : MonoBehaviour
{
    public HealthControllerTower tower;
    public HealthController LaserShooter;
    public HealthControllerWall MirrorWall;
    public ParticleSystem laserShooterDieEffect;
    private Transform laserShooterTransform;
    public AudioSource laserShooterDieSound;

    private void Start()
    {
        tower = GameObject.Find("Tower").GetComponent<HealthControllerTower>();
        laserShooterDieSound = GameObject.Find("EnemyDieAudioSrc").GetComponent<AudioSource>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Collision with tower");
            tower.TakeDamage(10);
            Destroy(this.gameObject, 0.01f);
        }
        if (collision.gameObject.CompareTag("LaserShooter"))
        {
            Debug.Log("Collision with Laser Shooter");
            LaserShooter = collision.gameObject.GetComponent<HealthController>();
            laserShooterTransform = collision.gameObject.GetComponent<Transform>();
            Debug.Log("Found Enemy Health Controller");
            LaserShooter.TakeDamage(100);
            
            laserShooterDieSound.Play();
            
            Debug.Log("laser shooter dead");
            
            Destroy(this.gameObject, 0.05f);
        }
        if (collision.gameObject.CompareTag("MirrorWall"))
        {
            Debug.Log("Collision with MetalWall");
            MirrorWall = collision.gameObject.GetComponent<HealthControllerWall>();
            MirrorWall.TakeDamage(10);
            Destroy(this.gameObject, 0.01f);
        }

    }
}
