using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class leveltrans : MonoBehaviour
{
    int sceneindex = 2 ;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<player>().savegame();
          
            SceneManager.LoadScene(sceneindex);
        }
        col.gameObject.GetComponent<player>().camerao = false;

    }
}
