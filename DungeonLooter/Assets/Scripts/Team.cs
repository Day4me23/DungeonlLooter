using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team
{
    string name;
    public List<Creature> team = new List<Creature>();
    public Creature[,] formation = new Creature[5,2];
    public Inventory inventory;

    public void ChangeFormation(Vector2Int pos1, Vector2Int pos2)
    {
        Creature temp = formation[pos1.x, pos1.y];
        formation[pos1.x, pos1.y] = formation[pos2.x, pos2.y];
        formation[pos2.x, pos2.y] = temp;
    }
    public void AddPlayer(Creature creature)
    {
        if (team.Count == 10)
        {
            Debug.LogWarning("can't add more than 10 players");
            return;
        }

        team.Add(creature);

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 2; j++)
                if (formation[i,j] == null)
                {
                    formation[i, j] = creature;
                    return;
                }
    }
    public void AddEnemy(Creature creature, Vector2Int pos)
    {
        team.Add(creature);
        formation[pos.x, pos.y] = creature;
    }
    public Team(Enemy enemy)
    {
        team.Add(enemy);
        formation[0, 0] = enemy;
    }
    public Team(List<Enemy> enemy)
    {

    }
    public Team(List<Adventurer> players)
    {
        inventory = new Inventory();

        for (int i = 0; i < players.Count; i++)
            AddPlayer(players[i]);
    }

}
