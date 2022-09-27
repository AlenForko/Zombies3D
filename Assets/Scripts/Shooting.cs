using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody[] bulletPrefab;
    private float _bulletSpeed = 10f;
    
    private int _currentWeapon;
    public Transform[] weapons;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(1);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(0);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rigidbody newBullet = Instantiate(bulletPrefab[_currentWeapon], transform.position, Quaternion.identity);
            newBullet.AddForce(transform.up * _bulletSpeed, ForceMode.Impulse);
        }
    }

    private void ChangeWeapon(int weaponOrder)
    {
        _currentWeapon = weaponOrder;
        for (int i = 0; i < bulletPrefab.Length; i++)
        {
            if (i == weaponOrder)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
}
