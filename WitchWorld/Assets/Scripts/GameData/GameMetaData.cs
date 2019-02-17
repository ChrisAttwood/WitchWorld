using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMetaData {

    public Dictionary<string, GameMetaFile> GameSaves;

    public GameMetaData()
    {
        GameSaves = new Dictionary<string, GameMetaFile>();
    }

}
