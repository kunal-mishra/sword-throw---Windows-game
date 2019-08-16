using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playgame : MonoBehaviour
{
    int sceneindex = 1;
   

    public void play()
    {
        SceneManager.LoadScene(sceneindex);
    }
}
