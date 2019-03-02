using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class MainMenu : MonoBehaviour {

    GameMetaData GameMetaData;

    public GameObject NewGameCanvas;
    public GameObject LoadGames;
    public Button ButtonPrefab;
    public InputField NewGameName;

    public string NextSceneName;


    void Start () {

        NewGameCanvas.SetActive(false);

        if (!GameFileManager.Exists("Meta"))
        {
            GameMetaData = new GameMetaData();
            GameFileManager.Save(GameMetaData, "Meta");
        }
        else
        {
            GameMetaData = GameFileManager.Load<GameMetaData>("Meta");
        }


        foreach(var g in GameMetaData.GameSaves)
        {
            string t = g.Key;
            var btn = Instantiate(ButtonPrefab, LoadGames.transform);
            btn.onClick.AddListener(delegate { Load(t); });
            btn.transform.GetChild(0).GetComponent<Text>().text = t;
        }




    }

    public void Load(string name)
    {
        GameFile gameFile = GameFileManager.Load<GameFile>(name);
        GameFileManager.GameFile = gameFile;
        SceneManager.LoadScene(NextSceneName);
    }


    public void ChooseNewGame()
    {
        NewGameCanvas.SetActive(true);
    }

    public void CreateNewGame()
    {

        if (!string.IsNullOrEmpty(NewGameName.text))
        {
            string name = NewGameName.text;
            GameMetaFile gameMetaFile = new GameMetaFile(name);
            GameMetaData.GameSaves.Add(name, gameMetaFile);
            GameFileManager.Save(GameMetaData, "Meta");

            GameFile gameFile = new GameFile(name);
            GameFileManager.GameFile = gameFile;
            GameFileManager.Save();
            SceneManager.LoadScene(NextSceneName);

        }
    }
}
