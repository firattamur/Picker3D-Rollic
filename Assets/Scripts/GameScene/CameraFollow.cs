using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offsetPosition;

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTransform.position + offsetPosition;
    }

}
