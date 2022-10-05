using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateMe : MonoBehaviour
{
    [Range(0, 360)]
    public float speed = 90;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
