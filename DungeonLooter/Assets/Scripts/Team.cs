using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Team
{
    public List<Creature> team = new List<Creature>();
    public Creature[,] formation = new Creature[2,5];

    public Team(List<Enemy> enemy)
    {
        for (int i = 0; i < enemy.Count; i++)
        {
            team.Add(enemy[i]);
        }
    }
    public Team(List<Player> players)
    {
        for (int i = 0; i < players.Count; i++)
        {
            team.Add(players[i]);
        }
    }

}
