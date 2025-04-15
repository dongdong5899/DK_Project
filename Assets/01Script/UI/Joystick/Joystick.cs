using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _joystick;
    [SerializeField] private Transform _joystickDot;

    private Vector2 _downPos;
    private float _joystickRadius;

    public Vector2 InputDir { get; private set; }

    private void Start()
    {
        _joystickRadius = (_joystick as RectTransform).sizeDelta.x / 2;
        _joystick.gameObject.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _downPos = eventData.position;
        _joystick.position = _downPos;
        _joystick.gameObject.SetActive(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - _downPos;
        InputDir = dir.normalized;

        if (dir.magnitude < _joystickRadius)
            _joystickDot.localPosition = dir;
        else
            _joystickDot.localPosition = InputDir * _joystickRadius;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _joystick.gameObject.SetActive(false);
    }
}
