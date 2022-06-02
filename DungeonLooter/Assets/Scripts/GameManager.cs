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

    [SerializeField] GameObject BattleSlotPrefab;
    [SerializeField] BattleSlot [] SlotsParty;
    [SerializeField] BattleSlot [] SlotsEnemy;

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

    }
}
