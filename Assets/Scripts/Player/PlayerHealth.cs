using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static int MaxHP = 1000;             // maximální počet životů hráče (zde je developer hodnota, reálná hodnota je u play v main menu)
    public static int HP = 1000;                // aktuální počet životů hráče (zde je developer hodnota, reálná hodnota je u play v main menu)
    public static bool isDead = false;          // bool zda je hráč mrtvý nebo ne (využívá se v UI)
    
    public void Start()
    {
        if (MaxHP < HP)             // kdyby náhodou byli maximální životy menší než aktuální životy
        {
            HP = MaxHP;             // tak nastav aktuální životy na maximální životy
        }
    }


    public void PlayerTakeDamage(int damage)         // Funkce pro zranění sebe samotného (hráč bude zasáhnut)
    {
        HP -= damage;          // uber životy o hodnotu damage
        if (HP <= 0)           // Pokud má 0 a méně životů
        {
            Die();                  // Tak umři
        }
    }

    private void Die()
    {
        isDead = true;              // hráč je mrtvý
        Destroy(gameObject);        // Vymaže objekt
    }
}
