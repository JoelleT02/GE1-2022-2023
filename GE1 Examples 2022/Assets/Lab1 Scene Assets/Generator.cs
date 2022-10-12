using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int loops = 10;
    public GameObject prefab;
    public int circumference;

    public float radius;
    private float x;
    private float z;
    private float angle;
    private Vector3 position;
    private Quaternion rotation;
    private float cx;
    private float cz;
    private int j;

    private GameObject dodecahedron;

    private void Update()
    {

        while (j < loops)
        {
            j++;
            radius += 1f;
            circumference = (int) (2 * Mathf.PI * radius);

            for (int i = 0; i < circumference; i++)
            {
                angle = i * Mathf.PI * 2 / circumference;

                cx = transform.position.x;
                cz = transform.position.z;
                x = cx + Mathf.Cos(angle) * radius;
                z = cz + Mathf.Sin(angle) * radius;
                //position = transform.position + new Vector3(x, 0, z);
                //rotation = Quaternion.Euler(0, angle, 0);
                dodecahedron = Instantiate(prefab);
                dodecahedron.transform.position = new Vector3(x, 0, z);
            }
        }
    }
}

