using UnityEngine;

public class BoidObstacleAvoidance : MonoBehaviour
{
    public float avoidDistance = 3f;
    public float avoidStrength = 20f;
    private Boid boid;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidDistance))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Vector3 avoidDir = Vector3.Reflect(transform.forward, hit.normal);
                boid.velocity += avoidDir.normalized * avoidStrength * Time.deltaTime;
            }
        }
    }
}
