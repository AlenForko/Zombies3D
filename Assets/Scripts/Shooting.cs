using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody bulletPrefab;

    private float _bulletSpeed = 10f;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rigidbody newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.AddForce(transform.up * _bulletSpeed, ForceMode.Impulse);
        }
    }
}
