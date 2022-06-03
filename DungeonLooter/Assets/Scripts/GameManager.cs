using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }
    #endregion

    [SerializeField] GameObject battleSlotPrefab;
    [SerializeField] GameObject emptySlotPrefab;
    [SerializeField] Slot [] slotsParty;
    [SerializeField] Slot [] slotsEnemy;
    [SerializeField] Transform partySlots;
    [SerializeField] Transform enemySlots;

    public Team computer;
    public Team party;

    List<Creature> turnOrder = new List<Creature>();
    public Creature selected;

    private void Start()
    {
        try
        { 
            party = Save.instance.party;
            computer = Save.instance.enemy;
        }
        catch 
        { 
            Debug.LogWarning("cannot find save script"); 
        }

        SetInitiative();
        SetFormation();
    }
    void SetInitiative()
    {
        foreach (Creature c in computer.team)
        {
            c.SetTurn(Dice.HideRoll(Die.d20, c.GetInitiative()));
            turnOrder.Add(c);
        }
        foreach (Creature c in party.team)
        {
            c.SetTurn(Dice.HideRoll(Die.d20, c.GetInitiative()));
            turnOrder.Add(c);
        }
        turnOrder = turnOrder.OrderByDescending(c => c.GetTurn()).ToList();
    }
    void SetFormation()
    {
        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 5; j++)
                if (computer.formation[j,i] == null)
                {
                   GameObject slot = Instantiate(emptySlotPrefab, enemySlots);
                }
                else
                {
                    GameObject slot = Instantiate(battleSlotPrefab, enemySlots);
                    slot.transform.GetComponent<BattleSlot>().creature = computer.formation[j,i];
                }
                
            

        for (int i = 0; i < 2; i++)
            for (int j = 0; j < 5; j++)
                if (party.formation[j,i] == null)
                {
                    GameObject slot = Instantiate(emptySlotPrefab, partySlots);
                }
                else
                {
                    GameObject slot = Instantiate(battleSlotPrefab, partySlots);
                    slot.transform.GetComponent<BattleSlot>().creature = party.formation[j,i];
                }
    }
    public void NextTurn()
    {
        Creature creature = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Add(creature);
        
    }
    public Creature GetCurrentTurn() => turnOrder[0];
}
