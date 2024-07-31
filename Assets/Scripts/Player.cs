using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public int playerLevel = 1;
    public int playerGold = 0;
    public int playerGems = 0;
    public int playerXP = 0;
    public string playerName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public string GetPlayerName()
    {
        return PlayerPrefs.GetString("playerName");
    }

    public bool CheckValidPlayer()
    {
        if (string.IsNullOrEmpty(GetPlayerName()))
        {
            return false;
        }
        return true;
    }
}
