using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AITank : MonoBehaviour {

    public float radius = 10;
    public int numWaypoints = 5;
    public int current = 0;
    public List<Vector3> waypoints = new List<Vector3>();
    public float speed = 10;
    public Transform player;
    private float x;
    private float z;
    private float c;
    private float angle;
    private Vector3 pos;

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying)
        {
            // Task 1
            // Put code here to draw the gizmos
            // Use sin and cos to calculate the positions of the waypoints 
            // You can draw gizmos using
            // Gizmos.color = Color.green;
            //Gizmos.DrawWireSphere(pos, 1);
            for (int i = 0; i < numWaypoints; i++)
            {
                angle = i * Mathf.PI * 2 / numWaypoints;
                x = Mathf.Cos(angle) * radius;
                z = Mathf.Sin(angle) * radius;
                pos = transform.TransformPoint(new Vector3(x, 0.5f, z));
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(pos, 1);
            }
            // Task 1 complete :)
        }
    }

    // Use this for initialization
    void Awake () {
        // Task 2
        // Put code here to calculate the waypoints in a loop and 
        // Add them to the waypoints List
        for (int i = 0; i < numWaypoints; i++)
        {
            angle = i * Mathf.PI * 2 / numWaypoints;
            x = Mathf.Cos(angle) * radius;
            z = Mathf.Sin(angle) * radius;
            pos = transform.TransformPoint(new Vector3(x, 0.5f, z));
            waypoints.Add(pos);
        }
        //Task 2 complete :)
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one


        // Task 4
        // Put code here to check if the player is in front of or behine the tank
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        // You can print stuff to the screen using:
        GameManager.Log("Hello from th AI tank");
    }
}
