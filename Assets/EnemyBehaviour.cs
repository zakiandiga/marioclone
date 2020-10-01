using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    private EnemyState enemyState = EnemyState.patrol;

    public enum EnemyState
    {
        patrol,
        chase,
        rest,
    }

    [SerializeField] private float maxPatrolSlot = 3;
    private float patrolSlot;

    [SerializeField] private float chaseCooldown = 3;
    [SerializeField] private float patrolCooldown = 6;

    //List of command from command from static NPCBehaviorCommand
    private MoveLeft moveLeft;
    private MoveRight moveRight;


    private List<Command> patrolingBehaviorCommands = new List<Command>();
    private List<Command> chaseBehaviorCommands = new List<Command>();



    void Start()
    {
        
        moveLeft = new moveLeft();
        moveRight = new moveRight();

        //add behavior to command list
        patrolingBehaviorCommands.Add(moveLeft);
        patrolingBehaviorCommands.Add(moveLeft);
        patrolingBehaviorCommands.Add(moveLeft);
        patrolingBehaviorCommands.Add(moveLeft);
        patrolingBehaviorCommands.Add(moveRight);


    }

    //PATROL BEHAVIOUR
    private void EnemyPatrol()
    {
        if (enemyState != EnemyState.chase)
        {
            //while()
        }
        if (currentPatrol > 0)
        {
            StartCoroutine("EnemyPatrolling");
        }
        if(currentPatrol <= 0)
        {
            //Go to EnemyState.rest
        }
    }

    IEnumerator EnemyPatroling()
    {
        patrolTime = Random.Range(5, 7); 
        Debug.Log("I'm patrolling, patrol slot remaining is " + patrolSlot);
        //Patrol movements
        //execute patrolling commands

        yield return new WaitForSeconds(patrolTime);
        Debug.Log("Start over patrolling");

        if (patrolSlot <= 0 && enemyState != EnemyState.chase)
        {
            enemyState = EnemyState.rest;
            Debug.Log("Go rest");
            DoRest();
        }

    }

    //Chase condition
    void OnTriggerEnter2D (Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            enemyState = EnemyState.chase;
            DoChase();
        }
    }

    //REST STATE//
    private void DoRest()
    {

    }
    //cool down for ready to chase
    //cool down for back to patrol

    



    void Update()
    {
        /*
        switch (enemyState) //Should we use switch??
        {
            case enemytates.patrol:
                //repeating behavior       

                //state change conditions:
                if (playerNotified) //CONDITION THAT CHANGE TO CHASE
                {
                    enemyState = EnemyState.chase;
                }

                else if () //SWITCH TO REST

                    break;

            case enemyState.chase:
                //repeating behavior

                //state change conditions:
                if () // CONDITION THAT CHANGE STATE BACK TO PATROL
                {
                    enemyState = EnemyState.patrol;
                }
                break;

            case PlayerStates.rest:
                //repeating behavior

                if () //CONDITION THAT CHANGE STATE TO PATROL
                {
                    enemyState = EnemyState.patrol;
                }
                else if () //CONDITION THAT CHANGE STATE TO CHASE
                {
                    enemyState = EnemyState.chase;
                }
                break;

            default:
                break;
        }
        */
    }

}
