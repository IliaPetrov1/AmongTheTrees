using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] [Range(1, 10)] private float _smoothFactor;

    private void Update()
    {
        if(target == null)
        {
            return;
        }
    }

    private void FixedUpdate()
    {
        Follow(target, _offset, _smoothFactor);
    }

    void Follow(Transform target, Vector3 offset, float smoothFactor)
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = targetPosition;
    }
}
