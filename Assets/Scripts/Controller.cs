using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject sectorPrefab;
    public GameObject horizontalPrefab;
    public GameObject verticalPrefab;
    public GameObject playerPrefab;
    public GameObject blockPrefab;

    void Start()
    {
        Map map = new Map(sectorPrefab, horizontalPrefab, verticalPrefab,playerPrefab,blockPrefab);
        map.CreateFullMap();
    }    
}
