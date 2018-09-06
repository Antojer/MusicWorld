﻿using UnityEngine;
using UnityEngine.UI;

public class BossHPController : MonoBehaviour
{

    public float fHp;
    public GameObject hpBarCanvas;
    public Image hpBar;
    private bool _bEntered = false;
    private DisplayController _dpController;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainNote")
        {
            LoadStats l = GameObject.Find("/MainCharacter").GetComponent<LoadStats>();
            hpBar.transform.localScale = new Vector3((fHp - l.c.fDamage) / fHp, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
            fHp -= l.c.fDamage;
            Destroy(coll.gameObject);
            if (fHp <= 0 && _bEntered == false)
            {
                _dpController = GameObject.Find("/CanvasUI").transform.Find("Display").GetComponent<DisplayController>();
                ++_dpController.totalKilled;
                _bEntered = true;
                this.gameObject.transform.parent.GetComponentInParent<BossGeneratorAndController>().iEnemyCount--;
                GameObject.Find("/ItemGenerator").GetComponent<GenerateItem>().generateItemHere(this.transform);
                Destroy(hpBarCanvas);
                Destroy(this.gameObject);
            }
        }
    }
}