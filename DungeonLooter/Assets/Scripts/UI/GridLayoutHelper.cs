using UnityEngine.UI;
using UnityEngine;

public class GridLayoutHelper : MonoBehaviour
{
    GridLayoutGroup gridLayout;
    [SerializeField] float padding;
    [SerializeField] Vector2 size;
    [SerializeField] Dirrection dirrection;
    [SerializeField] int cellCount;

    void Awake() => gridLayout = GetComponent<GridLayoutGroup>();
    void Update()
    {
        
    }
    enum Dirrection { vertical, horizontal};
}
