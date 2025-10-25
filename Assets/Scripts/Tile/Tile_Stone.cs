using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Stone : Tile_Snow
{
    protected override void ChangeObstacle()
    {
        countObstacle = 7 - countObstacle;
         
        ActiveObstacle(countObstacle);
    }
}
