using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FixedButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]private PlayerMovement player;
    [SerializeField]private float direction;
    public void OnPointerDown(PointerEventData eventData)
    {
        player.Direction = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.Direction = 0;
    }
}
