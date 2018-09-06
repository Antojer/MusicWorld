using UnityEngine;
using System.IO;

public class LoadStats : MonoBehaviour {
   
    public Character c;
    private string _sPath;
    private string _sJsonString;

    void Start () {
        _sPath = Path.Combine(Application.streamingAssetsPath, "character.json");
        if (Application.platform == RuntimePlatform.Android)
        {      
            // Android only use WWW to read file
            WWW reader = new WWW(_sPath);
            while (!reader.isDone) { }//cutrez, IEnumerator yield
            _sJsonString = reader.text;
        }
        else
            _sJsonString = File.ReadAllText(_sPath);

        c = JsonUtility.FromJson<Character>(_sJsonString);
        this.GetComponent<Movement>().enabled = true;
        this.GetComponent<HealthPointController>().enabled = true;
    }

    [System.Serializable]
    public class Character
    {
        public float fDamage;
        public float fMovementSpeed;
        public float fShotForce;
        public float fShotSize;
        public float fRange;
        public int iHealthPoints;
    }
}
