using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class EnemyFollow : MonoBehaviour
{

    protected Animator enemyAnim;

    private float speed = 200f;

    private int runSpeed = 4;
    public float nextWaypointDistance = 4f;

    public float stoppingDistance = 3;
    public float attackDistance = 10;

    private Destructable destructableTarget;

    protected Transform target;
    private Transform playerTarget;

    private Rigidbody2D enemyRb;
    //poot added for melee calculations
    //public Vector2 _target;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    //shooting variables
    private float lastAttackTime;
    private float attackDelay = 1;
    

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

    protected virtual void FixedUpdate()
    {

        
        Move();

    }

    protected virtual void Move()
    {

        SetTarget();
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
            Vector2 force = (direction * speed * Time.deltaTime).normalized;

            //enemyRb.AddForce(force);
            enemyRb.velocity =  runSpeed * force;

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
            
            //enemyAnim.SetBool("IsWalk", Math.Abs(force.sqrMagnitude) > Mathf.Epsilon);
            enemyAnim.SetBool("IsWalk", true);
            enemyAnim.SetBool("IsAttack", false);
        }
        else
        {   
            if(Time.time > lastAttackTime + attackDelay)
            {
                Attack();
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

    void SetTarget()
    {
        destructableTarget = FindClosestTarget();
        if (Vector2.Distance(transform.position, playerTarget.position) > (attackDistance))
        {
            target = destructableTarget.GetComponent<Transform>();
            //_target = new Vector2(target.x, target.y).normalized;
        }
        else
        {
            target = playerTarget;
        }
    }

    protected virtual void Attack()
    {
        enemyAnim.SetBool("IsWalk", false);
        enemyAnim.SetBool("IsAttack", true);
        Debug.Log("hes a shootin");
    }
}

