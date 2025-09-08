using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject trackPrefab;
    public GameObject sushiPrefab;

    private static float[] _tracks = { 11f, 15f, 19f };

    public void SpawnTrack()
    {
        float platformLength = 203.55f;

        // Instantiate the new platform at the correct Z position
        GameObject newPlatform = Instantiate(trackPrefab, new Vector3(0, 0, platformLength), Quaternion.identity);

        // Get the platform length from its collider
        Collider platformCollider = newPlatform.GetComponent<Collider>();

        // Spawn obstacles for this platform
        SpawnObstacles(platformLength);
    }

    public void SpawnObstacles(float platformLength)
    {
        float groupSpacing = 20f;
        int numGroups = Mathf.FloorToInt(platformLength / groupSpacing);

        for (int group = 0; group < numGroups; group++)
        {
            float zPos = platformLength + group * groupSpacing;
            int emptyTrackIndex = Random.Range(0, 3);

            for (int i = 0; i < 3; i++)
            {
                if (i != emptyTrackIndex)
                {
                    Vector3 spawnPosition = new Vector3(_tracks[i], -1.3f, zPos);
                    Instantiate(obstaclePrefab, spawnPosition, Quaternion.Euler(270, 0, 0));
                }
            }

            float sushiLineLength = groupSpacing;
            int sushiPerLine = 5;
            for (int x = 0; x < sushiPerLine; x++)
            {
                float sushiZ = zPos + (x * (sushiLineLength / sushiPerLine));
                Vector3 sushiPosition = new Vector3(_tracks[emptyTrackIndex], 1f, sushiZ);
                Instantiate(sushiPrefab, sushiPosition, Quaternion.identity);
            }
        }
    }
}