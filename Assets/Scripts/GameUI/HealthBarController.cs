using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    private Slider healthBarSlider;
    private TMPro.TextMeshProUGUI healthBarText;

    void Start()
    {
        healthBarSlider = GetComponent<Slider>();       // najde komponentu slider
        healthBarText = GetComponentInChildren<TMPro.TextMeshProUGUI>();        // najde podkompenntu text, která je umístěna v slideru
    }
    // Update is called once per frame
    void Update()
    {
        healthBarSlider.maxValue = PlayerHealth.MaxHP;          // nastav maximální hodnotu slideru na maximální počet životů
        healthBarSlider.value = PlayerHealth.HP;                // nastav aktuální hodnotu slideru na aktuální počet životů
        if (PlayerHealth.isDead)            // pokud hráč je mrtvý (isDead = true)
        {
            healthBarText.text = "DEAD";                // místo životů ukaž nápis "DEAD"
        }
        else
        {
            healthBarText.text = PlayerHealth.HP.ToString() + " / " + PlayerHealth.MaxHP.ToString();            // jinak ukaž aktuální životy / maximální životy
        }
    }
}
