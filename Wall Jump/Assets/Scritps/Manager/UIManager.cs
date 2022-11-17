using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public Vector2 currentBashObjectPosition { get; set; } = Vector2.zero;
}
