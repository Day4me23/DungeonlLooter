using UnityEngine.UI;
using UnityEngine;

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
    [SerializeField] Player selected;
    public Transform inventorySlots;
    [SerializeField] Text[] equipmentSlots;
    [SerializeField] Transform[] formationSlots;

    private void Start()
    {
        team = Save.instance.team;

        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 2; j++)
                if (team.formation[i,j] != null)
                    CreateFormationSlot(formationSlots[j * 5 + i], team.formation[i,j]);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            team.inventory.AddItem(new Equipment(Random.Range(0, 1000).ToString(), Random.Range(0, 1)));
        }

        try
        {
            equipmentSlots[0].text = selected.stuff.head.name;
            equipmentSlots[1].text = selected.stuff.chest.name;
            equipmentSlots[2].text = selected.stuff.legs.name;
            equipmentSlots[3].text = selected.stuff.feet.name;
        }
        catch (System.Exception)
        {

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

    public void SelectPlayer(Player player)
    {
        selected = player;
        ChangeUI();
    }

    public Stuff GetStuff()
    {
        return selected.stuff;
    }

    void ChangeUI()
    {

    }

}
