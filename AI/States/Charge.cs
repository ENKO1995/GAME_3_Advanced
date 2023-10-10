using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : State
{
    bool isDone;
    
    public Charge(AI _FSMnew) : base(_FSMnew)
    {
        
    }
    
    public override void MakeTransition()
    {
        if (!AI.isCharging)
        {
            AI.ChangeState(new Patrol(AI, AI.Speed));
        }
    }

    public override void OnUpdate()
    {
        GoToStation();
        Charging();
        MakeTransition();
        
    }
   
   private void GoToStation()
    {
        if (!isDone)
        {
            AI.Agent.stoppingDistance = 0;
            AI.Agent.SetDestination(AI.ChargingStation.transform.position);
            Debug.Log(AI.transform.position);
            isDone = !isDone;
        }
    }
    
    
    private void Charging()
    {
        AI.isCharging = true;
        AI.currentBattery += 2 * Time.deltaTime;
        if (AI.currentBattery >= 100)
        {
            AI.currentBattery = AI.MaxBattery;
            AI.isCharging = false;
        }
    }
}
