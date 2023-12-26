
using System.IO;
using UnityEngine;

//
// Game Cartridge Data Editor v2021.04.04
//
// 2020.12.22
//

public class GameCartridge : MonoBehaviour
{
    public static GameCartridge gameCartridge;

    public string gameCartridgeDataFile;

    //public GameController gameController;

    public GameCartridgeData gameCartridgeData;

    private string gameCartridgeDataFilePath = "/StreamingAssets";


    private void Awake()
    {
        gameCartridge = this;
    }


    private void Start()
    {
        LoadGameCartridgeData();

        Debug.Log(gameCartridgeData.gameTitle);
    }


    private void LoadGameCartridgeData()
    {
        string filePath = Application.dataPath + gameCartridgeDataFilePath + "/" + gameCartridgeDataFile + ".json";

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);

            gameCartridgeData = JsonUtility.FromJson<GameCartridgeData>(dataAsJson);
        }

        else
        {
            Debug.LogError("ERROR: Game cartridge data file does not exist.");
        }
    }


    private void SaveGameCartridgeData()
    {
        string dataAsJson = JsonUtility.ToJson(gameCartridgeData);

        string filePath = Application.dataPath + gameCartridgeDataFilePath;

        File.WriteAllText(filePath, dataAsJson);
    }


} // end of class
