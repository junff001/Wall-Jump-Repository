using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TouchToScreen : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private UnityEvent touchToScreenEvent;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("ÅÍÄ¡");
    }
}
