using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionsManager : MonoBehaviour
{
    #region Singleton
    public static ActionsManager instance;
    void Awake() => instance = this;
    #endregion

    Creature creature;
    public List<Slot> selected = new List<Slot>();

    private void Start()
    {
        creature = GameManager.instance.GetCurrentTurn();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        yield return StartCoroutine(Select(1));

        Creature target = (selected[0] as BattleSlot).creature;
        target.Damage(creature.GetDamage(), DamageType.melee);

        selected.Clear();
        EndTurn();
    }
    public void EndTurn()
    {
        if (creature is Enemy)
            return;
        GameManager.instance.NextTurn();
        creature = GameManager.instance.GetCurrentTurn();
    }
    IEnumerator Select(int numOfSlots)
    {
        Slot[] slots = FindObjectsOfType<Slot>();

        foreach (Slot slot in slots)
            slot.highlight = true;

        while (selected.Count < numOfSlots)
            yield return new WaitForEndOfFrame();

        foreach (Slot slot in slots)
            slot.highlight = false;
    }
}
