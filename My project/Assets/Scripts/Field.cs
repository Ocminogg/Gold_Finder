using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour
{
    public static Field Instance;

    [Header("Характеристики Поля")]
    public float CellSize;
    public float CellSpacing;
    public int FieldSize;
    public int InitCellsCount;

    [Space(10)]
    [SerializeField]
    private Cell cellPref;
    [SerializeField]
    private RectTransform rt;

    [SerializeField]
    private Image image;

    private Cell[,] field;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    

    public void CreateField()
    {
        field = new Cell[FieldSize, FieldSize];

        float fieldWidth = FieldSize * (CellSize + CellSpacing) + CellSpacing;
        rt.sizeDelta = new Vector2(fieldWidth, fieldWidth);

        float startX = -(fieldWidth / 2) + (CellSize / 2) + CellSpacing;
        float startY = (fieldWidth / 2) - (CellSize / 2) - CellSpacing;

        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                var cell = Instantiate(cellPref, transform, false);
                var position = new Vector2(startX + (x * (CellSize + CellSpacing)), startY - (y * (CellSize + CellSpacing)));
                cell.transform.localPosition = position;

                field[x, y] = cell;
                cell.SetValue(x, y, 0);
            }
        }       
    }

    public void GenerateField()
    {
        if (field == null)
            CreateField();
        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
               field[x, y].SetValue(x, y, 0);
            }
        }
        for (int i = 0; i < InitCellsCount; i++)
        {
            GenerateRandomCellGold();
        }
    }

    private void GenerateRandomCellGold()
    {
        var emptyCells = new List<Cell>();

        for (int x = 0; x < FieldSize; x++)
        {
            for (int y = 0; y < FieldSize; y++)
            {
                if (field[x, y].IsEmpty)
                {
                    emptyCells.Add(field[x,y]);
                }
            }
        }
        if (emptyCells.Count == 0)
            throw new System.Exception("Здесь нет пустых cell!");

        int value = Random.Range(0,4);

        var cell = emptyCells[Random.Range(0,emptyCells.Count)];
        cell.SetValue(cell.X, cell.Y, value,1);
    }
}
