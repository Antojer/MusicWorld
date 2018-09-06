using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class LoadItems : MonoBehaviour {

    public Items oItems;
    public GameObject goMainCharacter;
    public GameObject goItemGenerator;
    private string _sPath;
    private string _sJsonString;

    void Start()
    {
        _sPath = Path.Combine(Application.streamingAssetsPath, "items.json");
        if (Application.platform == RuntimePlatform.Android)
        {
            // Android only use WWW to read file
            WWW reader = new WWW(_sPath);
            while (!reader.isDone) { }//cutrez, IEnumerator yield
            _sJsonString = reader.text;
        }
        else
            _sJsonString = File.ReadAllText(_sPath);
        oItems = JsonUtility.FromJson<Items>(_sJsonString);
        goMainCharacter.GetComponent<PickItem>().enabled = true;
    }

    [System.Serializable]
    public class Items
    {
        public List<Item> items;
    }

    [System.Serializable]
    public class Item
    {
        public string sName;
        public float fDamage;
        public float fMovementSpeed;
        public float fShotForce;
        public float fShotSize;
        public float fRange;
        public int iHP;
    }
}
