using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class JsonReading : MonoBehaviour
{
    private string path;

    public JsonReading(string path)
    {
        this.path = path;
    }

    public JsonStructure Read()
    {
        string jsonString = ReadJson(path);
        JsonStructure map = ConvertJson(jsonString);
        return map;
    }

    private string ReadJson(string path)
    {
        StreamReader jsonFile = new StreamReader(path);
        return jsonFile.ReadToEnd();
    }

    private JsonStructure ConvertJson(string jsonString)
    {
        return JsonUtility.FromJson<JsonStructure>(jsonString);
    }
}

[Serializable]
public class JsonStructure
{
    public int width;
    public int height;
    public int playerPosition;
    public List<Walls> walls;
    public List<int> blocksPositions;
    public List<int> finishPositions;
}

[Serializable]
public class Walls
{
    public bool top;
    public bool bot;
    public bool left;
    public bool right;
}
