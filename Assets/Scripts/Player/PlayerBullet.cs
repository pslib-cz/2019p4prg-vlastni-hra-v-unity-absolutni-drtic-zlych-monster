using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rigbody;    // "Fyzika" kulky
    public static float speed = 20;        // rychlost kulky (zde je developer hodnota, reálná hodnota je u play v main menu)
    public static int damage = 1;          // poškození (zde je developer hodnota, reálná hodnota je u play v main menu)
    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();          // dynamicky najde na komponentě (kulce) rigidbody
        rigbody.velocity = transform.up * speed;            // vypočítá jeho rychlost
    }

    private void OnTriggerEnter2D(Collider2D collision)     // použije se při kolizi s jiným colliderem, collision se použije pro získání objektu
    {
        EnemyLogic enemy = collision.GetComponent<EnemyLogic>();            // z daného objektu (díky kolizi) si vememe jeho skript EnemyLogic
        if (enemy != null)              // Pokud enemy není prázdný - tedy i kontrola zda trefil objekt enemy
        {
            enemy.EnemyTakeDamage(damage);              // Tak v jeho skriptu použij zranění
        }
        Destroy(gameObject);                            // Následovně znič danou kulku
    }
}
