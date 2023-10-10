using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : State
{

    public Chase(AI _FSMnew) : base(_FSMnew)
    {
        
    }
    
    public override void OnUpdate()
    {
        OnEnter();
        ChaseTarget();

        MakeTransition();
    }

    public override void MakeTransition()
    {
        if (!AI.InChaseRange && AI.currentBattery>75f)
        {
            AI.ChangeState(new Patrol(AI,10f));
        }
        if (AI.currentBattery<20)
        {
            AI.ChangeState(new Charge(AI));
        }
    }
    
    private void ChaseTarget()
    {
        if (AI.InChaseRange)
        {

            AI.Agent.stoppingDistance = 5f;
            AI.Agent.SetDestination(AI.Target.position);
            
        }
    }
    
}
