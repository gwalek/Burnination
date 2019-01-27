using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class BurnLogic : MonoBehaviour
{
    public static BurnLogic instance;
    public GameObject GnomePrefab;
    public float Spawnoffset = 16f;
    public Dictionary<int, Controller> PlayerTable; 
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        AirConsole.instance.onMessage += OnMessage;
        AirConsole.instance.onReady += OnReady;
        AirConsole.instance.onConnect += OnConnect;
        AirConsole.instance.onDisconnect += OnDisconnect;
        AirConsole.instance.onGameEnd += OnGameEnd;
        PlayerTable = new Dictionary<int, Controller>();
    }

    void OnMessage(int deviceID, JToken data)
    {
        Debug.Log(deviceID + " msg: " + data);
        if (data["action"] != null && data["action"].ToString().Equals("interact"))
        {
            Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }

    void OnReady(string code)
    { }

    void OnConnect(int deviceID)
    {
        if (!PlayerTable.ContainsKey(deviceID))
        {
            AddPlayer(deviceID); 
        }

        GetController(deviceID).StartGame(); 
    }

    void AddPlayer(int deviceID)
    {
        Controller c = gameObject.AddComponent<Controller>();
        c.deviceID = deviceID;
        PlayerTable.Add(deviceID, c); 
    }

    Controller GetController(int deviceID)
    {
        return PlayerTable[deviceID]; 
    }

    void OnDisconnect(int deviceID)
    {
        GetController(deviceID).StartGame();
    }

    void OnGameEnd()
    {
    }

    void Update()
    {

    }
}
