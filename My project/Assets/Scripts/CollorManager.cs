using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorManager : MonoBehaviour
{
    public static CollorManager Instance;

    
    public Color[] CellColor;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
