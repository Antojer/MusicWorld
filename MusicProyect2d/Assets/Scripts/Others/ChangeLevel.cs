using UnityEngine;

public class ChangeLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainCharacter")
            GameObject.Find("/InitialRoom").GetComponent<StartLvl>().asyncLoad.allowSceneActivation = true;
    }
}
