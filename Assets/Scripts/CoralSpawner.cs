using UnityEngine;

public class CoralSpawner : MonoBehaviour
{
    public GameObject coralPrefab;
    public int obstacleCount = 25;

    // Arena size (half extents)
    public float arenaWidth = 15f;
    public float arenaHeight = 7.5f;
    public float arenaDepth = 15f;

    public void SpawnObstacles()
    {
        for (int i = 0; i < obstacleCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-arenaWidth, arenaWidth),
                Random.Range(-arenaHeight, arenaHeight),
                Random.Range(-arenaDepth, arenaDepth)
            );

            if (Vector3.Distance(pos, Vector3.zero) < 3f)
            {
                i--;
                continue;
            }

            Quaternion rot = Random.rotation;

            GameObject obj = Instantiate(coralPrefab, pos, rot);

            // Randomize scale for variation
            float scale = Random.Range(0.8f, 2.5f);
            obj.transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void ClearObstacles()
    {
        GameObject[] corals = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject coral in corals)
        {
            Destroy(coral);
        }
    }
}
