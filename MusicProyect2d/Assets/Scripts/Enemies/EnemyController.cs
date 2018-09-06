using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float hp;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "mainNote")
        {
            hp--;
            Destroy(coll.gameObject);
            if (hp <= 0)
            {
                this.GetComponentInParent<GenerateEnemies>().iEnemyCount--;
                Destroy(this.gameObject);
            }
        }
    }
}
