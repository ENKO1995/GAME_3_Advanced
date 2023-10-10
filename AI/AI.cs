using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [Header ("General")]
    private State currentState;
    public float Speed;

    public BatteryBar BatteryBar;
    public NavMeshAgent Agent;

    [Header("Patrol")]
    [SerializeField] 
    private float sightRange;
    public Transform Target;
    public bool walkPointSet= false;
    public Vector3 WalkPoint;
    public LayerMask IsGround,IsCharger;


    [Header("Chase")]
    [SerializeField]
    private float chaseRange;
    [SerializeField]
    public bool InChaseRange;


    [Header("Charge")]
    private float maxBattery = 100;
    [SerializeField]
    public float currentBattery;
    public bool isCharging;
    public GameObject ChargingStation;

    public float SightRange => sightRange;
    public float ChaseRange => chaseRange;
    public float MaxBattery => maxBattery;
    
    

    private void Awake()
    {
        Target = GameObject.FindWithTag("Player").transform;
        currentState = new Patrol(this, 10f);
        Agent = GetComponent<NavMeshAgent>();

        currentBattery = maxBattery;

    }

    private void Update()
    {
        currentState.OnUpdate();
        LooseEnergy();
        BatteryBar.SetBattery(currentBattery, maxBattery);
    }

    private void LooseEnergy()
    {
        if (!isCharging)
        {
            currentBattery -= UnityEngine.Random.Range(1,4) * Time.deltaTime;
            BattaryLife();
        }
    }


    public void ChangeState (State _state)
    {
        currentState.OnExit();
        currentState = _state;
        currentState.OnExit();
    }


    private void BattaryLife()
    {
        if (currentBattery <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
