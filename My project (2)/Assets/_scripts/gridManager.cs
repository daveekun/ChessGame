using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridManager : MonoBehaviour
{
    public static gridManager instance;

    [SerializeField]
    public int width, height;
    [SerializeField]
    public Vector3 offset;
    [SerializeField]
    public List<GameObject> prefabs;

    private float preWidth;
    private float preHeight;
    private GameObject[,] Tiles;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }


        Tiles = new GameObject[width, height];
        Debug.Log(prefabs[0].transform.localScale);
        Debug.Log(prefabs[1].transform.localScale);
        preWidth = prefabs[0].transform.localScale.x;
        preHeight = prefabs[0].transform.localScale.y;
        GenerateMap();
    }

    public void GenerateMap()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                var newTile = Instantiate(prefabs[(i + j) % prefabs.Count], this.transform);
                newTile.name = "(" + i + ", " + j + ")";

                Tiles[i ,j] = newTile;
                newTile.transform.position = new Vector3((i * 0.5f + j * 0.5f) * preWidth, (i * -0.25f + j * 0.25f) * preHeight, 0) + offset;
            }
        }
    }
    public static Vector3 GridCordsToWorldCords(Vector2Int cords)
    {
        Transform tile = gridManager.instance.prefabs[0].transform;
        Vector3 pos = new Vector3(tile.localScale.x * gridManager.instance.width * (cords.x + cords.y) / 2 + gridManager.instance.offset.x,
                                                tile.localScale.y * gridManager.instance.height * (cords.y - cords.x) + gridManager.instance.offset.y,
                                                0
                                                );
        return pos;
    }
}
