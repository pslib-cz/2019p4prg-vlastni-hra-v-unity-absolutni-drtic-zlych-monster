using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWalls : MonoBehaviour
{
    private GameObject EnemyObject;
    private GameObject[] FinalWalls;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ExitTrigger = GameObject.FindGameObjectWithTag("Finish");            // najde objekt, který slouží k přepnutí na další level (exit trigger)
    }

    // Update is called once per frame
    void Update()
    {
        EnemyObject = GameObject.FindGameObjectWithTag("EnemyTag");         // snaží se najít objekt nepřítele
        if (EnemyObject == null)                                            // pokud ho nenajde
        {
            FinalWalls = GameObject.FindGameObjectsWithTag("ExitWall");     // tak vyhledá určené zdi
            foreach (GameObject go in FinalWalls)
            {
                go.SetActive(false);                                        // a všechny vypne
            }
        }
    }
}
