using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressButton : Button, IPointerDownHandler, IPointerUpHandler
{
    public event Action OnButtonPressed;
    public event Action OnButtonReleased;

    public void OnPointerDown(PointerEventData eventData) => OnButtonPressed?.Invoke();
    public void OnPointerUp(PointerEventData eventData) => OnButtonReleased?.Invoke();
}

