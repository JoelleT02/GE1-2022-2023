using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Fish : MonoBehaviour
{
    private GameObject fishBody;
    private GameObject fishHead;
    private GameObject fishTail;

    private Transform fish;
    public Transform head;
    public Transform tail;

    private Material bodyMat;
    private Material headMat;
    private Material tailMat;

    [Range(0.1f, 20f)] 
    public float frequency; //speed

    public int headAmplitude; //head highest & lowest point
    public int tailAmplitude; //tail highest & lowest point
    public float theta;

    private float headMovement;
    private float tailMovement;



    private void Start()
    {
        //assigning the parents
        fish = FindObjectOfType<Fish>().transform;
        head = GameObject.Find("Head").transform;
        tail = GameObject.Find("Tail").transform;
        
        //creating the cubes
        fishBody = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fishHead = GameObject.CreatePrimitive(PrimitiveType.Cube);
        fishTail = GameObject.CreatePrimitive(PrimitiveType.Cube);

        //making them grey
        bodyMat = fishBody.GetComponent<MeshRenderer>().material;
        headMat = fishHead.GetComponent<MeshRenderer>().material;
        tailMat = fishTail.GetComponent<MeshRenderer>().material;
        bodyMat.color = Color.gray;
        headMat.color = Color.gray;
        tailMat.color = Color.gray;

        //changing cubes' scale
        fishBody.transform.localScale = new Vector3(2, 1, 1);
        fishHead.transform.localScale = new Vector3(2, 1, 1);
        fishTail.transform.localScale = new Vector3(2, 1, 1);

        fishHead.transform.position = new Vector3(2, 0, 0);
        fishTail.transform.position = new Vector3(-2, 0, 0);


        //setting the parents
        fishBody.transform.SetParent(fish);
        fishHead.transform.SetParent(head);
        fishTail.transform.SetParent(tail);
    }

    
    private void Update()
    {
        theta += Time.deltaTime * frequency;
        headMovement = headAmplitude * (Mathf.Sin(theta));
        tailMovement = tailAmplitude * (Mathf.Sin(theta) * -1);
        head.transform.localRotation = Quaternion.AngleAxis(headMovement, Vector3.forward);
        tail.localRotation = Quaternion.AngleAxis(tailMovement * -1, Vector3.forward);
    }
    
    
    
}
