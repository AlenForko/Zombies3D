using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutofBounds : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(0, 5), 10, Random.Range(0, 5));
        }
    }
}
