using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class RankingController : MonoBehaviour {

    private DisplayController _dpController;
    private float _minutes;
    private float _seconds;
    private int _totalKilled;
    private int _points;
    private string _sPath;
    private string _sJsonString;
    private Ranking _rank;


    // Use this for initialization
    void Start () {
       // initializer();
        //cleanComponents();
        loadRanking();
        calculatePointsAndSave();
        loadRanking();
    }

    [System.Serializable]
    public class Ranking
    {
        public List<Player> ranking;
    }

    [System.Serializable]
    public class Player
    {
        public int position;
        public int points;
    }

    private void initializer()
    {
        _dpController = GameObject.Find("/CanvasUI").transform.Find("Display").GetComponent<DisplayController>();
        _minutes = _dpController.minutes;
        _seconds = _dpController.seconds;
        _totalKilled = _dpController.totalKilled;
        _dpController.stopChrono = true;
    }

    private void cleanComponents()
    {
        Destroy(GameObject.Find("/MainCharacter"));
        Destroy(GameObject.Find("/CanvasUI"));
        Destroy(GameObject.Find("/Main Camera"));
        Destroy(GameObject.Find("/ItemGenerator"));
        Destroy(GameObject.Find("/ItemsLoadManager"));
    }

    private void loadRanking()
    {
        _sPath = Path.Combine(Application.streamingAssetsPath, "ranking.json");
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android only use WWW to read file
            WWW reader = new WWW(_sPath);
            while (!reader.isDone) { }//cutrez, IEnumerator yield
            _sJsonString = reader.text;
        }
        else
            _sJsonString = File.ReadAllText(_sPath);
        _rank = JsonUtility.FromJson<Ranking>(_sJsonString);

        this.transform.Find("first").GetComponent<Text>().text = _rank.ranking[0].position+"     " + _rank.ranking[0].points;
        this.transform.Find("second").GetComponent<Text>().text = _rank.ranking[1].position + "     " + _rank.ranking[1].points;
        this.transform.Find("third").GetComponent<Text>().text = _rank.ranking[2].position + "     " + _rank.ranking[2].points;
    }

    private void calculatePointsAndSave()
    {
        _totalKilled = 10;
        _minutes = 6;
        _seconds = 54;
        _points = _totalKilled * 1000 + (int)(1 / ((_minutes * 60) + _seconds))*100000;
        bool setted = false;
        for(int i = 0; i < _rank.ranking.Count; ++i)
        {
            if (_points > _rank.ranking[i].points && !setted) {
                _rank.ranking[i].points = _points;
                setted = true;
            }
        }
        string json = JsonUtility.ToJson(_rank);
        File.WriteAllText(_sPath,json);
    }

}
