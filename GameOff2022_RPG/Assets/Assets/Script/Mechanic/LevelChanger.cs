using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    [SerializeField]
    public string nextLevelName;
    private int x = 1;
    void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
            //If the GameObject has the same tag as specified, output this message in the console
                if(x == 1)
                {
                    SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
                    Debug.Log("CHANGEMENT DE NIVEAU");
                }
                else
                {
                    Debug.Log("CONDITIONS NON REMPLIS");
                }
            }
    }
}
