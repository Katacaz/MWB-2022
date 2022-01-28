using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public enum EnemyState
    {
        Idle,
        Patrol,
        Search,
        Alert,
        CaughtObject,
        Stunned
    }
    public EnemyState state = EnemyState.Idle;

    public Enemy_Navigation navigation;
    public Enemy_Vision vision;
    public float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case EnemyState.Idle:
                Idle();
                break;
            case EnemyState.Patrol:
                Patrol();
                break;
            case EnemyState.Search:
                Search();
                break;
            case EnemyState.Alert:
                Alert();
                break;
            case EnemyState.CaughtObject:
                CaughtObject();
                break;
            case EnemyState.Stunned:
                Stunned();
                break;

        }
    }

    public void Idle()
    {
        vision.canSee = true;
    }
    public void Patrol()
    {
        navigation.agent.speed = moveSpeed;
        vision.canSee = true;
    }
    public void Search()
    {

    }
    public void Alert()
    {

    }
    public void CaughtObject()
    {

    }
    public void Stunned()
    {
        navigation.agent.speed = 0;
        vision.canSee = false;
    }
}
