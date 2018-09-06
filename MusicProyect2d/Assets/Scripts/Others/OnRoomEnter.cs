using UnityEngine;

public class OnRoomEnter : MonoBehaviour {
    GenerateObstacle gObs;
    GenerateEnemies gEnm;
    void Start()
    {
        gObs = this.GetComponentInChildren<GenerateObstacle>();
        gEnm = this.GetComponentInChildren<GenerateEnemies>();
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (this.enabled)
        {
            gObs = this.GetComponentInChildren<GenerateObstacle>();
            gEnm = this.GetComponentInChildren<GenerateEnemies>();
            if (coll.tag == "mainCharacter" && gEnm.bGenerated == false)
            {
                coll.GetComponent<ChangeRoom>().enabled = false;
                gEnm.generateEnemies();
                gObs.generateObstacles();
            }
            if (coll.tag == "mainCharacter" && gEnm.bGenerated == true && gEnm.iEnemyCount == 0)
            {
                coll.GetComponent<ChangeRoom>().enabled = true;
                this.GetComponent<OnRoomEnter>().enabled = false;
            }
        }
    }
}
