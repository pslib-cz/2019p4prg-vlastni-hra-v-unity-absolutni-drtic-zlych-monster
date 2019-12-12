using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;       // určené místo pro spawnutí kulky
    public GameObject bulletPrefab;     // co se bude spawnovat

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))       // při zmáčknutí lmb
        {
            ShootWeapon();
        }
    }

    void ShootWeapon()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);      // naklonuj prefab kulky na pozici a rotaci místa pro spawnutí
    }
}
