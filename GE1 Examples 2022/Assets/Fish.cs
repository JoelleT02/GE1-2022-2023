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
        
        
        //setting the parents
        fishBody.transform.SetParent(fish, false);
        fishHead.transform.SetParent(head, false);
        fishTail.transform.SetParent(tail, false);
    }
}
