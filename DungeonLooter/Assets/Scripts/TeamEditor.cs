using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamEditor : MonoBehaviour
{
    #region Singleton
    public static TeamEditor instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Team team;
    public Adventurer selected;

    [SerializeField] Text stats;
    public Transform inventorySlots;
    [SerializeField] Text[] equipmentSlots;
    [SerializeField] Transform[] formationSlots;

    private void Start()
    {
        team = Save.instance.party;
        //MAKE DYNAMIC 
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 2; j++)
                if (team.formation[i,j] != null)
                    CreateFormationSlot(formationSlots[j * 5 + i], team.formation[i,j]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            team.inventory.AddItem(ItemLibrary.GetRandomItem());
        if (Input.GetKeyDown(KeyCode.B))
        {
            Save.instance.enemy = new Team(new Enemy("Dude", new int[] { 10, 10, 10, 10, 10 }));
            SceneManager.LoadScene("Battle");
        }

        try
        {
            if (selected != null && selected.stuff.head != null)
                equipmentSlots[0].text = selected.stuff.head.name;
            else equipmentSlots[0].text = "";
            if (selected != null && selected.stuff.chest != null)
                equipmentSlots[1].text = selected.stuff.chest.name;
            else equipmentSlots[1].text = "";
            if (selected != null && selected.stuff.legs != null)
                equipmentSlots[2].text = selected.stuff.legs.name;
            else equipmentSlots[2].text = "";
            if (selected != null && selected.stuff.feet != null)
                equipmentSlots[3].text = selected.stuff.feet.name;
            else equipmentSlots[3].text = "";
        } catch { }

        try
        { 
            stats.text = selected.GetName();
            for (int i = 0; i < System.Enum.GetNames(typeof(StatType)).Length; i++)
                stats.text += "\n" + ((StatType)i).ToString() + ":" + selected.stats[(StatType)i].GetMax();
            stats.text += "\nHealth: " + selected.GetHealth();
        }
        catch
        {
            stats.text = "";
        }
    }
    void CreateFormationSlot(Transform parent, Creature creature)
    {
        GameObject gameObject = new GameObject("FormationSlot", typeof(FormationSlot), typeof(Image), typeof(CanvasGroup));
        gameObject.transform.SetParent(parent);
        gameObject.GetComponent<FormationSlot>().RT = gameObject.GetComponent<RectTransform>();
        gameObject.GetComponent<FormationSlot>().Setup(creature);
        gameObject.GetComponent<Image>().color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
    }
    public void EditFormationSlot(FormationZone one, FormationZone two)
    {
        Creature temp = team.formation[one.column, one.row];
        team.formation[one.column, one.row] = team.formation[two.column, two.row];
        team.formation[two.column, two.row] = temp;
    }

    public void SelectPlayer(Adventurer player)
    {
        selected = player;
        ChangeUI();
    }

    void ChangeUI()
    {

    }
}
