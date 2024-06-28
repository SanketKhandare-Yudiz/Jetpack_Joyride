//using System.Collections.Generic;
//using UnityEngine;

//public class SpecialPowerSpawner : MonoBehaviour
//{
//    [SerializeField] private List<GameObject> superPowersPrefab;
//    private float specialPowerDistance;
//    private float initialSPPosition = 200f;

//    public Transform player;

//    private List<GameObject> SpecialPower = new List<GameObject>();
//    private float nextSPPosition;

//    void Start()
//    {
//        nextSPPosition = initialSPPosition;
//        for(int i =0; i<2; i++)
//        {
//            SpwanSuperPower();
//        }
//    }

//    void Update()
//    {
//        if (player.transform.position.x > SpecialPower[1].transform.position.x)
//        {
//            RemoveSpecialPower();
//            SpwanSuperPower();
//        }
//    }
//    public void SpwanSuperPower()
//    {
//        int randomIndex = Random.Range(0, superPowersPrefab.Count);
//        GameObject randomPrefab = superPowersPrefab[randomIndex];
//        float yoffset = Random.Range(0,3);
//        Vector3 spawnPosition = new Vector3(nextSPPosition, transform.position.y + yoffset, transform.position.z);
//        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
//        SpecialPower.Add(newObstacle);
//        specialPowerDistance = Random.Range(100,110);
//        nextSPPosition += specialPowerDistance;
//    }

//    void RemoveSpecialPower()
//    {
//        GameObject specialpower = SpecialPower[0];
//        SpecialPower.RemoveAt(0);
//        Destroy(specialpower);
//    }
//}

using UnityEngine;
using System.Collections.Generic;

public class SpecialPowerSpawner : SpawnManager
{
    private float nextSPPosition;
    private List<GameObject> SpecialPower;

    private void Update()
    {
        
    }

    public void SpawnSpecialPower()
    {
        int randomIndex = Random.Range(0, SpecialPowersPrefabs.Count);
        GameObject randomPrefab = SpecialPowersPrefabs[randomIndex];
        float yoffset = Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(nextSPPosition, transform.position.y + yoffset, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        SpecialPower.Add(newObstacle);
        float specialPowerDistance = Random.Range(500, 800);
        nextSPPosition += specialPowerDistance;
    }

    void RemoveSpecialPower()
    {
        GameObject specialpower = SpecialPower[0];
        SpecialPower.RemoveAt(0);
        Destroy(specialpower);
    }
}