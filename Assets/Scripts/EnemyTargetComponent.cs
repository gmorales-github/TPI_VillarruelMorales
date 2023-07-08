using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetComponent : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public Transform GetTarget()
    {
        return _target;
    }
}
