using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Reaper : MonoBehaviour
{
    public Enemy enemy;

    public float stunTimeLength = 2.0f;
    private float stunTime;

    private Enemy.EnemyState priorStunState = Enemy.EnemyState.Idle;

    public float increaseBatteryDrainAmount = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (enemy.state)
        {
            case Enemy.EnemyState.Idle:
                Idle();
                break;
            case Enemy.EnemyState.Patrol:
                Patrol();
                break;
            case Enemy.EnemyState.Search:
                Search();
                break;
            case Enemy.EnemyState.Alert:
                Alert();
                break;
            case Enemy.EnemyState.CaughtObject:
                CaughtObject();
                break;
            case Enemy.EnemyState.Stunned:
                Stunned();
                break;

        }
    }

    public void Idle()
    {
        if (enemy.vision.playerSeen)
        {
            enemy.state = Enemy.EnemyState.Alert;
        }
    }
    public void Patrol()
    {
        if (enemy.navigation.canMove)
        {
            if (enemy.vision.playerSeen)
            {
                enemy.state = Enemy.EnemyState.Alert;
            }
            else
            {
                if (Vector3.Distance(enemy.navigation.targetWaypoint.transform.position, this.transform.position) < 1.5f)
                {
                    enemy.navigation.FindNextWaypoint();
                }
                else
                {
                    if (enemy.navigation.targetWaypoint == null)
                    {

                        enemy.navigation.FindNextWaypoint();
                    }
                    //Debug.Log("Distance to Waypoint: " + Vector3.Distance(this.transform.position, enemy.navigation.targetPosition));
                    enemy.navigation.MoveToWaypoint(enemy.navigation.targetWaypoint, enemy.moveSpeed);
                }
            }
        }
        
    }
    public void Search()
    {

    }
    public void Alert()
    {
        if (enemy.vision.playerSeen)
        {
            if (Vector3.Distance(enemy.vision.targetSeenPosition, this.transform.position) > 1f)
            {
                enemy.navigation.targetPosition = enemy.vision.targetSeenPosition;
                enemy.navigation.MoveToPosition(enemy.navigation.targetPosition, enemy.moveSpeed);
            } else
            {
                AttemptCatchObject();
            }
        } else
        {
            if (enemy.navigation.DistanceToTarget(this.transform.position) > 1f)
            {
                enemy.navigation.targetPosition = enemy.vision.targetLastSeenPosition;
                enemy.navigation.MoveToPosition(enemy.navigation.targetPosition, enemy.moveSpeed);
            }
        }
    }
    public void CaughtObject()
    {

    }

    public void Stunned()
    {
        if (stunTime > 0)
        {
            stunTime -= Time.deltaTime;
            Player p = FindObjectOfType<Player>();
            p.flashlight.increaseDrainAmount = increaseBatteryDrainAmount;
            p.flashlight.increaseBatteryDrain = true;
        } else
        {
            enemy.state = priorStunState;
            FindObjectOfType<Player>().flashlight.increaseBatteryDrain = false;
        }
    }

    public void AttemptCatchObject()
    {
        Debug.Log("Attempting to Catch Target");
    }

    public void LightStun()
    {
        stunTime = stunTimeLength;
        if (enemy.state != Enemy.EnemyState.Stunned)
        {
            priorStunState = enemy.state;
        }
        enemy.state = Enemy.EnemyState.Stunned;

        //Debug.Log("Hit with light");
    }
}
