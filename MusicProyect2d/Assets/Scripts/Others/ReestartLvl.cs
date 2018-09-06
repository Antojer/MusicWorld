using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReestartLvl : MonoBehaviour {

    private AsyncOperation asyncLoad;


    // Use this for initialization
    void Start () {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        asyncLoad = SceneManager.LoadSceneAsync("lvl1");
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.isDone)
        {
            yield return null;
        }
        Debug.Log("dsd");
        Destroy(GameObject.Find("/MainCharacter"));
        Destroy(GameObject.Find("/CanvasUI"));
        Destroy(GameObject.Find("/Main Camera"));
        Destroy(GameObject.Find("/ItemGenerator"));
        Destroy(GameObject.Find("/ItemsLoadManager"));
        asyncLoad.allowSceneActivation = true;
    }
}
