using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagerSingleton : MonoBehaviour
{
    public int wichToActivate;
    private static PlayerManagerSingleton instance;
    public static PlayerManagerSingleton Instance{
        get{
            if(instance == null){
                GameObject gameManager = new GameObject();
                instance = gameManager.AddComponent<PlayerManagerSingleton>();
                gameManager.name = "GameManagerSingleton";
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance != null){
            Destroy(gameObject);
        }else{
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void wichAssigner(int ply){
        wichToActivate = ply;
    }

    public void ChangeSceneToGame(){
        SceneManager.LoadScene("Game");
    }
}
