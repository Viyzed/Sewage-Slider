using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 4.8f;
    
    // Fix camera height
    private Camera _camera;
    private float _fixedHeight;
    private float _fixedStart;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _fixedHeight = transform.position.y;
        _fixedStart = transform.position.x;
    }

    // LateUpdate runs immediately after the Update method
    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        smoothedPosition.y = _fixedHeight;

        if (smoothedPosition.x > _fixedStart)
        {
            transform.position = smoothedPosition;
        }
     
    }

}
