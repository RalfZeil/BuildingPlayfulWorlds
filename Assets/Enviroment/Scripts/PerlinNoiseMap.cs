using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseMap : MonoBehaviour
{
    static public PerlinNoiseMap instance;

    private Dictionary<int, GameObject[]> tileset;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] prefabsGrass;
    [SerializeField] private GameObject[] prefabsDeepGrass;
    [SerializeField] private GameObject[] prefabsHills;
    [SerializeField] private GameObject[] prefabsMountains;

    [Header("Map Settings")]
    [SerializeField] public int map_width = 80;
    [SerializeField] public int map_height = 80;
    [SerializeField] private float magnification = 7.0f;
    
    private List<List<int>> noise_grid = new List<List<int>>();
    private List<List<GameObject>> tile_grid = new List<List<GameObject>>();

    private int x_offset = 0;
    private int y_offset = 0; 

    private void Awake()
    {
        instance = this;

        x_offset = Random.Range(-10000, 10000);
        y_offset = Random.Range(-10000, 10000);

        CreateTileset();
        GenerateMap();
    }

    private void CreateTileset()
    {
        /** Collect and assign ID codes to the tile prefabs, for ease of access.
            Best ordered to match land elevation. **/

        tileset = new Dictionary<int, GameObject[]>();
        tileset.Add(0, prefabsGrass);
        tileset.Add(1, prefabsDeepGrass);
        tileset.Add(2, prefabsHills);
        tileset.Add(3, prefabsMountains);
    }

    private void GenerateMap()
    {
        /** Generate a 2D grid using the Perlin noise fuction, storing it as
            both raw ID values and tile gameobjects **/

        for (int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<int>());
            tile_grid.Add(new List<GameObject>());

            for (int y = 0; y < map_height; y++)
            {
                int tile_id = GetIdUsingPerlin(x, y);
                noise_grid[x].Add(tile_id);
                CreateTile(tile_id, x, y);
            }
        }
    }

    private int GetIdUsingPerlin(int x, int y)
    {
        /** Using a grid coordinate input, generate a Perlin noise value to be
            converted into a tile ID code. Rescale the normalised Perlin value
            to the number of tiles available. **/

        float raw_perlin = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );
        float clamp_perlin = Mathf.Clamp01(raw_perlin); // Thanks: youtu.be/qNZ-0-7WuS8&lc=UgyoLWkYZxyp1nNc4f94AaABAg
        float scaled_perlin = clamp_perlin * tileset.Count;

        // Replaced 4 with tileset.Count to make adding tiles easier
        if (scaled_perlin == tileset.Count)
        {
            scaled_perlin = (tileset.Count - 1);
        }
        return Mathf.FloorToInt(scaled_perlin);
    }

    private void CreateTile(int tile_id, int x, int y)
    {
        /** Creates a new tile using the type id code, group it with common
            tiles, set it's position and store the gameobject. **/
        int randomIndex = Random.Range(0, tileset[tile_id].Length);

        GameObject tile_prefab = tileset[tile_id][randomIndex];
        //GameObject tile_group = tile_groups[tile_id][randomIndex];
        GameObject tile = Instantiate(tile_prefab); //tile_group.transform);

        tile.name = string.Format("tile_x{0}_y{1}", x, y);
        tile.transform.localPosition = new Vector3(x, y, 0);

        tile.GetComponent<Tile>().x = x;
        tile.GetComponent<Tile>().y = y;

        tile_grid[x].Add(tile);
    }
}