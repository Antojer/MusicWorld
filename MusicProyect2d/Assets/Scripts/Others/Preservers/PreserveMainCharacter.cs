using UnityEngine;

public class PreserveMainCharacter: MonoBehaviour
{
    private static PreserveMainCharacter _instance;
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
