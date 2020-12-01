using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class EnemyFollow : MonoBehaviour
{

    private Animator enemyAnim;

    private float speed = 200f;
    public float nextWaypointDistance = 4f;

    public float stoppingDistance = 3;
    public float attackDistance = 10;

    private Destructable destructableTarget;

    private Transform target;
    private Transform playerTarget;

    private Rigidbody2D enemyRb;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    //shooting variables
    private float lastAttackTime;
    private float attackDelay = 1;

    public int damage = 20;
    public GameObject bullet;
    public float bulletForce;
    public Transform enemyShotPoint;
    public Transform gun;
    Vector2 gunDirection;
    

    private List<Vector3> pathVectorList;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyAnim = GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SetTarget();
        enemyRb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .1f);

    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(enemyRb.position, target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
            destructableTarget = FindClosestTarget();
            SetTarget();
        }
    }

    void FixedUpdate()
    {

        SetTarget();
        AimGun();
        
        //target = playerTarget;
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            if (path == null)
            {
                return;
            }
            if (currentWaypoint >= path.vectorPath.Count)
            {
                reachedEndOfPath = true;
                return;
            }
            else
            {
                reachedEndOfPath = false;
            }
            
            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - enemyRb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            enemyRb.AddForce(force);

            float distance = Vector2.Distance(enemyRb.position, path.vectorPath[currentWaypoint]);
            //transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);

            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
            if (target.position.x < transform.position.x)
            {
                transform.eulerAngles = new Vector2(0, 0);

            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            enemyAnim.SetBool("IsWalk", true);
        }
        else
        {
            
            enemyAnim.SetBool("IsWalk", false);
            
            if(Time.time > lastAttackTime + attackDelay)
            {
                Shoot();
                lastAttackTime = Time.time;
            }

        }

    }

    private Destructable FindClosestTarget()
    {
        float distanceToClosestTarget = Mathf.Infinity;
        Destructable closestTarget = null;
        Destructable[] allTargets = GameObject.FindObjectsOfType<Destructable>();

        foreach (Destructable currentTarget in allTargets)
        {
            float distanceToTarget = (currentTarget.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToTarget < distanceToClosestTarget)
            {
                distanceToClosestTarget = distanceToTarget;
                closestTarget = currentTarget;
            }
        }

        Debug.DrawLine(this.transform.position, closestTarget.transform.position);

        return closestTarget;
    }

    void Shoot()
    {
        Vector3 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        
        GameObject newBullet = Instantiate(bullet, enemyShotPoint.position, q);

    }
    void AimGun()
    {
        Vector3 gunDirection = (target.position - gun.position).normalized;
        float angle = Mathf.Atan2(gunDirection.y, gunDirection.x) * Mathf.Rad2Deg;
        gun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (gunDirection.x < gun.position.x)
        {
            gun.rotation = Quaternion.Euler(0, 180, (90-angle));
        }
    }

    void SetTarget()
    {
        destructableTarget = FindClosestTarget();
        if (Vector2.Distance(transform.position, playerTarget.position) > (attackDistance))
        {
            target = destructableTarget.GetComponent<Transform>();
        }
        else
        {
            target = playerTarget;
        }
    }
}

