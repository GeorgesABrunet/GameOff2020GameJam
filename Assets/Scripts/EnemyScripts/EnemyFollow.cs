using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Pathfinding;

public class EnemyFollow : MonoBehaviour
{

    private Animator enemyAnim;

    public float speed = 5f;
    public float nextWaypointDistance = 2f;

    public float stoppingDistance;
    public float attackDistance;

    private Destructable destructableTarget;

    private Transform target;
    private Transform playerTarget;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;


    private List<Vector3> pathVectorList;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        enemyAnim = GetComponent<Animator>();
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();


        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
        {
            seeker.StartPath(transform.position, target.position, OnPathComplete);
        }
    }

    void Update()
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
            Vector2 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            float distance = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);
            transform.position = Vector2.MoveTowards(transform.position, direction, speed * Time.deltaTime);

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
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
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


}

