using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidFleeShark : MonoBehaviour
{
    public Transform shark;
    public float fleeRadius = 5f;
    public float fleeStrength = 10f;

    private Boid boid;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boid = GetComponent<Boid>();
        if (shark == null)
        {
            shark = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shark == null) return;

        Vector3 diff = transform.position - shark.position;
        float dist = diff.magnitude;

        if (dist < fleeRadius)
        {
            Vector3 fleeForce = diff.normalized * (fleeStrength / Mathf.Max(dist, 0.1f));
            boid.velocity += fleeForce * Time.deltaTime;
        }
    }
}
