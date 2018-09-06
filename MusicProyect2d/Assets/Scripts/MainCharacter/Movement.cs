using UnityEngine;

public class Movement : MonoBehaviour {
    public Animator anmWalk;
    public float fDeltaMovement;
    public float fDrag = 0.5f;
    public Vector2 aMoveVector { set; get; }
    public VirtualJoystick joystick;

    void Start()
    {
        LoadStats l = this.GetComponent<LoadStats>();
        fDeltaMovement = l.c.fMovementSpeed;
    }

    void Update () {
        aMoveVector = PoolInput();
        MovementAndroid();          
    }

    void MovementAndroid()
    {
        this.transform.Translate(aMoveVector * fDeltaMovement);
    }

    private Vector2 PoolInput()
    {
        Vector2 dir = Vector2.zero;
        dir.x = joystick.Horizontal();
        dir.y = joystick.Vertical();
        if (dir.magnitude > 1)
            dir.Normalize();

        return dir;
    }
}
