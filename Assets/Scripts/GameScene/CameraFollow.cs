using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Vector3 offset;
    [SerializeField] float smoothness = 0.125f;
    [SerializeField] Transform targetTransform;

    private Vector3 newPosition;
    private Vector3 newSmoothedPosition;
    
    // Update is called once per frame
    void LateUpdate() {

        newPosition         = targetTransform.position + offset;
        newSmoothedPosition = Vector3.Lerp(transform.position, newPosition, smoothness * Time.deltaTime);

        transform.position  = newSmoothedPosition;

    }

}
