using System;
using UnityEngine;

public class syklist : MonoBehaviour
{
    private Transform transform;

    private void Start() => transform = GetComponent<Transform>();
    private void Update()
    {
        transform.position += -5 * Time.deltaTime * Vector3.right;
    }
}
