using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    public Tile[] tiles;
    public Tile[,] grid;

    public int highestX { get; private set; }
    public int highestZ { get; private set; }

    [SerializeField] private Sprite wallN;
    [SerializeField] private Sprite wallNEWS;
    [SerializeField] private Sprite wallNEW;
    [SerializeField] private Sprite wallNE;
    [SerializeField] private Sprite wallNW;
    [SerializeField] private Sprite wallNES;
    [SerializeField] private Sprite wallNWS;
    [SerializeField] private Sprite wallEWS;
    [SerializeField] private Sprite wallES;
    [SerializeField] private Sprite wallE;
    [SerializeField] private Sprite wallWS;
    [SerializeField] private Sprite wallW;
    [SerializeField] private Sprite wallS;
    [SerializeField] private Sprite wallEW;
    [SerializeField] private Sprite wall;


    [SerializeField] private GameObject[] prefabsEnemies;
    [SerializeField] private uint enemyAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        tiles = FindObjectsOfType<Tile>();
        AssignCorrectWalls();
    }

    private void AssignCorrectWalls()
    {
        foreach(Tile tile in tiles)
        {
            if(tile.type == TileType.Wall)
            {
                bool isNorthWall = GetNeighbourNorth(tile)?.type == TileType.Wall;
                bool isEastWall = GetNeighbourEast(tile)?.type == TileType.Wall;
                bool isSouthWall = GetNeighbourSouth(tile)?.type == TileType.Wall;
                bool isWestWall = GetNeighbourWest(tile)?.type == TileType.Wall;

                // All sides no wall
                if (!isNorthWall && !isEastWall && !isSouthWall && !isWestWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNEWS; }
                // North, East and West no wall
                else if (!isNorthWall && !isEastWall && !isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNEW; }
                // North and East no wall
                else if (!isNorthWall && !isEastWall && isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNE; }
                // North and West no wall
                else if (!isNorthWall && isEastWall && !isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNW; }
                // North, West and South no wall
                else if (!isNorthWall && isEastWall && !isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNWS; }
                // North East and South no wall
                else if (!isNorthWall && !isEastWall && isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallNES; }
                // North no wall
                else if (!isNorthWall && isEastWall && isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallN; }
                // East, West and South no wall
                else if (isNorthWall && !isEastWall && !isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallEWS; }
                // East and South no wall
                else if (isNorthWall && !isEastWall && isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallES; }
                // East and West no wall
                else if (isNorthWall && !isEastWall && !isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallEW; }
                // East no wall
                else if (isNorthWall && !isEastWall && isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallE; }
                // West and South no wall
                else if (isNorthWall && isEastWall && !isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallWS; }
                // West no wall
                else if (isNorthWall && isEastWall && !isWestWall && isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallW; }
                // South no wall
                else if (isNorthWall && isEastWall && isWestWall && !isSouthWall) { tile.GetComponent<SpriteRenderer>().sprite = wallS; }
                // All sides wall
                else { tile.GetComponent<SpriteRenderer>().sprite = wall; }
            }

            while(enemyAmount > 0)
            {
                Tile randomTile = GetRandomTile(TileType.DeepGrass);
                Instantiate(prefabsEnemies[0], randomTile.transform.position, Quaternion.identity);
                enemyAmount -= 1;
            }
        }
    }

    public Tile GetTile(int x, int y)
    {
        foreach(Tile tile in tiles)
        {
            if(tile.x == x && tile.y == y)
            {
                return tile;
            }
        }

        return null;
    }

    public Tile GetRandomTile(TileType type)
    {
        for (int i = 0; i < 10000; i++)
        {
            Tile randomTile = GetTile(Random.Range(0, PerlinNoiseMap.instance.map_width), Random.Range(0, PerlinNoiseMap.instance.map_height));

            if (randomTile.type == type)
            {
                return randomTile;
            }
        }

        return null;
    }

    public List<Tile> GetNeighbourList(Tile currentTile)
    {
        List<Tile> neighbours = new List<Tile>();

        neighbours.Add(GetNeighbourNorth(currentTile));
        neighbours.Add(GetNeighbourEast(currentTile));
        neighbours.Add(GetNeighbourSouth(currentTile));
        neighbours.Add(GetNeighbourWest(currentTile));

        return neighbours;
    }

    public Tile GetNeighbourNorth(Tile currentTile)
    {
        if (GetTile(currentTile.x, currentTile.y + 1) != null) { return GetTile(currentTile.x, currentTile.y + 1); }

        return null;
    }

    public Tile GetNeighbourEast(Tile currentTile)
    {
        if (GetTile(currentTile.x + 1, currentTile.y) != null) { return GetTile(currentTile.x + 1, currentTile.y); }

        return null;
    }

    public Tile GetNeighbourSouth(Tile currentTile)
    {
        if (GetTile(currentTile.x, currentTile.y - 1) != null) { return GetTile(currentTile.x, currentTile.y - 1); }

        return null;
    }

    public Tile GetNeighbourWest(Tile currentTile)
    {
        if (GetTile(currentTile.x - 1, currentTile.y) != null) { return GetTile(currentTile.x - 1, currentTile.y); }

        return null;
    }
}
