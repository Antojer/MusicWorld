using UnityEngine;

public class MultipleShot : MonoBehaviour {

    public GameObject goTarget;
    public Rigidbody2D rbNote;
    public float fShotSize;
    public float fShotForce;
    public float fInstantiatorTimer;
    public float fShotDistance;
    public float fNoteDestructionTimer;
    public int shotsNumber;
    public float fmultipleShotTimer;
    private float _fInstantiatorTimerAux;
    private float _fStartShootingTimer = 0.8f;
    private float _fmultipleShotTimerAux;
    private int _iShots;

    // Use this for initialization
    void Start()
    {
        goTarget = GameObject.Find("/MainCharacter");
        _fInstantiatorTimerAux = 1f;
        _iShots = 0;
        if (fmultipleShotTimer == 0)
            fmultipleShotTimer = 0.2f;
        _fmultipleShotTimerAux = fmultipleShotTimer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_fStartShootingTimer > 0)
            _fStartShootingTimer -= Time.deltaTime;
        if (_fStartShootingTimer <= 0)
            if (Vector2.Distance(goTarget.transform.position, this.transform.position) < fShotDistance)
            {
                _fInstantiatorTimerAux -= Time.deltaTime;
                if (_fInstantiatorTimerAux <= 0)
                {
                    _fmultipleShotTimerAux -= Time.deltaTime;
                    if (_iShots < shotsNumber && _fmultipleShotTimerAux <= 0 && _fInstantiatorTimerAux<=0)
                    {
                        Rigidbody2D notaInstance;
                        notaInstance = Instantiate(rbNote, this.transform.position, this.transform.rotation) as Rigidbody2D;
                        notaInstance.GetComponent<DestroyNote>().fDestructionTimer = fNoteDestructionTimer;
                        notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                        Vector2 v = goTarget.transform.position - this.transform.position;
                        v = v.normalized;
                        notaInstance.velocity = (new Vector2(v.x * fShotForce, v.y * fShotForce));
                        _fmultipleShotTimerAux = fmultipleShotTimer;
                        _iShots++;
                    }
                    if(_iShots>= shotsNumber)
                    {
                        _iShots = 0;
                        _fInstantiatorTimerAux = fInstantiatorTimer;
                    }
                }
            }
    }
}
