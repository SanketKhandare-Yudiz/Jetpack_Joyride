using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ZapperPrefabs;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject laserPrefab;

    private float initialZapperPosition = 30f;
    private float initialMissilePosition = 300f;

    public Transform player;

    private List<GameObject> zapperlist = new List<GameObject>();
    private List<GameObject> missileList = new List<GameObject>();

    private float nextZapperPosition;
    private float nextMissilePosition;

    private bool missileSpawned = false;

    void Start()
    {
        nextZapperPosition = initialZapperPosition;
        nextMissilePosition = initialMissilePosition;
        for (int i = 0; i < 2; i++)
        {
            SpawnZapper();
        }
       // SpawnMissile();
    }

    void Update()
    {
        if (player.transform.position.x > zapperlist[1].transform.position.x)
        {
            RemoveZapper();
            SpawnZapper();
            Debug.Log("Spawn Zapper");
        }
        if(player.transform.position.x > 350f && !missileSpawned)
        {
            RemoveMissile();
            SpawnMissile();
            Debug.Log("missile Spawned");
            missileSpawned = true;
        }
    }

    void SpawnZapper()
    {
        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
        Debug.Log("randomprefabindex:" + randomIndex);
        GameObject randomPrefab = ZapperPrefabs[randomIndex];
        Vector3 spawnPosition = new Vector3(nextZapperPosition, transform.position.y, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        zapperlist.Add(newObstacle);

        Transform childTransform = randomPrefab.transform.GetChild(0);
        float childPos = childTransform.localPosition.x;
        //int myInt = (int)childPos;
        Debug.Log("child Pos : :" + childPos);

        float obstacleDistance = Random.Range(childPos +10f , childPos + 13f);
        nextZapperPosition += obstacleDistance;
        missileSpawned = false;
    }

    private void RemoveZapper()
    {
        GameObject zapper = zapperlist[0];
        zapperlist.RemoveAt(0);
        Destroy(zapper);
    }

    private void RemoveMissile()
    {
        GameObject missile = missileList[0];
        missileList.RemoveAt(0);
        Destroy(missile);

    }

    void SpawnMissile()
    {
        float yoffset = Random.Range(4, -3);
        Vector3 spownPosition = new Vector3(nextMissilePosition, transform.position.y + yoffset, transform.position.z);
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        GameObject newMissile = Instantiate(missilePrefab, spownPosition, rotation);

        Missile missile = newMissile.GetComponent<Missile>();
        if (missile != null)
        {
            missile.SetPlayerTransform(player);
        }
        missileList.Add(newMissile);
        float newDistance = Random.Range(100, 150);
        nextMissilePosition += newDistance;
    }
}

    //void RecycleObstacle(List<GameObject> obstacleList, float nextPosition, System.Action spawnMethod)
    //{
    //    GameObject obstacle = obstacleList[0];
    //    obstacleList.RemoveAt(0);
    //    Destroy(obstacle);
    //    spawnMethod.Invoke();
    //}


//pending Work Date 28 June 2024
//Spawnmanager >> obstacle >> coins >> SuperPowers

//using UnityEngine;
//using System.Collections.Generic;

//public class ObstacleSpawner : SpawnManager
//{
//    private float nextZapperPosition;
//    private float nextMissilePosition;
//    List<GameObject> zapperlist;
//    List<GameObject> missileList;
//    bool instantiate = false;
//    public Transform[] spawnPoint;
//    //float initialZapperPosition = 10f;
//    float spawninterval = 10f;
//    float timer;

//    private void Start()
//    {
//        nextZapperPosition = spawninterval;

//        for (int i = 0; i < 3; i++)
//        {
//            SpawnZapper();
//        }
//    }

//    private void Update()
//    {
//       if(player.transform.position.x > zapperlist[1].transform.position.x)
//        {
//            SpawnZapper();
//        }
//    }

//    public void SpawnZapper( )
//    {
//        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
//        Debug.Log("randomprefabindex:" + randomIndex);
//        GameObject randomPrefab = ZapperPrefabs[randomIndex];
//        Vector3 spawnPosition = new Vector3(nextZapperPosition, transform.position.y, transform.position.z);
//        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
//        zapperlist.Add(newObstacle);
//        //float obstacleDistance = Random.Range(70, 100);
//        spawninterval = Random.Range(50, 100);
//        nextZapperPosition += spawninterval;
//        instantiate = false;
//    }

//    public void SpawnMissile()
//    {
//        float yoffset = Random.Range(4, -3);
//        Vector3 spownPosition = new Vector3(nextMissilePosition, transform.position.y + yoffset, transform.position.z);
//        Quaternion rotation = Quaternion.Euler(0, 0, 90);
//        GameObject newMissile = Instantiate(missilePrefab, spownPosition, rotation);

//        Missile missile = newMissile.GetComponent<Missile>();
//        if (missile != null)
//        {
//            missile.SetPlayerTransform(player);
//        }
//        missileList.Add(newMissile);
//        float newDistance = Random.Range(100, 200);
//        nextMissilePosition += newDistance;
//        instantiate = false;
//    }
//}