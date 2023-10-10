using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Camera cam;
    RaycastHit hit;
    NavMeshAgent agent;
    [SerializeField]
    float speed;


    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        agent = GetComponent<NavMeshAgent>();
        speed = GetComponent<NavMeshAgent>().speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Ground")|| hit.collider.CompareTag("Charger"))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
 
}
