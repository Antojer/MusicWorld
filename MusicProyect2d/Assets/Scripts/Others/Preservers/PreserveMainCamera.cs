using UnityEngine;

public class PreserveMainCamera : MonoBehaviour {

    private static PreserveMainCamera  _instance;
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
