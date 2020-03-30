using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;                   //gets access to the Unity UI elements
using UnityEngine.SceneManagement;
using System.IO;    //for working with files
using System.Runtime.Serialization.Formatters.Binary; //RSFB helps Serialization

/// <summary>
/// Manages the important gameplay features like keeping the score, restarting levels,
/// saving/Loading data, updating the HUD etc
/// </summary>

public class GameCtrl : MonoBehaviour
{
    public static GameCtrl instance;
    public float restartDelay;
    public GameData data;   //to work with game data in inspector
    public Text txtCoinCount;  // track number ofc oins collected in the HUD

    string dataFilePath;  //path to store the data file
    BinaryFormatter bf;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dat";
        Debug.Log(dataFilePath);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ResetData();
    }

    public void SaveData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close(); //this is imp
    }

    public void LoadData()
    {
        if(File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (GameData)bf.Deserialize(fs);
            //    Debug.Log("Number of Coins = " + data.coinCount);
            txtCoinCount.text = " x " + data.coinCount;
            fs.Close();
        }
    }

     void OnEnable()
    {
        Debug.Log("Data Loaded");
        LoadData();
    }

     void OnDisable()
    {
        Debug.Log("Data Saved");
        SaveData();
    }

     void ResetData()
    {
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        //reset all the data items
        data.coinCount = 0;
        txtCoinCount.text = " x 0 ";
        bf.Serialize(fs, data);
        fs.Close();
        Debug.Log("Data Reset");
    }

    /// <summary>
    /// restarts the level when the player dies
    /// </summary>

    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
        
        Invoke("RestartLevel", restartDelay);
    }

    /// <summary>
    /// restarts the level when the player falls in water
    /// </summary>

    public void PlayerDrowned(GameObject player)
    {
        
        Invoke("RestartLevel", restartDelay);
    }

    public void UpdateCoinCount()
    {
        data.coinCount += 1;
        txtCoinCount.text = " x " + data.coinCount;
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
