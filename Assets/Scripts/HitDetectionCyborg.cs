using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionCyborg : MonoBehaviour
{
    public HealthController tower;
    public HealthController BulletShooter;
    public HealthControllerWall MetalWall;

    private void LateUpdate()
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
        if (collision.gameObject.CompareTag("BulletShooter"))
        {
            Debug.Log("Collision with BulletShooter");
            BulletShooter = collision.gameObject.GetComponent<HealthController>();
            BulletShooter.TakeDamage(100);
            Destroy(this.gameObject, 0.01f);
        }
        if (collision.gameObject.CompareTag("MetalWall"))
        {
            Debug.Log("Collision with MetalWall");
            MetalWall = collision.gameObject.GetComponent<HealthControllerWall>();
            MetalWall.TakeDamage(50);
            Destroy(this.gameObject, 0.01f);
        }

    }
}