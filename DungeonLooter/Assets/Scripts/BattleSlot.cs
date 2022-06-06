using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class BattleSlot : Slot, IPointerClickHandler
{
    [SerializeField] Image art;
    [SerializeField] Image healthBar;
    [SerializeField] Image staminaBar;
    [SerializeField] Image manaBar;

    public Creature creature;

    // Get rid of update method
    private void Update()
    {
        if(creature.GetName() == "Dude")
            Debug.Log(creature.GetHealth() / creature.GetMaxHealth());
        
        healthBar.fillAmount = creature.GetHealth() / creature.GetMaxHealth();
        staminaBar.fillAmount = creature.GetStamina() / creature.GetMaxStamina();
        manaBar.fillAmount = creature.GetMana() / creature.GetMaxMana();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (highlight)
        {
            Debug.Log("press " + creature.GetName());
            ActionsManager.instance.selected.Add(this);
        }
    }
}
