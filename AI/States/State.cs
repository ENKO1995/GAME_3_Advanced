using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State 
{
    protected AI AI;
    public State(AI _EnemyFsm)
    {
        this.AI = _EnemyFsm;
    }
  public virtual void OnEnter()
    {

    }

    public abstract void OnUpdate();

    public virtual void OnExit()
    {

    }

    public abstract void MakeTransition();
}
