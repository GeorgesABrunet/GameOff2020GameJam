using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{

    private const float speed = 40f;
    private Enemy enemy;
    private int currentPathIndex;
    private List<Vector3> pathVectorList;

    private float pathfindingTimer;
    private Vector3 moveDirection;
    private Vector3 lastMoveDirection;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    
    // Update is called once per frame
    void Update()
    {
        pathfindingTimer -= Time.deltaTime;
        HandleMovement();
    }

    private void HandleMovement()
    {
       
        if (pathVectorList != null)
        {
            Vector3 targetPosition = pathVectorList[currentPathIndex];
            float reachedTargetDistance = 5f;
            if (Vector3.Distance(GetPosition(), targetPosition) > reachedTargetDistance)
            {
                moveDirection = (targetPosition - GetPosition()).normalized;
                lastMoveDirection = moveDirection;
                enemy.CharacterAnims.PlayMoveAnim(moveDirection);
                float distanceBefore = Vector3.Distance(transform.position, targetPosition);
                animatedWalker.SetMoveVector(moveDirection);
                transform.position = transform.position + moveDirection * speed * Time.deltaTime;
            }
            else
            {
                currentPathIndex++;
                if (currentPathIndex >= pathVectorList.Count)
                {
                    StopMoving();
                    animatedWalker.SetMoveVector(Vector3.zero);
                }
            }
        }
    }

    private void StopMoving()
    {
        pathVectorList = null;
        moveDirection = Vector3.zero
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = Pathfinding.Instance.FindPath(GetPosition(), targetPosition);


        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }
    }
}
