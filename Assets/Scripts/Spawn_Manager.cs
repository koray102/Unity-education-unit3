using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject obstaclePre;
    public Vector3 spawnPos = new Vector3(25, 0, 0);
    private int startDelay = 3;
    public float repeateInterval = 3;
    public Player_Conroller playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeateInterval);
        playerControllerScript = GameObject.Find("Player").GetComponent<Player_Conroller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
        {
            Instantiate(obstaclePre, spawnPos, obstaclePre.transform.rotation);
        }
    }
}
