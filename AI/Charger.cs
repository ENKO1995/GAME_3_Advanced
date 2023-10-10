using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charger : MonoBehaviour
{
    public GameObject Station;
    public bool Occupied;
    [SerializeField]
    Material occupiedC;
    [SerializeField]
    Material freeC;
    GameObject [] AI;

    private void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
    }

    private void OnTriggerEnter(Collider collider)
    {
        
        if (collider.CompareTag("AI") && collider.GetComponent<AI>().isCharging == true)
        {
            Station.GetComponent<MeshRenderer>().material = occupiedC;

        }

    }
    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("AI") && collider.GetComponent<AI>().isCharging == true)
        {
            Station.GetComponent<MeshRenderer>().material = occupiedC;

        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("AI")&& collider.GetComponent<AI>().isCharging==false)
        {
            Station.GetComponent<MeshRenderer>().material = freeC;
            Debug.Log("Exit");
        }
    }
}
