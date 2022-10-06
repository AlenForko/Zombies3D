using System.Collections;
using UI;
using UnityEngine;

namespace Player
{
    public class Shooting : MonoBehaviour
    {
        public Rigidbody[] bulletPrefab;
        private float _bulletSpeed = 10f;
        public bool hasShot = false;

        private int _currentWeapon;
        public Transform[] weapons;
        public static int WeaponDamage;

        private MeshRenderer _weaponSkin;

        void Start()
        {
            _weaponSkin = weapons[_currentWeapon].GetComponent<MeshRenderer>();
            _currentWeapon = 0;
            WeaponDamage = 20;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeWeapon(0);
                WeaponDamage = 20;
            }
            else if(Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeWeapon(1);
                WeaponDamage = 50;
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && !hasShot && !PauseMenu.GameIsPaused)
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
            _weaponSkin = weapons[_currentWeapon].GetComponent<MeshRenderer>();
        }

        IEnumerator WeaponSkin()
        {
            _weaponSkin.enabled = false;
            yield return new WaitForSeconds(2f);
            _weaponSkin.enabled = true;
        }
    }
}
