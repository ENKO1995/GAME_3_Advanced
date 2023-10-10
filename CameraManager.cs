using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    Transform player;
    private Vector3 cameraOffset;

    [SerializeField]
    float smoothFactor;


    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = player.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
    }
}
