using UnityEngine;

public class AvoidShots : MonoBehaviour {

    public float fSpeed;
    private GameObject _goCentralBox;
    private GameObject _goNoteToAvoid;
    private float _fTimer;
    private bool _bResetPosition;
    private float avoidCoolDown;
    private Animator _eminemAnim;

    void Start()
    {
        _goCentralBox = this.transform.parent.transform.parent.Find("movementMatrix/Square (27)").gameObject;
        _eminemAnim = this.GetComponent<Animator>();
        _fTimer = 0f;
        _bResetPosition = false;
        avoidCoolDown = 0f;
    }

    void Update () {
        if (avoidCoolDown > 0)
        {
            avoidCoolDown -= Time.deltaTime;
            _eminemAnim.Play("Normal");
        }
        else
        {
            if (_bResetPosition)
            {
                if (Vector2.Distance(_goCentralBox.transform.position, this.transform.position) > 0.3)
                {
                    this.transform.Translate((_goCentralBox.transform.position - this.transform.position).normalized * fSpeed);
                    _eminemAnim.Play("walking");
                }
                _fTimer -= (Time.deltaTime+0.05f);
                if (_fTimer <= 0)
                {
                    _bResetPosition = false;
                    avoidCoolDown = 2f;
                }
            }
            if (!_bResetPosition)
            {
                if (GameObject.Find("/MainCharacter/Items/queenvinyl").gameObject.activeSelf)
                    _goNoteToAvoid = GameObject.Find("NotesVinyl(Clone)");
                else
                    _goNoteToAvoid = GameObject.Find("Notes(Clone)");
                if (_goNoteToAvoid != null)
                {
                    if (Vector2.Distance(this.transform.position, _goNoteToAvoid.transform.position) < 3)
                    {
                        _eminemAnim.Play("walking");
                        this.transform.Translate((this.transform.position - _goNoteToAvoid.transform.position).normalized * fSpeed);
                    }
                    else
                    {
                        _eminemAnim.Play("Normal");
                    }
                }
                _fTimer += 0.05f;
                if (_fTimer >= 12)
                    _bResetPosition = true;
            }
        }
    }
}
