using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLvl : MonoBehaviour {

    public AsyncOperation asyncLoad;
    public int iLvl;

    // Use this for initialization
    void Start () {
        Scene s = SceneManager.GetActiveScene();
        if (s.name == "lvl1")
            GameObject.Find("ItemGenerator").GetComponent<GenerateItem>().generateItemInThisPosition(new Vector2(-4.44f, 10.07f));
        else
        {
            GameObject.Find("MainCharacter").transform.position = new Vector2(-4.75f, 9);
            GameObject.Find("/Main Camera").transform.position = new Vector3(-4.37f, 10.2f, -10);
            GameObject.Find("ItemGenerator").GetComponent<GenerateItem>().generateItemInThisPosition(new Vector2(-4.44f, 12.07f));
        }
        StartCoroutine(waitToStart());
    }

    IEnumerator waitToStart()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(LoadSceneAsync());   
    }

    IEnumerator LoadSceneAsync()
    {
        asyncLoad = SceneManager.LoadSceneAsync("lvl" + iLvl);
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
