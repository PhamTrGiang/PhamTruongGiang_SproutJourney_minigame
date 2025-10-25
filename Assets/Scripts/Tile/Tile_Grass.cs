using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class Tile_Grass : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private GameObject[] obstacles;

    [Header("Tile Prifabs")]
    public GameObject tileGrass;
    public GameObject tileSnow;
    public GameObject tileSand;
    public GameObject tileStone;

    [Header("Settings")]
    [OnValueChanged(nameof(SetupTile))]
    [Range(1, 6)]
    [SerializeField] protected int countObstacle = 1;

    private void SetupTile()
    {
        ActiveObstacle(countObstacle);
    }

    protected void ActiveObstacle(int count)
    {
        foreach (GameObject obstacle in obstacles)
            obstacle.SetActive(false);

        switch (count)
        {
            case 1:
                obstacles[3].SetActive(true);
                break;
            case 2:
                obstacles[0].SetActive(true);
                obstacles[6].SetActive(true);
                break;
            case 3:
                obstacles[3].SetActive(true);
                obstacles[0].SetActive(true);
                obstacles[6].SetActive(true);
                break;
            case 4:
                obstacles[0].SetActive(true);
                obstacles[6].SetActive(true);
                obstacles[1].SetActive(true);
                obstacles[5].SetActive(true);
                break;
            case 5:
                obstacles[0].SetActive(true);
                obstacles[6].SetActive(true);
                obstacles[3].SetActive(true);
                obstacles[1].SetActive(true);
                obstacles[5].SetActive(true);
                break;
            case 6:
                obstacles[0].SetActive(true);
                obstacles[6].SetActive(true);
                obstacles[2].SetActive(true);
                obstacles[4].SetActive(true);
                obstacles[1].SetActive(true);
                obstacles[5].SetActive(true);
                break;
        }
    }

    [Button("Grass")]
    public void ChangeTileGrass()
    {
        GameObject newTile = Instantiate(tileGrass, transform.position, Quaternion.identity, transform.parent);
        Object.DestroyImmediate(gameObject);
    }

    [Button("Snow")]
    public void ChangeTileSnow()
    {
        GameObject newTile = Instantiate(tileSnow, transform.position, Quaternion.identity, transform.parent);
        Object.DestroyImmediate(gameObject);
    }

    [Button("Sand")]
    public void ChangeTileSand()
    {
        GameObject newTile = Instantiate(tileSand, transform.position, Quaternion.identity, transform.parent);
        Object.DestroyImmediate(gameObject);
    }

    [Button("Stone")]
    public void ChangeTileStone()
    {
        GameObject newTile = Instantiate(tileStone, transform.position, Quaternion.identity, transform.parent);
        Object.DestroyImmediate(gameObject);
    }
}