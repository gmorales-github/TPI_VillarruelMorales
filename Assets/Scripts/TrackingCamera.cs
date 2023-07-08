using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void LateUpdate()
    {
        // Ponemos el Traking de la camara en LateUpdate para que se posicione despues de que el resto de elementos 
        if (_target)
        {
            transform.position = new Vector3(_target.position.x, _target.position.y, transform.position.z);
        }
    }
}