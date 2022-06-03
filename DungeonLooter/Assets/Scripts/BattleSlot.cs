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

    private void Update()
    {
        healthBar.fillAmount = creature.GetHealth() / creature.GetMaxHealth();
        staminaBar.fillAmount = creature.GetStamina() / creature.GetMaxStamina();
        manaBar.fillAmount = creature.GetMana() / creature.GetMaxMana();
    }
    public void OnPointerClick(PointerEventData eventData)
    {

    }
}
