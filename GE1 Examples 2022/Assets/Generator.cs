using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    public int numberofDodecahedrons = 6;
    
    public float radius;
    private float sin;
    private float cos;
    private float angle;
    private Vector3 position;
    private Quaternion rotation;

    // Update is called once per frame
    void Start()
    {
        for (int i = 0; i < numberofDodecahedrons; i++)
        {
            angle = i * Mathf.PI * 2 / numberofDodecahedrons;
            cos = Mathf.Cos(angle) * radius;
            sin = Mathf.Sin(angle) * radius;
            position = transform.position + new Vector3(cos, 0, sin);
            rotation = Quaternion.Euler(0, angle, 0);
            Instantiate(prefab, position, rotation);
        }

    }
}
