using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Type type;
    public bool highlight = false;
    public enum Type { friend, enemy, all }
}
