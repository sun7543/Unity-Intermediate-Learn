using UnityEngine;
using UnityEngine.AI;

public class Roaming : State
{
    public Roaming(Enemy enemy, NavMeshAgent agent) : base(enemy, agent)
    {
        Name = STATE.ROAMING;
    }

    public override void Enter()
    {
        // How many location to patrol
        int locationQuantity = EnemyClass.ObserveLocation.Length;

        // We gonna go there
        Agent.SetDestination(SearchWaypoint(locationQuantity));

        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if(Agent.remainingDistance < .5f)
        {   
            // If remaning distance is less than 0.5m
            // Set NextState to Idle
            // And Change Stage to Exit
            // NextState = new Idle(EnemyClass, Agent);
            // State = EVENT.EXIT;

            // How many location to patrol
            int locationQuantity = EnemyClass.ObserveLocation.Length;

            // We gonna go there
            Agent.SetDestination(SearchWaypoint(locationQuantity));
        }

        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private Vector3 SearchWaypoint(int locationQuantity)
    {
        //Randont POIs (Point of interests)
        int index = Random.Range(0, locationQuantity);

        //Set estimate destination
        Vector3 destination = EnemyClass.ObserveLocation[index].position;

        /*
        Find if NavMesh exist on that postion or not
        If not find the closest one
        If there's no closest random another point
        */
        NavMeshHit hit;
        if(NavMesh.SamplePosition(destination, out hit, 1.0f, NavMesh.AllAreas))
        {
            destination = hit.position;
        }
        else
            destination = SearchWaypoint(locationQuantity);
        
        return destination;
    }
}
