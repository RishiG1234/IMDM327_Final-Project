using UnityEngine;

public class BoidBoundsBehavior : MonoBehaviour
{
    public Vector3 center = Vector3.zero; 
    public Vector3 boundsSize = new Vector3(25, 25, 25);
    public float avoidStrength = 20f;

    private Boid boid;

    void Start()
    {
        boid = GetComponent<Boid>();
    }

    void Update()
    {
        Vector3 offset = transform.position - center;

        if (Mathf.Abs(offset.x) > boundsSize.x ||
            Mathf.Abs(offset.y) > boundsSize.y ||
            Mathf.Abs(offset.z) > boundsSize.z)
        {
            // Push back toward the center
            Vector3 force = -offset.normalized * avoidStrength;
            boid.velocity += force * Time.deltaTime;
        }
    }
}
