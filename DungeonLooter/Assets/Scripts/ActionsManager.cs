using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] Creature creature;
    private void Start()
    {
        creature = GameManager.instance.GetCurrentTurn();
    }
    public void ButtonEndTurn()
    {
        if (creature is Enemy)
            return;
        GameManager.instance.NextTurn();
        creature = GameManager.instance.GetCurrentTurn();
    }
}
