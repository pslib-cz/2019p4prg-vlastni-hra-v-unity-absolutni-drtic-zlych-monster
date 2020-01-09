using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageTextController : MonoBehaviour
{
    private TMPro.TextMeshProUGUI StageNumberText;

    // Start is called before the first frame update
    void Start()
    {
        StageNumberText = GetComponentInChildren<TMPro.TextMeshProUGUI>();      // získej komponentu textového pole
    }

    // Update is called once per frame
    void Update()
    {
        StageNumberText.text = SceneManager.GetActiveScene().buildIndex.ToString();         // nastav hodnotu stage podle toho, jaký je build index - toto možná přepíšu na proměnnou
    }
}
