using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    public string sceneName;

    private AssetBundle myLoadedAssetBundle;
    private string[] scenePaths;

  //  void Start()
  //  {
  //      myLoadedAssetBundle = AssetBundle.LoadFromFile("Assets/Scenes");
  //      scenePaths = myLoadedAssetBundle.GetAllScenePaths();
  //  }

    public void Play()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

     public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Quit");
        }
}
