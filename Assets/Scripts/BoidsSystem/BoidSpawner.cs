using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float radius;
    public int number;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefab, this.transform.position + Random.insideUnitSphere * radius, Random.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
