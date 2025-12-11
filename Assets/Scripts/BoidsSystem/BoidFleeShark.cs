using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidFleeShark : MonoBehaviour
{
    [Header("References")]
    public GameObject sharkObject;   // Assign the SHARK GameObject here
    public GameObject playerObject;  // Assign the PLAYER GameObject here

    [Header("Settings")]
    public float fleeSpeed = 5f;
    public float fleeDistance = 10f;

    private Transform shark;
    private Transform player;

    void Start()
    {
        // Cache transforms after assignment
        shark = sharkObject.transform;
        player = playerObject.transform;
    }

    void Update()
    {
        // If the shark is close, flee
        float distance = Vector3.Distance(shark.position, transform.position);

        if (distance < fleeDistance)
        {
            Vector3 awayFromShark = transform.position - shark.position;
            transform.position += awayFromShark.normalized * fleeSpeed * Time.deltaTime;
        }
    }
}
