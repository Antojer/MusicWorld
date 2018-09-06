using UnityEngine;
using System.Collections;
public class ExplosiveDash : MonoBehaviour {

    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public Rigidbody2D rbNote;
    public float fNoteDestructionTimer;
    public float fSpeed;
    private float _fInstantiatorTimerAux;
    private GameObject _goTarget;
    private bool _dashing;
    private Vector3 _targetPos;

    // Use this for initialization
    void Start () {
        _fInstantiatorTimerAux = 1.5f;
        _dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fInstantiatorTimerAux > 0)
        {
            this.GetComponent<Animator>().Play("normal");
            _fInstantiatorTimerAux -= Time.deltaTime;
        }
        if (_fInstantiatorTimerAux <= 0)
        {
            _goTarget = GameObject.Find("/MainCharacter");
            if (!_dashing)
            {
                _dashing = true;
                _targetPos = _goTarget.transform.position;
            }

            this.transform.Translate((_targetPos-this.transform.position).normalized*fSpeed);
            StartCoroutine(waitForDash());
        }
    }

    IEnumerator waitForDash()
    {
        yield return new WaitForSeconds(0.9f);
        StartCoroutine(waitForAttack());
    }

    IEnumerator waitForAttack()
    {
        this.GetComponent<Animator>().Play("slashAttack");
        yield return new WaitForSeconds(0.3f);
        circleShots();
    }

    void circleShots()
    {
        if (_fInstantiatorTimerAux <= 0)
        {
            Rigidbody2D notaInstance;
            Rigidbody2D notaInstance2;
            Rigidbody2D notaInstance3;
            Rigidbody2D notaInstance4;
            Rigidbody2D notaInstance5;
            Rigidbody2D notaInstance6;
            Rigidbody2D notaInstance7;
            Rigidbody2D notaInstance8;
            Vector2 v;
            //instanciación primera nota, hacia arriba
            notaInstance = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.up;
            v = v.normalized;
            notaInstance.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia izquierda
            notaInstance2 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance2.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance2.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.left;
            v = v.normalized;
            notaInstance2.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia derecha
            notaInstance3 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance3.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance3.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.right;
            v = v.normalized;
            notaInstance3.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia abajo
            notaInstance4 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance4.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance4.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.down;
            v = v.normalized;
            notaInstance4.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia arriba-izquierda
            notaInstance5 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance5.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance5.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.up + Vector2.left;
            v = v.normalized;
            notaInstance5.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia arriba-derecha
            notaInstance6 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance6.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance6.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.up + Vector2.right;
            v = v.normalized;
            notaInstance6.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia abajo-izquierda
            notaInstance7 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance7.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance7.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.down + Vector2.left;
            v = v.normalized;
            notaInstance7.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            //instanciación primera nota, hacia abajo-derecha
            notaInstance8 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance8.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance8.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            v = Vector2.down + Vector2.right;
            v = v.normalized;
            notaInstance8.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            _fInstantiatorTimerAux = fInstantiatorTimer;
            _dashing = false;
        }
    }
}
