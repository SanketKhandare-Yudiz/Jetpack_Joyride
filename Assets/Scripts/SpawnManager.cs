using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] obstacleSpawnPoints;
    public Transform[] specialPowerSpawnPoints;

    public Transform GetObstacleSpawnPoint(int index)
    {
        if (index < 0 || index >= obstacleSpawnPoints.Length)
        {
            Debug.LogError("Invalid obstacle spawn point index: " + index);
            return null;
        }
        return obstacleSpawnPoints[index];
    }

    public Transform GetSpecialPowerSpawnPoint(int index)
    {
        if (index < 0 || index >= specialPowerSpawnPoints.Length)
        {
            Debug.LogError("Invalid special power spawn point index: " + index);
            return null;
        }
        return specialPowerSpawnPoints[index];
    }
}
