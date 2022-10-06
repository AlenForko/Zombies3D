using System.Collections;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Rigidbody[] bulletPrefab;
    private float _bulletSpeed = 10f;
    public bool hasShot = false;

    private int _currentWeapon;
    public Transform[] weapons;
    public static int weaponDamage;

    private MeshRenderer weaponSkin;

    void Start()
    {
        weaponSkin = weapons[_currentWeapon].GetComponent<MeshRenderer>();
        _currentWeapon = 0;
        weaponDamage = 20;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeWeapon(0);
            weaponDamage = 20;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeWeapon(1);
            weaponDamage = 50;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !hasShot && !PauseMenu.gameIsPaused)
        {
            Rigidbody newBullet = Instantiate(bulletPrefab[_currentWeapon], transform.position, transform.rotation);
            newBullet.AddForce(transform.forward * _bulletSpeed, ForceMode.Impulse);
            BulletDetection bulletDetection = newBullet.GetComponent<BulletDetection>();
            bulletDetection.owner = this;
            hasShot = true;
            StartCoroutine(WeaponSkin());
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
        weaponSkin = weapons[_currentWeapon].GetComponent<MeshRenderer>();
    }

    IEnumerator WeaponSkin()
    {
        weaponSkin.enabled = false;
        yield return new WaitForSeconds(2f);
        weaponSkin.enabled = true;
    }
}
