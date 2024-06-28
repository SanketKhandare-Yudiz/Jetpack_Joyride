using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> ZapperPrefabs;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject laserPrefab;

    private float initialZapperPosition = 50f;
    private float initialMissilePosition = 400f;
    private float initiallaserPosition = 600f;

    public Transform player;

    private List<GameObject> zapperlist = new List<GameObject>();
    private List<GameObject> missileList = new List<GameObject>();
    private List<GameObject> laserlist = new List<GameObject>();

    private float nextZapperPosition;
    private float nextMissilePosition;
    private float nextLaserPosition;

    bool instantiate = false;

    void Start()
    {
        nextZapperPosition = initialZapperPosition;
        nextMissilePosition = initialMissilePosition;
        nextLaserPosition = initiallaserPosition;

        for (int i = 0; i < 3; i++)
        {
            SpawnZapper();
        }

        // SpawnMissile();
    }

    void Update()
    {
        if (player.transform.position.x > zapperlist[2].transform.position.x)
        {
            GameObject zapper = zapperlist[0];
            zapperlist.RemoveAt(0);
            Destroy(zapper);
            SpawnZapper();
            Debug.Log("Spown Zapper");
            // RecycleObstacle(zapperlist, nextZapperPosition, SpawnZapper);
        }

        if (player.transform.position.x > missileList[0].transform.position.x && !instantiate)
        {
            GameObject missile = missileList[0];
            missileList.RemoveAt(0);
            Destroy(missile);
            SpawnMissile();
            instantiate = true;
            //RecycleObstacle(missileList, nextMissilePosition, SpawnMissile);
        }

        if (player.transform.position.x > 600f && !instantiate)
        {
            GameObject laser = laserlist[0];
            missileList.RemoveAt(0);
            Destroy(laser);
            SpawnLaser();
            instantiate = true;
            //RecycleObstacle(laserlist, nextLaserPosition, SpawnLaser);
        }
    }

    void SpawnZapper()
    {
        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
        Debug.Log("randomprefabindex:" + randomIndex);
        GameObject randomPrefab = ZapperPrefabs[randomIndex];
        float yoffset = Random.Range(3, -3);
        Vector3 spawnPosition = new Vector3(nextZapperPosition, transform.position.y + yoffset, transform.position.z);
        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        zapperlist.Add(newObstacle);
        float obstacleDistance = Random.Range(25, 50);
        nextZapperPosition += obstacleDistance;
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
        float newDistance = Random.Range(100, 200);
        nextMissilePosition += newDistance;
        instantiate = false;
    }

    void SpawnLaser()
    {
        float yOffset = Random.Range(4, -3);
        Vector3 spownPosition = new Vector3(nextLaserPosition, transform.position.y + yOffset, transform.position.z);
        GameObject newlaser = Instantiate(laserPrefab, spownPosition, Quaternion.identity);

        Laser laser = newlaser.GetComponent<Laser>();
        if (laser != null)
        {

        }

        laserlist.Add(newlaser);
        float newDistance = Random.Range(300, 400);
        nextLaserPosition += newDistance;
        instantiate = false;
    }
    //void RecycleObstacle(List<GameObject> obstacleList, float nextPosition, System.Action spawnMethod)
    //{
    //    GameObject obstacle = obstacleList[0];
    //    obstacleList.RemoveAt(0);
    //    Destroy(obstacle);
    //    spawnMethod.Invoke();
    //}
}



// pending Work Date 28 June 2024
// Spawnmanager >> obstacle >> coins >> SuperPowers

//using UnityEngine;
//using System.Collections.Generic;

//public class ObstacleSpawner : SpawnManager
//{
//    private float nextZapperPosition;
//    private float nextMissilePosition;
//    List<GameObject> zapperlist;
//    List<GameObject> missileList;
//    bool instantiate = false;

//    private void Start()
//    {

//    }

//    private void Update()
//    {

//    }

//    public void SpawnZapper()
//    {
//        int randomIndex = Random.Range(0, ZapperPrefabs.Count);
//        Debug.Log("randomprefabindex:" + randomIndex);
//        GameObject randomPrefab = ZapperPrefabs[randomIndex];
//        float yoffset = Random.Range(3, -3);
//        Vector3 spawnPosition = new Vector3(nextZapperPosition, transform.position.y + yoffset, transform.position.z);
//        GameObject newObstacle = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
//        zapperlist.Add(newObstacle);
//        float obstacleDistance = Random.Range(25, 50);
//        nextZapperPosition += obstacleDistance;
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