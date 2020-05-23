using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Gunnar Jessee 4/27/20 
 * TODO: Builds Gridbased Platform For Game SmashyTree
 * 
 */


public class PlatformGenerator : MonoBehaviour
{
    public GameObject prefab;
    
    public int width;
    public int length;
    public int xOffset;
    public int yOffset;
    public float randomYOffset = .25f;
    private GameObject[,] grid;

    // Start is called before the first frame update
    void Start()
    {

        GenerateGrid();        
    }

    // Generates a tiled grid based on length, width, and offsets
    private void GenerateGrid()
    {
        grid = new GameObject[width, length];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.parent = transform;
                obj.name = (x + "," + y);
                obj.transform.position = new Vector3(x * xOffset, Random.Range(-randomYOffset, randomYOffset), y * yOffset);
                grid[x, y] = obj;

                GrassTile tile = obj.GetComponent<GrassTile>();
                int randomInt = Random.Range(1, 10);
                if (randomInt == 3)
                {
                    tile.ToggleTree();
                }
            }
        }
    }

    // Returns Generated Grid
    public GameObject[,] GetGrid()
    {
        return grid;
    }

}
