using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TeamBuilder : MonoBehaviour
{
    public TMP_InputField name1;
    public TMP_InputField name2;
    public TMP_InputField name3;
    public TMP_InputField name4;
    public TMP_Dropdown drop1;
    public TMP_Dropdown drop2;
    public TMP_Dropdown drop3;
    public TMP_Dropdown drop4;
    List<Player> players = new List<Player>();
    public List<string> classes = new List<string>(){ "rogue", "mage", "warrior" };
    public List<Image> background = new List<Image>();



    private void Start()
    {
        drop1.ClearOptions();
        drop2.ClearOptions();
        drop3.ClearOptions();
        drop4.ClearOptions();

        drop1.AddOptions(classes);
        drop2.AddOptions(classes);
        drop3.AddOptions(classes);
        drop4.AddOptions(classes);
    }

    public void OnImageButtonClick()
    {
        Debug.Log("Clicked Image: ");
    }

    public void Button_BuildTeam()
    {
        players.Add(BuildPlayer(drop1.value, name1.text));
        players.Add(BuildPlayer(drop2.value, name2.text));
        players.Add(BuildPlayer(drop3.value, name3.text));
        players.Add(BuildPlayer(drop4.value, name4.text));
        Save.instance.team = new Team(players);
        SceneManager.LoadScene("TeamEditor");
    }

    private Player BuildPlayer(int playerClass, string name)
    {
        switch (playerClass)
        {
            case 0: // rogue 
                return new Player(name, new int[] { 10, 25, 10, 10, 25 }, new List<Equipment>());
            case 1: // mage
                return new Player(name, new int[] { 10, 10, 10, 50, 10 }, new List<Equipment>());
            case 2: // warior
                return new Player(name, new int[] { 25, 10, 25, 10, 10 }, new List<Equipment>());
            default:
                return null;
        }
    }

}
