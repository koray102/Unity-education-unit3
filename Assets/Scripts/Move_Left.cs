using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Left : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 40;
    public Player_Conroller playerControllerScript;

    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<Player_Conroller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        
    }
}
