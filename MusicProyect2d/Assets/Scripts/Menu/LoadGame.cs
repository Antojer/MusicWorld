using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{

    public GameObject bttButtons;
    public GameObject loadingScreen;
    private AsyncOperation asyncLoad;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    public void play()
    {
        bttButtons.GetComponent<Animator>().Play("buttons");
        StartCoroutine(waitForAnimation());
        asyncLoad.allowSceneActivation = true;
    }

    IEnumerator waitForAnimation()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(waitForAnimation());
        loadingScreen.SetActive(true);
        bttButtons.GetComponent<Animator>().Play("Loading");
    }

    IEnumerator LoadSceneAsync()
    {
        asyncLoad = SceneManager.LoadSceneAsync("lvl1");
        asyncLoad.allowSceneActivation = false;
        while (asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
