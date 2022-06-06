using UnityEngine;
using UnityEngine.EventSystems;

public class EmptySlot : Slot, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (highlight)
        {
            Debug.Log("Press empty slot");
            ActionsManager.instance.selected.Add(this);
        }
    }
}
