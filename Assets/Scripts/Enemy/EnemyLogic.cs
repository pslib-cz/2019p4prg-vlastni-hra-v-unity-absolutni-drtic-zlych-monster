using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int enemyHP;                     // Počet životů
    public Transform meleePoint;            // Bod od kterého se měří vzdálenost útoku na blízko
    public float meleeRange;                // Vzdálenost pro útok
    public LayerMask enemyPlayer;           // Maska hráče - pro útook
    public float meleeAttackRate;           // Proměnná jak často může enemy útočit
    public int attackDamage;                // Proměnná pro sílu útoku
    private GameObject PlayerObject;        // Ukládá collider trefeného hráče
    private float nextAttack;               // Ukládá čas posledního útoku
    private Vector2 playerPosition;         // Vektor pro otáčení enemy k player
    private Rigidbody2D rigbody;            // Rigidbody enemy pro otáčení směrem k hráči

    private void Start()
    {
        rigbody = GetComponent<Rigidbody2D>();                      // Vezme si dynamicky komponentu rigidbody z daného objektu
        PlayerObject = GameObject.FindGameObjectWithTag("Player");      // Najde ve hře objekt s tagem player
    }

    private void Update()
    {
        playerPosition = PlayerObject.transform.position;               // vezme pozici hráče
        playerPosition.x -= rigbody.position.x;                         // odečte pozici enemy od pozice hráče pro udání správného vektoru
        playerPosition.y -= rigbody.position.y;                         // odečte pozici enemy od pozice hráče pro udání správného vektoru
        Collider2D hitPlayer = Physics2D.OverlapCircle(meleePoint.position, meleeRange, enemyPlayer);       // Skenuje ve svém okruhu hráče
        if (hitPlayer != null && Time.time > nextAttack)              // Pokud najde hráče a zároveň neútočil nedávno
        {
            nextAttack = Time.time + meleeAttackRate;         // Nastaví čas dalšímu útoku
            Attack();                       // Zaútočí
        }
    }

    private void FixedUpdate()
    {
        rigbody.SetRotation((Mathf.Atan2(playerPosition.y, playerPosition.x) * Mathf.Rad2Deg) - 90);            // vrátí úhel enemy ku hráči, -90 je pro dorovnání úhlu
    }

    public void EnemyTakeDamage(int damage)         // Funkce pro zranění sebe samotného (kulka hráče jej trefí)
    {
        enemyHP -= damage;
        if (enemyHP <= 0)           // Pokud má 0 a méně životů
        {
            Die();                  // Tak umři
        }
    }

    private void Attack()           // Útok nepřítele na hráče
    {
        PlayerObject.GetComponent<PlayerHealth>().PlayerTakeDamage(attackDamage);          // Zraní hráče
        // Debug.Log("NPC hit");
    }

    private void Die()             // Enemy umřel
    {
        Destroy(gameObject);        // Vymaže objekt
    }


    // Využito pro vykreslení okruhu proměnné meleeRange
    /*private void OnDrawGizmosSelected()
    {
        if (meleePoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(meleePoint.position, meleeRange);
    }*/
}
