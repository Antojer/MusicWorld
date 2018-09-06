using UnityEngine;

public class BossAttacks : MonoBehaviour {

    public GameObject goTarget;
    public Rigidbody2D rbNote;
    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public float fShotDistance;
    public float fNoteDestructionTimer;
    private GameObject _goBox1;
    private GameObject _goBox2;
    public GameObject goZombie;
    private float _fInstantiatorTimerAux;
    private float _fStartAttackTimer = 1f;
    private GameObject _goEnemyInstance;
    private GameObject _goEnemyInstance1;
    private float _fInvocationTimer;

    // Use this for initialization
    void Start () {
        goTarget = GameObject.Find("/MainCharacter");
        _fInstantiatorTimerAux = 1.5f;
        _goBox1 = this.transform.parent.transform.parent.Find("movementMatrix").transform.Find("Square (46)").gameObject;
        _goBox2 = this.transform.parent.transform.parent.Find("movementMatrix").transform.Find("Square (51)").gameObject;
        _fInvocationTimer = 0f;
        this.transform.parent.GetComponent<Animator>().Play("MJackson");
    }
	
	// Update is called once per frame
	void Update () {
        if (_fStartAttackTimer > 0)
            _fStartAttackTimer -= Time.deltaTime;
        if (_fStartAttackTimer <= 0)
        {
            int iRandom = Random.Range(1, 4);
            if (iRandom==1)
                shotTarget();
            if (iRandom == 2)
                allDirectionShots();
            if (iRandom == 3)
                callZombies();
        }
    }

    void shotTarget()
    {
        _fInstantiatorTimerAux -= Time.deltaTime;
        if (_fInstantiatorTimerAux <= 0)
        {
            Rigidbody2D notaInstance;
            notaInstance = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
            notaInstance.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
            notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
            Vector2 v = goTarget.transform.position - this.transform.position;
            v = v.normalized;
            notaInstance.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
            _fInstantiatorTimerAux = fInstantiatorTimer;
        }
    }

    void allDirectionShots()
    {
        _fInstantiatorTimerAux -= Time.deltaTime;
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
            v = Vector2.up+Vector2.left;
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
        }
    }

    void callZombies()
    {
        _fInvocationTimer = _fInvocationTimer - Time.deltaTime;
        if (_fInvocationTimer<=0)
        {
            _goEnemyInstance = Instantiate(goZombie, _goBox1.transform.position, this.transform.rotation);
            _goEnemyInstance.transform.parent = this.transform.parent.transform.parent.Find("enemyGenerator");
            _goEnemyInstance1 = Instantiate(goZombie, _goBox2.transform.position, this.transform.rotation);
            _goEnemyInstance1.transform.parent = this.transform.parent.transform.parent.Find("enemyGenerator");
            _fInstantiatorTimerAux = fInstantiatorTimer + 0.4f;
            _fInvocationTimer = 14.7f;
        }
    }
}
