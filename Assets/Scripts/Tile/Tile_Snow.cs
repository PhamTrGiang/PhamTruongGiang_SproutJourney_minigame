using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile_Snow : Tile_Grass
{
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            ChangeObstacle();
        }
    }

    protected virtual void ChangeObstacle()
    {
        countObstacle--;
        if (countObstacle > 0)
            ActiveObstacle(countObstacle);
        else Destroy(gameObject);
    }
}
