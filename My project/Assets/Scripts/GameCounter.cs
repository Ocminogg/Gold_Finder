using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCounter : MonoBehaviour
{
    public static GameCounter Instance;

    public static int Points { get; private set; }
    public static int FindGolds { get; private set; }

    public static int ShovelsCount { get; private set; }
    public static bool GameStarted { get; private set; }

    [Header("Кол-во лопато и необходимое кол-во золота для победы")]
    public int Shovel;
    public int Golds;

    [SerializeField]
    private TextMeshProUGUI gameResult;
    [SerializeField]
    public TextMeshProUGUI pointsText;
    [SerializeField]
    public TextMeshProUGUI shovelsText;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        Points = 0;
        FindGolds = 0;
        ShovelsCount = Shovel;
        gameResult.text = "";
        pointsText.text = "0";
        shovelsText.text = Convert.ToString(Shovel);
        GameStarted = true;        
        Field.Instance.CreateField();
        Field.Instance.GenerateField();
    }
    ///////////////////////////////////////////////////////
    public void Win()
    {
        GameStarted = false;
        gameResult.text = "U Win!";
    }
    public void Lose()
    {
        GameStarted = false;
        gameResult.text = "U Lose!";
    }
    //////////////////////////////////////////////////////
    public void AddPoints()
    {
        SetPoints(Points + 1);
    }
    public void AddPoints(int points)
    {
        FindGolds += points;
    }
    public void SetPoints(int points)
    {
        Points = points;
        pointsText.text = Points.ToString();
        if (Points == Golds)
            Win();
    }
    ///////////////////////////////////////////////////
    public void SubShovel()
    {
        SetShovel(ShovelsCount - 1);
    }
    public void SetShovel(int points)
    {
        ShovelsCount = points;
        shovelsText.text = ShovelsCount.ToString();
        if ((ShovelsCount == 0) && (FindGolds < Golds ))
        {
            Lose();
        }
    }
}
