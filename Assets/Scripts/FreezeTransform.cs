using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    private void Update()
    {
        transform.position = target.position + offset;
    }
}