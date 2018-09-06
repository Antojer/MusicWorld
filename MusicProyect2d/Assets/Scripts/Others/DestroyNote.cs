using UnityEngine;

public class DestroyNote : MonoBehaviour {

    public float fDestructionTimer;
	// Use this for initialization
	void Start () {
        if(this.tag=="enemyShot" || this.tag == "enemyGiantShot")
		    Destroy (gameObject, fDestructionTimer);
        else
        {
            LoadStats d = GameObject.Find("/MainCharacter").GetComponent<LoadStats>();
            fDestructionTimer = d.c.fRange;
            Destroy(gameObject, fDestructionTimer);
        }

	}
}
