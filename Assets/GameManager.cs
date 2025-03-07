using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] Enemys;
    public GameObject[] ActivePlys;
    private static GameManager instance;
    public int[] vidaPlys;
    public List<GameObject> paredes;
    public delegate void LifeChange(int plyNum);
    public static LifeChange lifeChange;
    public static GameManager Instance{
        get{
            if(instance == null){
                GameObject gameManager = new GameObject();
                instance = gameManager.AddComponent<GameManager>();
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

    void OnEnable()
    {
        CollisionWallBall.onCollisionWithBall += LossLife;
    }

    void OnDisable()
    {
        CollisionWallBall.onCollisionWithBall -= LossLife;
    }

    void LossLife(int wichPly){
        vidaPlys[wichPly-1] = vidaPlys[wichPly-1] - 1;
        lifeChange?.Invoke(wichPly);
        isDeadOrNot(wichPly);
    }
    void isDeadOrNot(int wichPly){
        if(vidaPlys[wichPly-1]==0){
            ActivePlys[wichPly-1].SetActive(false);
            if(wichPly != 1)
            Enemys[wichPly-2].SetActive(false);
            paredes[wichPly-1].SetActive(true);
        }
    }
}
