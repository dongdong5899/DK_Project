using DKProject.Cores;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Joystick : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private Transform _joystick;
    [SerializeField] private Transform _joystickDot;

    private Vector2 _downPos;
    private float _joystickRadius;

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
        PlayerManager.Instance.SetAutoMode(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - _downPos;

        Vector2 dotPos = Vector2.ClampMagnitude(dir, _joystickRadius);

        _joystickDot.localPosition = dotPos;

        PlayerManager.Instance.OnPlayerInput(dir.normalized);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _joystick.gameObject.SetActive(false);
        PlayerManager.Instance.SetAutoMode(false);
    }
}
