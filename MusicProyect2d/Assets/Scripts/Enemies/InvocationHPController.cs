using UnityEngine;
using UnityEngine.UI;

public class InvocationHPController : MonoBehaviour {

    public float fHp;
    public Image hpBar;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainNote")
        {
            LoadStats l = GameObject.Find("/MainCharacter").GetComponent<LoadStats>();
            hpBar.transform.localScale = new Vector3((fHp - l.c.fDamage) / fHp, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            fHp -= l.c.fDamage;
            Destroy(coll.gameObject);

            if (fHp <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
