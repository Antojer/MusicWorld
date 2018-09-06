using UnityEngine;
using UnityEngine.UI;

public class DisplayController : MonoBehaviour {
    public int totalKilled;
    public float minutes;
    public float seconds;
    public bool stopChrono;
    private float _deltaTime;
    private Text _totalKilledText;
    private Text _timeText;

    // Use this for initialization
    void Start () {
        stopChrono = false;
        totalKilled = 0;
        _deltaTime = Time.deltaTime;
        _totalKilledText = this.transform.Find("totalDefeated").GetComponent<Text>();
        _timeText = this.transform.Find("totalTime").GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!stopChrono) { 
            _deltaTime += Time.deltaTime;
            minutes = Mathf.Floor(_deltaTime / 60);
            seconds = (_deltaTime % 60);
            _timeText.text = (minutes.ToString("00") + ":" + seconds.ToString("00"));
            _totalKilledText.text = totalKilled.ToString();
        }
    }
}
