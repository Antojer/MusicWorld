using UnityEngine;

public class ShotToTarget : MonoBehaviour {

    public GameObject goTarget;
    public Rigidbody2D rbNote;
    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public float fShotDistance;
    public float fNoteDestructionTimer;
    private float _fInstantiatorTimerAux;
    private float _fStartShootingTimer = 0.8f;

    // Use this for initialization
    void Start () {
        goTarget = GameObject.Find("/MainCharacter");
        _fInstantiatorTimerAux = 1.5f;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_fStartShootingTimer > 0)
            _fStartShootingTimer -= Time.deltaTime;
        if(_fStartShootingTimer<=0)
            if (Vector2.Distance(goTarget.transform.position, this.transform.position) < fShotDistance)
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
                    notaInstance.velocity = (new Vector2(v.x * fShotForce,v.y * fShotForce));
                    _fInstantiatorTimerAux = fInstantiatorTimer;
                }
            }
	}
}
