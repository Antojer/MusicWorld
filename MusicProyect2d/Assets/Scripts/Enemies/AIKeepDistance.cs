using UnityEngine;

public class AIKeepDistance : MonoBehaviour {

    public float fSpeed;
    private GameObject _goTarget;
    private float _fStartChasingTimer = 0.8f;

    // Use this for initialization
    void Start () {
        _goTarget = GameObject.Find("/MainCharacter");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (_fStartChasingTimer <= 0)
        {
            if (Vector2.Distance(this.transform.position, _goTarget.transform.position) < 4)
            {
                Vector2 thisPosition = new Vector2(this.transform.position.x, this.transform.position.y);
                Vector2 targetPosition = new Vector2(_goTarget.transform.position.x, _goTarget.transform.position.y);
                this.transform.Translate((thisPosition - targetPosition).normalized * fSpeed);
            }
        }
        if (_fStartChasingTimer > 0)
            _fStartChasingTimer -= Time.deltaTime;
        
    }

}
