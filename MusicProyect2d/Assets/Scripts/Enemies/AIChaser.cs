using UnityEngine;
using System.Collections.Generic;

public class AIChaser : MonoBehaviour
{

    public int iPlayerCurrentBox;
    public float fSpeed;
    private Transform _goParent;
    private AIMapping tpm;
    private int iCurrentBox;
    private bool _bStarted;
    private List<int> _aPath;
    private float _fStartChasingTimer = 0.8f;

    void Start()
    {
        _aPath = new List<int>();
        _bStarted = false;
        _goParent = this.transform.parent.transform.parent;            
        if (this.name == "SingerCompanion" || this.name == "SingerCompanion 1" || this.name == "SingerCompanion 2" || this.name == "SingerCompanion 3")
            tpm = _goParent.transform.parent.Find("movementMatrix").GetComponent<AIMapping>() as AIMapping;
        else
            tpm = _goParent.Find("movementMatrix").GetComponent<AIMapping>();
        iPlayerCurrentBox = tpm.iTargetBoxIndex;
    }

    void FixedUpdate()
    {
        if (this.name == "SingerCompanion" || this.name == "SingerCompanion 1" || this.name == "SingerCompanion 2" ||  this.name == "SingerCompanion 3")
            tpm = _goParent.transform.parent.Find("movementMatrix").GetComponent<AIMapping>() as AIMapping;
        else
            tpm = _goParent.Find("movementMatrix").GetComponent<AIMapping>() as AIMapping;
        if (iPlayerCurrentBox != tpm.iTargetBoxIndex)
        {
            iPlayerCurrentBox = tpm.iTargetBoxIndex;
            PathFinder();
        }
        if (_bStarted)
            if(_fStartChasingTimer<=0)
                moveToNextBox();
        if(_fStartChasingTimer>0)
            _fStartChasingTimer -= Time.deltaTime;
    }

    void PathFinder()
    {
        int v;
        v = iCurrentBox;//cambiar por posición actual del enemigo
        _aPath.Clear();
        //recuperamos el camino más corto entre enemigo y objetivo;
        do
        {
            _aPath.Add(tpm.aaAllPaths[iPlayerCurrentBox, v]);
            v = tpm.aaAllPaths[iPlayerCurrentBox, v];
        } while (v != iPlayerCurrentBox);
        _aPath.Add(iPlayerCurrentBox);
        _bStarted = true;
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "matrixBox")
        {
            //Buscamos el índice del elemento con nombre igual a la casilla con la que el enemigo se encuentra
            iCurrentBox = tpm.agoBoxes.FindIndex(x => x.gameObject.name == coll.gameObject.name);
            if (!_bStarted)
            {
                PathFinder();
            }
        }
    }

    void moveToNextBox()
    {
        Vector2 thisPosition = new Vector2(tpm.agoBoxes[iCurrentBox].transform.position.x, tpm.agoBoxes[iCurrentBox].transform.position.y);
        Vector2 targetPosition = new Vector2(tpm.agoBoxes[_aPath[0]].transform.position.x, tpm.agoBoxes[_aPath[0]].transform.position.y);
        this.transform.Translate((targetPosition - thisPosition).normalized * fSpeed);
        if (_aPath[0] == iPlayerCurrentBox)
            _aPath.Add(iPlayerCurrentBox);
        if (Vector2.Distance(thisPosition, targetPosition)<0.2)
            _aPath.RemoveAt(0);  
    }
}

