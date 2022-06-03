using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    int index;
    Inventory inventory;

    public void OnPointerClick(PointerEventData eventData)
    {
        inventory.EquipItem(index);
    }

    public void Set(int index, Inventory inventory)
    {
        this.index = index;
        this.inventory = inventory;

        if (inventory.items[index].art != null)
            GetComponent<Image>().sprite = inventory.items[index].art;
        else Debug.Log("art = null");
    }

}
