using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMetaFile  {

    public GameMetaFile(string name)
    {
        Name = name;
    }


	public string Name { get; private set; }

}
