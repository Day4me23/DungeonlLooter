using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySlot : Slot, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click empty slot.");
    }
}
