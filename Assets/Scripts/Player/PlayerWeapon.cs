using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;       // určené místo pro spawnutí kulky
    public GameObject bulletPrefab;     // co se bude spawnovat
    public static float FireRate = 0.5f;  // určuje rychlost střelby - čím větší, tím pomaleji střílí (zde je developer hodnota, reálná hodnota je u play v main menu)
    private float NextShot = 0;         // Ukládá čas poslední střely

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > NextShot)       // při zmáčknutí/držení levého tlačítka myši a zároveň kontrola jestli můžu střílet
        {
            NextShot = Time.time + FireRate;               // Nastaví čas dalšímu útoku     
            ShootWeapon();                  // vystřel
        }
    }

    void ShootWeapon()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);      // naklonuj prefab kulky na pozici a rotaci místa pro spawnutí
    }
}
