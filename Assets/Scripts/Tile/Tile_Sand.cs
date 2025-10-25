using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Sand : Tile_Snow
{
    protected override void ChangeObstacle()
    {
        countObstacle++;
        if (countObstacle <= 6)
            ActiveObstacle(countObstacle);
        else Destroy(gameObject);
    }
}
