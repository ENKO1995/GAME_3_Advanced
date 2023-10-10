using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : State
{
    float distance;
    float speed;
    bool isDone;
    
    public Patrol(AI AI , float _speed) : base(AI)
    {
        this.speed = _speed;
    }
    public override void OnEnter()
    {
        
        AI.Agent = AI.GetComponent<NavMeshAgent>();
        Debug.Log("Patrol");
    }
    public override void OnUpdate()
    {
        //NPC patrol
        if (!AI.walkPointSet)
        {
            SearchWalkPoint();
        }

        if (AI.walkPointSet)
        {
            AI.Agent.SetDestination(AI.WalkPoint);
        }

        Vector3 distance = AI.transform.position - AI.WalkPoint;
        if (distance.magnitude < 1f)
        {
            AI.walkPointSet = false;
        }
        MakeTransition();
    }


    private void SearchWalkPoint()
    {
        //Set random WalkPoint
        float randomZ = UnityEngine.Random.Range(-AI.SightRange, AI.SightRange);
        float randomX = UnityEngine.Random.Range(-AI.SightRange, AI.SightRange);

        AI.WalkPoint = new Vector3(AI.transform.position.x + randomX, AI.transform.position.y, AI.transform.position.z + randomZ);

        
            if (Physics.Raycast(AI.WalkPoint, -AI.transform.up,2f,AI.IsGround))
                AI.walkPointSet = true;
    }
    

    public override void OnExit()
    {
        base.OnExit();
    }

    public bool CheckChaseRange()
    {
        float distance = Vector3.Distance(AI.Target.position, AI.Agent.transform.position);
        if (distance <= AI.ChaseRange)
        {
            AI.InChaseRange = true;
        }
        Debug.Log(AI.InChaseRange);
        return AI.InChaseRange;
    }

    public override void MakeTransition()
    {
        
        
            if (CheckChaseRange() == true)
            {
                AI.ChangeState(new Chase(AI));
            }


            if (AI.currentBattery < 20)
            {
                AI.ChangeState(new Charge(AI));
            }
        
        

    }
}
