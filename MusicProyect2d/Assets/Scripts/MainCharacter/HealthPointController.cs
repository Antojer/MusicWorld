using UnityEngine;
using System.Collections.Generic;

public class HealthPointController : MonoBehaviour {
    public Transform hpInstantiator;
    public GameObject hpObject;
    public GameObject goGameOver;
    public GameObject goShotpad;
    private int hp;
    private List<GameObject> createdHearts;
    private float InstantiationTimer = 1f;

    void Start () {
        hp = 0;
        createdHearts = new List<GameObject>();
        LoadStats loadStats = this.GetComponent<LoadStats>();
        for (int i = 0; i < loadStats.c.iHealthPoints; i++)
            addHP();
    }
	
    void FixedUpdate()
    {
        InstantiationTimer -= Time.deltaTime;
    }

    public void addHP()
    {
        hp += 1;
        GameObject hpInstance;
        hpInstance = Instantiate(hpObject, hpInstantiator.position, hpInstantiator.rotation) as GameObject;
        hpInstance.transform.SetParent(GameObject.Find("CanvasUI").transform);
        createdHearts.Add(hpInstance);
        hpInstantiator.position = new Vector2(hpInstantiator.position.x + 65.0f, hpInstantiator.position.y);
    }

    public void subHP()
    {
        Destroy(createdHearts[hp - 1]);
        createdHearts.Remove(createdHearts[hp - 1]);
        hpInstantiator.position = new Vector2(hpInstantiator.position.x - 65.0f, hpInstantiator.position.y);
        if (hp - 1 > 0)
        {
            hpInstantiator.position = new Vector2(hpInstantiator.position.x - 1.0f, hpInstantiator.position.y);
            hp -= 1;
        }
        else
        {
            this.GetComponent<Movement>().enabled = false;
            this.transform.Find("leftHead").gameObject.SetActive(false);
            this.transform.Find("rightHead").gameObject.SetActive(false);
            this.transform.Find("backHead").gameObject.SetActive(false);
            this.transform.Find("frontHead").gameObject.SetActive(true);
            this.transform.Find("frontHeadDead").gameObject.SetActive(true);
            goShotpad.SetActive(false);
            goGameOver.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemyShot")
        {
            Destroy(coll.gameObject);
            if (InstantiationTimer <= 0)
            {
                InstantiationTimer = 1f;
                subHP();
            }
        }
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "enemy" || coll.gameObject.tag == "enemyGiantShot")
        {        
            if (InstantiationTimer <= 0)
            {
                InstantiationTimer = 1f;
                subHP();       
            }
        }
        if (coll.gameObject.tag == "extraHP")
        {
            if (hp < 12)
            {
                Destroy(coll.gameObject);
                addHP();
            }
        }
    }
}
