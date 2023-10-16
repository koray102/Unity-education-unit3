using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Out_Of_Border : MonoBehaviour
{
    public float leftBorder = -8.17f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }
    }
}
