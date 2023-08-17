
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Gun Gun;

    public NavMeshAgent agent;

    public Transform player;
    public GameObject gun;

    //Stats
    public int health;

    //Check for Ground/Obstacles
    public LayerMask whatIsGround, whatIsTower;

    //Patroling
    public Vector3 walkPoint;
    public bool walkPointSet;
    public float walkPointRange;

    //Attack Player
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public bool isDead;
    public float attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //Special
    public Material green, red, yellow;
    public GameObject projectile;

    private Animator enemyAnimator;
    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
        player = GameObject.Find("Tower").transform;
        agent = GetComponent<NavMeshAgent>();
        attackRange = Random.Range(30f, 60f);
    }
    private void Update()
    {
        if (!isDead)
        {
            //Check if Player in sightrange
            // playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsTower);
            playerInSightRange = true;
            //Check if Player in attackrange
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsTower);

            if (playerInSightRange && !playerInAttackRange) ChasePlayer();
            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawSphere(transform.position, attackRange);
    //}


    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        if (isDead) return;

        agent.SetDestination(player.position);
       // enemyAnimator.SetTrigger("EnemyRifleRun");
        // GetComponent<MeshRenderer>().material = yellow;
    }

    private void AttackPlayer()
    {
        if (isDead) return;

        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);
        //Debug.Log("player in attack range.");

        transform.LookAt(player);
        enemyAnimator.SetTrigger("ShootNow");
        

        
            Gun.Shoot();
        
        /*  if (!alreadyAttacked)
          {

              //Attack
              Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

              rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
              rb.AddForce(transform.up * 8, ForceMode.Impulse);

              alreadyAttacked = true;
              Invoke("ResetAttack", timeBetweenAttacks);
         }*/

        //GetComponent<MeshRenderer>().material = red;
    }
}




