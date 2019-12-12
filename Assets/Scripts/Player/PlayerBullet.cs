using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private Rigidbody2D rigbody;    // "Fyzika" kulky
    public float speed = 20;        // private a public poté vyměním až přidám itemy
    public int damage = 1;          // poškození
    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();          // dynamicky najde na komponentě (kulce) rigidbody
        rigbody.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)     // použije se při kolizi s jiným colliderem
    {
        EnemyLogic enemy = collision.GetComponent<EnemyLogic>();
        if (enemy != null)
        {
            enemy.EnemyTakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
