using UnityEngine;

public enum TileType
{
    grass = 0,
    DeepGrass = 1,
    Wall = 2,
    DeepWall = 3,
}

public class Tile : MonoBehaviour
{

    public int x;
    public int y;

    public TileType type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
