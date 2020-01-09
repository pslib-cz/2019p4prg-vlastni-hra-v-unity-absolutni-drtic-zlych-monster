using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // používáme pro měnění scén v Unity

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        // SceneManager.LoadScene(1);    toto by šlo použít, ovšem líbí se mi více ta dynamičtější varianta
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);           // Přičte k aktivní scéně + 1, aby načetlo scénu, která je po této v queue
        PlayerHealth.HP = 10;               // nastavení hodnot pro hráče - toto jsou ty základní hodnoty pro normálního hráče (developer hodnoty jsou v daných scriptech)
        PlayerHealth.MaxHP = 10;
        PlayerHealth.isDead = false;
        PlayerBullet.speed = 20;
        PlayerBullet.damage = 1;
        PlayerWeapon.FireRate = 1;
        PlayerMovement.movementSpeed = 3;
    }

    public void Exit()
    {
        Application.Quit();     // Vypne aplikaci, nefunguje v preview v unity!
    }
}
