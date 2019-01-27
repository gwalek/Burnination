using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq; 

public class BurnLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AirConsole.instance.onMessage += OnMessage; 
    }

    void OnMessage( int deviceID, JToken data)
    {
        Debug.Log(deviceID + " msg: " + data);
        if (data["action"] != null && data["action"].ToString().Equals("interact"))
        {
            Camera.main.backgroundColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
