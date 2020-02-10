using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTiles : MonoBehaviour
{
    public GameObject[] tilesPrefab;
    private Transform playerTransform;
    private float spawnZ = -6.0f;
    private float tileLength = 30.0f;
    private int numberOfTilesOnScreen = 3;

    private List<GameObject> activeTiles;
    private float safeZone = 50.0f;
    //private float prefabIndex = 0;
    private int lastPrefabIndex = 0;



    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i <= numberOfTilesOnScreen; i++)
        {
            if(i < 2)
            spawnTiles(0);
            else
            spawnTiles();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z > (spawnZ -numberOfTilesOnScreen * tileLength))
        {
            spawnTiles();
            deleteTile();
        }
        
    }
    // adding tiles
    private void spawnTiles(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        go = Instantiate (tilesPrefab [RandomPrefabIndex()]) as GameObject;
        else
        go = Instantiate (tilesPrefab [prefabIndex]) as GameObject;

        go.transform.SetParent (transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);

    }
    
    private void deleteTile()
    {
        Destroy (activeTiles [0]);
        activeTiles.RemoveAt(0);
    }
    // picking Random Prefab from ( public GameObject[] tilesPrefab;)
    private int RandomPrefabIndex()
    {
        if(tilesPrefab.Length <= 1)
        return 0;
        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range (0, tilesPrefab.Length);
        } 
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
