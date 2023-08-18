using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionSoldier : MonoBehaviour
{
    public HealthController tower;
    public HealthController LaserShooter;
    public HealthControllerWall MirrorWall;

    private void Start()
    {
        tower = GameObject.Find("Tower").GetComponent<HealthController>();
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Debug.Log("Collision with tower");
            tower.TakeDamage(5);
            Destroy(this.gameObject, 0.01f);
        }
        if (collision.gameObject.CompareTag("LaserShooter"))
        {
            Debug.Log("Collision with Laser Shooter");
            LaserShooter = collision.gameObject.GetComponent<HealthController>();
            LaserShooter.TakeDamage(100);
            Destroy(this.gameObject, 0.01f);
        }
        if (collision.gameObject.CompareTag("MirrorWall"))
        {
            Debug.Log("Collision with MetalWall");
            MirrorWall = collision.gameObject.GetComponent<HealthControllerWall>();
            MirrorWall.TakeDamage(50);
            Destroy(this.gameObject, 0.01f);
        }

    }
}
