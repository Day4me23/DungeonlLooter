using System.Collections;
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
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public ArenaSlot[,] arena = new ArenaSlot[4, 5];
    public Team computer;
    public Team player;

    List<Creature> initiative = new List<Creature>();
    public Creature selected;

    private void Start()
    {
        
    }
}
public enum Die { d4 = 4, d6 = 6, d8 = 8, d10 = 10, d12 = 12, d20 = 20, d100 = 100 }