using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class GridBuilder : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private int tileSize = 3;

    [Header("Settings")]
    [OnValueChanged(nameof(GenerateGrid))]
    [SerializeField] private int gridLength = 10;
    [OnValueChanged(nameof(GenerateGrid))]
    [SerializeField] private int gridWidth = 10;

    private void GenerateGrid()
    {
        while (transform.childCount > 0)
        {
            Transform child = transform.transform.GetChild(0);
            child.SetParent(null);
            Object.DestroyImmediate(child.gameObject);
        }

        for (int x = 0; x < gridWidth; x++)
        {
            for (int z = 0; z < gridLength; z++)
            {
                Cretile(x, z);
            }
        }
    }

    private void Cretile(float xPosition, float zPosition)
    {
        Vector3 newPosition = new Vector3(xPosition * tileSize, 0, zPosition * tileSize);

        GameObject newTile = Instantiate(tilePrefab, newPosition, Quaternion.identity, transform);
    }
}
