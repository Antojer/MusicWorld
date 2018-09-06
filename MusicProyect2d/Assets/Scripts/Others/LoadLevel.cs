using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {
    public void loadMenu()
    {
        SceneManager.LoadScene("menu");
    }

    public void loadRanking()
    {
        Destroy(GameObject.Find("/MainCharacter"));
        Destroy(GameObject.Find("/CanvasUI"));
        Destroy(GameObject.Find("/Main Camera"));
        Destroy(GameObject.Find("/ItemGenerator"));
        Destroy(GameObject.Find("/ItemsLoadManager"));
        SceneManager.LoadScene("lvl4");
    }

    public void loadLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }

    public void loadLevel3()
    {
        SceneManager.LoadScene("lvl3");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("loadingScreen");
    }
}
