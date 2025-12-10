using UnityEngine;

[RequireComponent(typeof(Boid))]
public class BoidContainerBehavior : MonoBehaviour
{
    private Boid boid;
    public float radius;
    public float boundaryForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boid.transform.position.magnitude > radius)
        {
            boid.velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * boundaryForce * Time.deltaTime;
        }
    }
}
