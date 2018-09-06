using UnityEngine;

public class exShot : MonoBehaviour {

    public Rigidbody2D rbNote;
    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public float fShotDistance;
    public float fNoteDestructionTimer;
    private float _fInstantiatorTimerAux;
    private float _fStartShootingTimer = 0.8f;

    // Use this for initialization
    void Start()
    {
        _fInstantiatorTimerAux = 2f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_fStartShootingTimer > 0)
            _fStartShootingTimer -= Time.deltaTime;
        if (_fStartShootingTimer <= 0)
        {
            _fInstantiatorTimerAux -= Time.deltaTime;
            if (_fInstantiatorTimerAux <= 0)
            {
                Rigidbody2D notaInstance;
                Rigidbody2D notaInstance1;
                Rigidbody2D notaInstance2;
                Rigidbody2D notaInstance3;
                Vector2 v;
                //instanciación primera nota, hacia arriba-izquierda
                notaInstance = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                v = Vector2.up + Vector2.left;
                v = v.normalized;
                notaInstance.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                //instanciación primera nota, hacia arriba-derecha
                notaInstance1 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance1.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance1.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                v = Vector2.up + Vector2.right;
                v = v.normalized;
                notaInstance1.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                //instanciación primera nota, hacia abajo-izquierda
                notaInstance2 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance2.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance2.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                v = Vector2.down + Vector2.left;
                v = v.normalized;
                notaInstance2.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                //instanciación primera nota, hacia abajo-derecha
                notaInstance3 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance3.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance3.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                v = Vector2.down + Vector2.right;
                v = v.normalized;
                notaInstance3.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                _fInstantiatorTimerAux = fInstantiatorTimer;
            }
        }
    }
}
