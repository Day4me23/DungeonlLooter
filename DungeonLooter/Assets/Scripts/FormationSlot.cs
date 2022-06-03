using UnityEngine.EventSystems;
using UnityEngine;

public class FormationSlot : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    static float transparency = .65f;
    static float growth = 1.1f;

    public RectTransform RT;
    [SerializeField] Canvas canvas;
    [SerializeField] CanvasGroup group;

    [SerializeField] Creature creature;
    Transform oldParent = null;

    public void Setup(Creature creature)
    {
        this.creature = creature;
        RT.localPosition = Vector3.zero;
        RT.sizeDelta = new Vector2(85,85); // NEED TO NOT BE HARDCODED
    }
    private void Start()
    {
        RT = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            oldParent = transform.parent;
            transform.SetParent(canvas.transform);

            group.blocksRaycasts = false;
            group.alpha = transparency;
            RT.sizeDelta *= growth;
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            TeamEditor.instance.SelectPlayer((Adventurer)creature);
        }
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            RT.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        Transform newParent = eventData.pointerEnter.GetComponent<Transform>();
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (newParent.GetComponent<FormationZone>() != null)
            {
                if (newParent != oldParent)
                    TeamEditor.instance.EditFormationSlot(oldParent.GetComponent<FormationZone>(), newParent.GetComponent<FormationZone>());
                transform.SetParent(newParent);

            }
            else transform.SetParent(oldParent);

            group.blocksRaycasts = true;
            group.alpha = 1;
            RT.sizeDelta /= growth;

            RT.localPosition = Vector3.zero;
            RT.sizeDelta = RT.parent.GetComponent<RectTransform>().sizeDelta;
        }
    }
}
