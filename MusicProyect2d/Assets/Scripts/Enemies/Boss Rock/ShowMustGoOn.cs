
using UnityEngine;

public class ShowMustGoOn: MonoBehaviour {

    public Rigidbody2D rbNote;
    public float fInstantiatorTimer;
    private Animator _mercuryAnim;
    private float _fStartShootingTimer = 3f;
    public float fShotSize;
    public float fmultipleShotTimer;
    public int shotsNumber;
    private float _fmultipleShotTimerAux;
    private float _fInstantiatorTimerAux;
    private int _iShots;
    private bool _playingAnim;

    // Use this for initialization
    void Start () {
        _mercuryAnim = this.transform.parent.GetComponent<Animator>();
        _playingAnim = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (_fStartShootingTimer > 0)
            _fStartShootingTimer -= Time.deltaTime;
        if (_fStartShootingTimer <= 0) {
            _fInstantiatorTimerAux -= Time.deltaTime;
            if (_fInstantiatorTimerAux <= 0)
            {
                if (!_playingAnim)
                {
                    _mercuryAnim.Play("ShowMustGoOn");
                    _playingAnim = true;
                }
                _fmultipleShotTimerAux -= Time.deltaTime;
                if (_iShots < shotsNumber && _fmultipleShotTimerAux <= 0 && _fInstantiatorTimerAux <= 0)
                {
                    Rigidbody2D notaInstance;
                    int x = Random.Range(-6, 6);
                    int y = Random.Range(-3, 4);
                    Vector2 v = new Vector2(this.transform.position.x+x,this.transform.position.y+y);
                    notaInstance = Instantiate(rbNote, v, this.transform.rotation) as Rigidbody2D;
                    notaInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                    _fmultipleShotTimerAux = fmultipleShotTimer;
                    _iShots++;
                }
                if (_iShots >= shotsNumber)
                {
                    _iShots = 0;
                    _fInstantiatorTimerAux = fInstantiatorTimer;
                    _playingAnim = false;
                    _mercuryAnim.Play("Normal");
                }
            }

        }

    }
}
