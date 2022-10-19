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
    private Vector3 nextWaypoint;
    private float waypointDistance;
    private Vector3 playerDistance;
    public float dot;
    public float FOV;
    private Quaternion targetRotation;
    

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
            
            player = GameObject.FindWithTag("Player").transform;
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
    }

    // Update is called once per frame
    void Update () {
        // Task 3
        // Put code here to move the tank towards the next waypoint
        // When the tank reaches a waypoint you should advance to the next one
        pos = transform.position;
        nextWaypoint = waypoints[current] - pos;
        waypointDistance = nextWaypoint.magnitude;

        if (waypointDistance < 1f)
        {
            current += 1 % waypoints.Count;

            if (current >= 5f)
            {
                current = 0;
                return;
            }
        }

        transform.position = Vector3.Lerp(transform.position, waypoints[current], Time.deltaTime);
        targetRotation = Quaternion.LookRotation(nextWaypoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);


        // Task 4
        // Put code here to check if the player is in front of or behind the tank
        playerDistance = player.position - transform.position;
        dot = Vector3.Dot(transform.forward, playerDistance.normalized);
          
        
        if (dot > 0)
        {
            GameManager.Log("Player is in front of the AI Tank");
        }
        else
        {
            GameManager.Log("Player is behind the AI Tank");
        }
        
        // Task 5
        // Put code here to calculate if the player is inside the field of view and in range
        FOV = Vector3.Angle(playerDistance, transform.forward);

        if (FOV < 45)
        {
            GameManager.Log("Player is inside the field of view");
        }

        if (playerDistance.magnitude < 10)
        {
            GameManager.Log("Player is in range");
        }

    }
}
