using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HUD : MonoBehaviour
{
    public GameObject GamePannel;
    public GameObject PreGamePannel;
    public GameObject PostGamePannel;
    public Text HealthValue; 


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGamePannel();
    }

    void UpdateGamePannel()
    {
        HealthValue.text = Dragon.instance.Health.ToString(); 
    }

    void UpdatePreGamePannel()
    {

    }

    void UpdatePostGamePannel()
    {

    }
}
