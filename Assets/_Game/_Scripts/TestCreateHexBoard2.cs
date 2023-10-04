using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TestCreateHexBoard2 : HMonoBehaviour
{
    [SerializeField] private HexUnit hexUnitPrefab;
    [SerializeField] private int separateTimes = 4;

    private readonly Dictionary<Vector2Int, HexUnit> hexUnitDic = new();
    private readonly List<HexUnit> nonSpannedHexUnits = new();
    private void Start()
    {
        CreateHexBoard();
    }

    private void SpawnHexUnit(Vector2Int index)
    {
        if (hexUnitDic.ContainsKey(index)) return;
        HexUnit hexUnit = Instantiate(hexUnitPrefab, new Vector3(index.x * 0.725f, index.y * 0.415f, 0), Quaternion.identity);
        hexUnit.Index = index;
        hexUnit.Tf.parent = Tf;
        hexUnitDic.Add(index, hexUnit);
        nonSpannedHexUnits.Add(hexUnit);
    }

    private void SeparateHexUnit(HexUnit hexUnit)
    {
        if (!hexUnitDic.ContainsKey(hexUnit.Index)) return;
        nonSpannedHexUnits.Remove(hexUnit);
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x, hexUnit.Index.y + 2));
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x + 1, hexUnit.Index.y + 1));
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x + 1, hexUnit.Index.y - 1));
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x, hexUnit.Index.y - 2));
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x - 1, hexUnit.Index.y - 1));
        SpawnHexUnit(new Vector2Int(hexUnit.Index.x - 1, hexUnit.Index.y + 1));
    }

    private void CreateHexBoard()
    {
        SpawnHexUnit(Vector2Int.zero);
        for (int i = 0; i < separateTimes; i++)
        {
            List<HexUnit> hexUnits = new(nonSpannedHexUnits);
            foreach (HexUnit hexUnit in hexUnits)
            {
                SeparateHexUnit(hexUnit);
                nonSpannedHexUnits.Remove(hexUnit);
            }
        }
    }
}
