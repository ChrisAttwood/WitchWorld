using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameFile {

    public GameFile(string name)
    {
        Name = name;

    }

    public string Name { get; private set; }


}
