using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public static PositionManager manager;
    private void Awake()
    {
        manager = this;
    }
    public GameObject Player;
}
