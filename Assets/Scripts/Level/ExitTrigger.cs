using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    private GameObject Player;
    private Collider2D PlayerCollider;
    private int SceneCount;

    /*private void Awake() // Dá se ještě před funkcí start, nemusí být ani na žádném objektu a i tak se spustí
    {
        DontDestroyOnLoad(Player);
    }*/

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");        // najde objekt hráče
        PlayerCollider = Player.GetComponent<Collider2D>();         // vezme si jeho collider
        SceneCount = SceneManager.sceneCountInBuildSettings;        // vrátí mi kolik scén je v build settings
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log(collision);
        if (collision == PlayerCollider)                        // když do triggeru vejde collider hráče
        {
            if (SceneManager.GetActiveScene().buildIndex < SceneCount - 1)          // když po build indexu aktuální scény je ještě další scéna
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);           // tak načti jí
            }
            else
            {
                SceneManager.LoadScene(0);                      // jinak načti menu
            }
        }
    }
}
