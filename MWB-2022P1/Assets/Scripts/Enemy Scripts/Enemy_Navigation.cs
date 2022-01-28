using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Navigation : MonoBehaviour
{
    public NavMeshAgent agent;
    public navPath path;
    public navWaypoint targetWaypoint;

    public Vector3 targetPosition = Vector3.zero;

    public bool canMove;

    public bool pathForwards;
    // Start is called before the first frame update
    void Start()
    {
        //targetWaypoint = path.FindClosestWaypoint(this.transform.position);
    }

    public void MoveToPosition(Vector3 position, float speed)
    {
        if (canMove)
        {
            agent.speed = speed;
            agent.SetDestination(position);
            
        }
    }
    public void MoveToWaypoint(navWaypoint waypoint, float speed)
    {
        if (canMove)
        {
            agent.speed = speed;
            agent.SetDestination(waypoint.transform.position);
        }
    }

    public float DistanceToTarget(Vector3 position)
    {
        return Vector3.Distance(position, targetPosition);
    }

    public void FindNextWaypoint()
    {
        //Debug.Log("Finding Next Waypoint");

        if (pathForwards)
        {
            if (targetWaypoint.endOfPath)
            {
                targetWaypoint = path.FindPrevWaypoint(targetWaypoint);
                pathForwards = false;
            }
            else
            {
                targetWaypoint = path.FindNextWaypoint(targetWaypoint);
            }
            //targetPosition = targetWaypoint.transform.position;
            //targetPosition = (path.FindNextWaypoint(path.FindClosestWaypoint(this.transform.position))).transform.position;
        } else
        {
            if (targetWaypoint.endOfPath)
            {
                targetWaypoint = path.FindNextWaypoint(targetWaypoint);
                pathForwards = true;
            }
            else
            {
                targetWaypoint = path.FindPrevWaypoint(targetWaypoint);
            }
            
            //targetPosition = (path.FindPrevWaypoint(path.FindClosestWaypoint(this.transform.position))).transform.position;
        }
    }


}
