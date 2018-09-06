using UnityEngine;

public class PreserveItemGenerator : MonoBehaviour {

    private static PreserveItemGenerator _instance;
    void Awake()
    {
        if (!_instance)
            _instance = this;
        //otherwise, if we do, kill this thing
        else
            Destroy(this.gameObject);


        DontDestroyOnLoad(this.gameObject);
    }
}
