using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navPath : MonoBehaviour
{
    public navWaypoint[] waypoints;

    public navWaypoint FindNextWaypoint(navWaypoint wP)
    {
        navWaypoint nextWP = waypoints[0];
        if (wP.nextWaypoint != null)
        {
            nextWP = wP.nextWaypoint;
        }
        return nextWP;
    }
    public navWaypoint FindPrevWaypoint(navWaypoint wP)
    {
        navWaypoint prevWP = waypoints[waypoints.Length - 1];
        if (wP.prevWaypoint != null)
        {
            prevWP = wP.prevWaypoint;
        }
        return prevWP;
    }

    public navWaypoint FindClosestWaypoint(Vector3 pos)
    {
        navWaypoint waypoint = waypoints[0];
        float shortestDistance = Vector3.Distance(waypoint.transform.position, pos);
        for (int i = 0; i < waypoints.Length; i++)
        {
            float newDistance = Vector3.Distance(waypoint.transform.position, waypoints[i].transform.position);
            if (newDistance < shortestDistance)
            {
                shortestDistance = newDistance;
                waypoint = waypoints[i];
            }
        }

        return waypoint;
    }
    public navWaypoint FindFurthestWaypoint(Vector3 pos)
    {
        navWaypoint waypoint = waypoints[0];
        float furthestDistance = Vector3.Distance(waypoint.transform.position, pos);
        for (int i = 0; i < waypoints.Length; i++)
        {
            float newDistance = Vector3.Distance(waypoint.transform.position, waypoints[i].transform.position);
            if (newDistance > furthestDistance)
            {
                furthestDistance = newDistance;
                waypoint = waypoints[i];
            }
        }

        return waypoint;
    }
}
