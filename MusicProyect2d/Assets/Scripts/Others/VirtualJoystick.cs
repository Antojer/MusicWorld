using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler,IPointerDownHandler {

    public Animator anmWalk;
    private Image _imgBgImg;
    private Image _imgJoystickImg;
    private Vector2 _aInputVector;

    void Start()
    {
        _imgBgImg = GetComponent<Image>();
        _imgJoystickImg = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_imgBgImg.rectTransform,
            ped.position
            , ped.pressEventCamera
            , out pos))
        {
            pos.x = (pos.x / _imgBgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _imgBgImg.rectTransform.sizeDelta.y);
            _aInputVector = new Vector2(pos.x * 2 + 1, pos.y * 2 - 1);
            _aInputVector = (_aInputVector.magnitude > 1.0f) ? _aInputVector.normalized : _aInputVector;

            _imgJoystickImg.rectTransform.anchoredPosition = new Vector2(_aInputVector.x * (_imgBgImg.rectTransform.sizeDelta.x / 2)
                , _aInputVector.y * (_imgBgImg.rectTransform.sizeDelta.y / 2));
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        anmWalk.Play("Walk");
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        anmWalk.CrossFade("Normal", 0.1f);
        _aInputVector = Vector2.zero;
        _imgJoystickImg.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float Horizontal()
    {
        if (_aInputVector.x != 0)
            return _aInputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (_aInputVector.y != 0)
            return _aInputVector.y;
        else
            return Input.GetAxis("Vertical");
    }

}
