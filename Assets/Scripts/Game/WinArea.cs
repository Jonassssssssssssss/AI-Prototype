using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            Victory();
        }
    }

    void Victory()
    {
        SceneManager.LoadScene("VictoryScreen");
    }
}
