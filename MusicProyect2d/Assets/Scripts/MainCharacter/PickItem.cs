
using UnityEngine;

public class PickItem : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        
        LoadItems l = GameObject.Find("/ItemsLoadManager").GetComponent<LoadItems>();
        int i = 0;
        while (i < l.oItems.items.Count && l.oItems.items[i].sName != coll.gameObject.tag)
            ++i;
        if (i != l.oItems.items.Count)
        {
            if(l.oItems.items[i].sName!="gloves" && l.oItems.items[i].sName != "godsLanguage")
                this.transform.Find("Items").transform.Find(l.oItems.items[i].sName).gameObject.SetActive(true);
            LoadStats d = this.GetComponent<LoadStats>();
            Movement m = this.GetComponent<Movement>();
            d.c.fDamage += l.oItems.items[i].fDamage;
            d.c.fShotForce += l.oItems.items[i].fShotForce;
            d.c.fShotSize += l.oItems.items[i].fShotSize;
            m.fDeltaMovement += l.oItems.items[i].fMovementSpeed;
            d.c.fRange += l.oItems.items[i].fRange;
            if (l.oItems.items[i].iHP > 0)
            {
                HealthPointController c = this.GetComponent<HealthPointController>();
                for (int j=0;j< l.oItems.items[i].iHP; j++)
                    c.addHP();
            }
            Destroy(coll.gameObject);
        }
    }
}
