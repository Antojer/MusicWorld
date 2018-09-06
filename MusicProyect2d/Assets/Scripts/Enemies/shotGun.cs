using UnityEngine;

public class shotGun : MonoBehaviour {

    public GameObject goTarget;
    public Rigidbody2D rbNote;
    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public float fShotDistance;
    public float fNoteDestructionTimer;
    private float _fInstantiatorTimerAux;
    private float _fStartShootingTimer = 0.8f;

    void Start () {
        goTarget = GameObject.Find("/MainCharacter");
        _fInstantiatorTimerAux = 2f;
    }

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
                Rigidbody2D notaInstance2;
                Rigidbody2D notaInstance3;
                Vector2 v;
                Vector3 vaux;

                notaInstance = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                v = goTarget.transform.position - this.transform.position;
                v = v.normalized;
                notaInstance.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));

                notaInstance2 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance2.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance2.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                
                vaux = new Vector3(goTarget.transform.position.x - 1, goTarget.transform.position.y + 1);
                v = vaux  - this.transform.position;
                v = v.normalized;
                notaInstance2.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));

                notaInstance3 = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                notaInstance3.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                notaInstance3.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                vaux = new Vector3(goTarget.transform.position.x + 1, goTarget.transform.position.y - 1);
                v = vaux - this.transform.position;
                v = v.normalized;
                notaInstance3.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                _fInstantiatorTimerAux = fInstantiatorTimer;
            }
        }
    }
}
