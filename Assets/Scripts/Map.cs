using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    private GameObject sectorPrefab;
    private GameObject horizontalWallPrefab;
    private GameObject verticalWallPrefab;
    private GameObject playerPrefab;
    private GameObject blockPrefab;

    private List<GameObject> sectors;

    private int width;
    private int height;
    private int playerPosition;
    private List<Walls> walls;
    private List<int> blocksPositions;
    private List<int> finishPositions;

    public Map(GameObject sectorPrefab, GameObject horizontalPrefab, GameObject verticalPrefab, GameObject playerPrefab, GameObject blockPrefab)
    {
        string path = "Assets/Json/map.json";
        JsonReading jsonReading = new JsonReading(path);
        JsonStructure mapData = jsonReading.Read();

        width = mapData.width;
        height = mapData.height;
        playerPosition = mapData.playerPosition;
        blocksPositions = mapData.blocksPositions;
        walls = mapData.walls;
        finishPositions = mapData.finishPositions;

        this.sectorPrefab = sectorPrefab;
        horizontalWallPrefab = horizontalPrefab;
        verticalWallPrefab = verticalPrefab;
        this.blockPrefab = blockPrefab;
        this.playerPrefab = playerPrefab;

    }

    public void CreateFullMap()
    {
        CreateSectors();
        CreateWalls();
        
        CreateBlocks();
        CreateFinishs();
        CreatePlayer();
    }

    private void CreateSectors()
    {
        sectors = new List<GameObject>();
        for(int i = 0; i < width; i++)
        {
            for (int k = 0; k < height; k++)
            {
                float x = sectorPrefab.transform.position.x + i;
                float z = sectorPrefab.transform.position.z + k;
                Vector3 position = new Vector3(x, 0, z);
                GameObject sector = Instantiate(sectorPrefab, position, Quaternion.identity);
                sectors.Add(sector);
            }
        }
    }

    private void CreateWalls()
    {
        for(int i = 0; i < walls.Count; i++)
        {
            if (walls[i].top)
                CreateOneWall(horizontalWallPrefab,0,0.5f,i);
            if (walls[i].bot)
                CreateOneWall(horizontalWallPrefab, 0, -0.5f,i);
            if (walls[i].left)
                CreateOneWall(verticalWallPrefab, -0.5f, 0,i);
            if (walls[i].right)
                CreateOneWall(verticalWallPrefab, 0.5f, 0,i);
        }
    }

    private void CreateOneWall(GameObject wall,float offsetX,float offsetZ, int count)
    {
        int offX = (count / width);
        int offZ = (count % height);

        float x = wall.transform.position.x + offsetX + offX;
        float y = wall.transform.position.y;
        float z = wall.transform.position.z + offsetZ + offZ;

        Vector3 position = new Vector3(x, y, z);

        Instantiate(wall, position, Quaternion.identity);
    }

    private void CreatePlayer()
    {
        Instantiate(playerPrefab, sectors[playerPosition-1].transform.position, Quaternion.identity);
    }

    private void CreateBlocks()
    {
        for (int i = 0; i< blocksPositions.Count; i++)
        {
            Instantiate(blockPrefab, sectors[blocksPositions[i] - 1].transform.position, Quaternion.identity);
        }
        
    }

    private void CreateFinishs()
    {
        for(int i = 0; i < finishPositions.Count; i++)
        {
            sectors[finishPositions[i] - 1].AddComponent<FinishBlock>();
        }  
    }
}

