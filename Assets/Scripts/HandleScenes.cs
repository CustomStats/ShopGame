using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class HandleScenes : MonoBehaviour
{
    public Player shopkeeper;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (shopkeeper.CheckValidPlayer())
            {
                SwitchToGameScene();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchToGameScene()
    {
        Debug.Log("Loaded: " + shopkeeper.GetPlayerName());
        SceneManager.LoadScene(2);
    }
}
