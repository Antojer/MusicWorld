using UnityEngine;

public class Pause : MonoBehaviour {

    public GameObject goVirtualJoystic;
    public GameObject goShotJoystic;
    private bool pause  = false;

    public void setPause()
    {
        pause = !pause;
        if (pause)
        {
            Time.timeScale = 1;
            transform.Find("Playing").gameObject.SetActive(true);
            transform.Find("Paused").gameObject.SetActive(false);
            goVirtualJoystic.gameObject.SetActive(true);
            goShotJoystic.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0;
            transform.Find("Playing").gameObject.SetActive(false);
            transform.Find("Paused").gameObject.SetActive(true);
            goVirtualJoystic.gameObject.SetActive(false);
            goShotJoystic.gameObject.SetActive(false);
        }
    }
}
