using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    //Checks if player jumps out of the terrain.
    void Update()
    {
        if (gameObject.transform.position.y < -5f)
        {
            transform.position = new Vector3(Random.Range(0, 5), 10, Random.Range(0, 5));
        }
    }
}
