using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Shooting : MonoBehaviour
{
    public Rigidbody[] bulletPrefab;
    private float _bulletSpeed = 7f;

    private int _currentWeapon;
    public Transform[] weapons;

    public List<Transform> placeholder = new List<Transform>();

    void Start()
    {
        _currentWeapon = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
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
