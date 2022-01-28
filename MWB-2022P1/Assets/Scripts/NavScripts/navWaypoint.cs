using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navWaypoint : MonoBehaviour
{
    public navWaypoint nextWaypoint;
    public navWaypoint prevWaypoint;

    public bool endOfPath;

    private void OnDrawGizmosSelected()
    {
        if (nextWaypoint != null)
            Debug.DrawLine(this.transform.position, nextWaypoint.transform.position, Color.green);
        if (prevWaypoint != null)
            Debug.DrawLine(this.transform.position, prevWaypoint.transform.position, Color.yellow);
    }

}
