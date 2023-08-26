using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ShootingSystem;
    [SerializeField]
    private Transform BulletSpawnPoint;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;
    [SerializeField]
    private TrailRenderer BulletTrail;
    [SerializeField]
    private float ShootDelay = 0.1f;
    [SerializeField]
    private float Speed = 50;
    [SerializeField]
    private LayerMask Mask;
    //private LayerMask TowerMask;
    [SerializeField]
    private bool BouncingBullets;
    [SerializeField]
    private float BounceDistance = 10f;

    private float LastShootTime;

    public AudioSource deflectionSound;
    public AudioSource laserShootSound,bulletShootSound;
    public bool isPinkEnemy;

    void playShootSound()
    {
        if (isPinkEnemy)
        {
            laserShootSound.Play();

        }
        else
        {
            bulletShootSound.Play();
        }
    }

    private void Start()
    {
        laserShootSound = GameObject.Find("LaserAudioSrc").GetComponent<AudioSource>();
        bulletShootSound = GameObject.Find("BulletAudioSrc").GetComponent<AudioSource>();
        deflectionSound = GameObject.Find("DeflectionAudioSrc").GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        if (LastShootTime + ShootDelay < Time.time)
        {

            if(isPinkEnemy)
            {
                laserShootSound.Play();

            }
            else
            {
                bulletShootSound.Play();
            }

            ShootingSystem.Play();

            Vector3 direction = transform.forward;
            TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);


            if (Physics.Raycast(BulletSpawnPoint.position, direction, out RaycastHit hit, float.MaxValue, Mask))
            {
                StartCoroutine(SpawnTrail(trail, hit.point, hit.normal, BounceDistance, true));
            }
            else
            {
                StartCoroutine(SpawnTrail(trail, BulletSpawnPoint.position + direction * 100, Vector3.zero, BounceDistance, false));
                deflectionSound.Play();
            }

            LastShootTime = Time.time;
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, Vector3 HitPoint, Vector3 HitNormal, float BounceDistance, bool MadeImpact)
    {

        Vector3 startPosition = Trail.transform.position;
        Vector3 direction = (HitPoint - Trail.transform.position).normalized;

        float distance = Vector3.Distance(Trail.transform.position, HitPoint);
        float startingDistance = distance;

        while (distance > 0)
        {
            Trail.transform.position = Vector3.Lerp(startPosition, HitPoint, 1 - (distance / startingDistance));
            distance -= Time.deltaTime * Speed;

            yield return null;
        }

        Trail.transform.position = HitPoint;

        if (MadeImpact)
        {
            Instantiate(ImpactParticleSystem, HitPoint, Quaternion.LookRotation(HitNormal));

            if (BouncingBullets && BounceDistance > 0)
            {
                Vector3 bounceDirection = Vector3.Reflect(direction, HitNormal);

                if (Physics.Raycast(HitPoint, bounceDirection, out RaycastHit hit, BounceDistance, Mask))
                {

                    

                    yield return StartCoroutine(SpawnTrail(
                        Trail,
                        hit.point,
                        hit.normal,
                        BounceDistance - Vector3.Distance(hit.point, HitPoint),
                        true
                    ));
                }
                else
                {
                    yield return StartCoroutine(SpawnTrail(
                        Trail,
                        HitPoint + bounceDirection * BounceDistance,
                        Vector3.zero,
                        0,
                        false
                    ));
                }
            }
        }

        Destroy(Trail.gameObject, Trail.time);
    }
}
