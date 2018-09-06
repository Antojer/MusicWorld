using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShotJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    private Image _imgBgImg;
    private Image _imgJoystickImg;
    private Vector2 _aInputVector;
    private bool _bIsShoting;
    private bool _bLookingLeft, _bLookingRight, _bLookingUp, _bLookingDown;
    private Shots _goShotsHandler;

    void Start()
    {
        _goShotsHandler = this.transform.parent.GetComponent<Shots>();
        _imgBgImg = GetComponent<Image>();
        _imgJoystickImg = transform.GetChild(0).GetComponent<Image>();
    }


    void Update()
    {
        if (Horizontal() < -0.1 && Vertical() < 0.5 && Vertical() > -0.5)
        {
            if (_bLookingRight)
            {
                _bLookingRight = false;
                _goShotsHandler.rightToDefaultState();
            }
            if (_bLookingUp)
            {
                _bLookingUp = false;
                _goShotsHandler.upToDefaultState();
            }
            if (_bLookingDown)
            {
                _bLookingDown = false;
                _goShotsHandler.downToDefaultState();
            }
            _bLookingLeft = true;
            _goShotsHandler.leftShot(_bIsShoting);
        }
        if (Horizontal() > 0.1 && Vertical() < 0.5 && Vertical() > -0.5)
        {
            if (_bLookingLeft)
            {
                _bLookingLeft = false;
                _goShotsHandler.leftToDefaultState();
            }
            if (_bLookingUp)
            {
                _bLookingUp = false;
                _goShotsHandler.upToDefaultState();
            }
            if (_bLookingDown)
            {
                _bLookingDown = false;
                _goShotsHandler.downToDefaultState();
            }
            _bLookingRight = true;
            _goShotsHandler.rightShot(_bIsShoting);
        }
        if (Vertical() <= -0.5)
        {
            if (_bLookingLeft)
            {
                _bLookingLeft = false;
                _goShotsHandler.leftToDefaultState();
            }
            if (_bLookingRight)
            {
                _bLookingRight = false;
                _goShotsHandler.rightToDefaultState();
            }
            if (_bLookingUp)
            {
                _bLookingUp = false;
                _goShotsHandler.upToDefaultState();
            }
            _bLookingDown = true;
            _goShotsHandler.downShot(_bIsShoting);
        }
        if (Vertical() >= 0.5)
        {
            if (_bLookingLeft)
            {
                _bLookingLeft = false;
                _goShotsHandler.leftToDefaultState();
            }
            if (_bLookingRight)
            {
                _bLookingRight = false;
                _goShotsHandler.rightToDefaultState();
            }
            if (_bLookingDown)
            {
                _bLookingDown = false;
                _goShotsHandler.downToDefaultState();
            }
            _bLookingUp = true;
            _goShotsHandler.upShot(_bIsShoting);
        }
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
        _bIsShoting = true;
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        _bIsShoting = false;
        _aInputVector = Vector2.zero;
        _imgJoystickImg.rectTransform.anchoredPosition = Vector2.zero;
        if (_bLookingLeft)
        {
            _bLookingLeft = false;
            _goShotsHandler.leftToDefaultState();
        }
        if (_bLookingRight)
        {
            _bLookingRight = false;
            _goShotsHandler.rightToDefaultState();
        }
        if (_bLookingUp)
        {
            _bLookingUp = false;
            _goShotsHandler.upToDefaultState();
        }
        if (_bLookingDown)
        {
            _bLookingDown = false;
            _goShotsHandler.downToDefaultState();
        }

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
