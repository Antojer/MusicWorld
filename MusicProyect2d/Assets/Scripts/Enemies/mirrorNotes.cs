using UnityEngine;

public class mirrorNotes : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainNote")
        {
            coll.tag = "enemyShot";
            coll.transform.parent.tag = "enemyShot";
            coll.gameObject.layer = 11;
            coll.transform.parent.gameObject.layer = 11;
            Rigidbody2D notaInstance;
            notaInstance = Instantiate(coll.transform.parent.gameObject.GetComponent<Rigidbody2D>(), this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance.GetComponent<DestroyNote>().fDestructionTimer = 1.2f;
            notaInstance.velocity = -coll.transform.parent.GetComponent<Rigidbody2D>().velocity;
            Destroy(coll.transform.parent.gameObject);
        }
    }
}
