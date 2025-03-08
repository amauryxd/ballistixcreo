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
    public delegate void WichOneWin(int plyNum);
    public static WichOneWin wichOneWin;
    public List<GameObject> paredes;
    public delegate void LifeChange(int plyNum);
    public static LifeChange lifeChange;
    public static bool playTime;
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
    void Start()
    {
        ActivarPlayers(PlayerManagerSingleton.Instance.wichToActivate);
        playTime=true;
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
        if(playTime){
            vidaPlys[wichPly-1] = vidaPlys[wichPly-1] - 1;
            lifeChange?.Invoke(wichPly);
            isDeadOrNot(wichPly);
        }
    }
    void isDeadOrNot(int wichPly){
        if(vidaPlys[wichPly-1]==0){
            ActivePlys[wichPly-1].SetActive(false);
            if(wichPly != 1)
            Enemys[wichPly-2].SetActive(false);
            paredes[wichPly-1].SetActive(true);
            ItIsWin();
        }
    }
    void ActivarPlayers(int many){
        if(many>=4){
            Enemys[2].SetActive(false);
            ActivePlys[3].SetActive(true);
        }
        if(many>=3){
            Enemys[1].SetActive(false);
            ActivePlys[2].SetActive(true);
        }
        if(many>=2){
            Enemys[0].SetActive(false);
            ActivePlys[1].SetActive(true);
        }
    }

    void ItIsWin(){
        int howManyActivates=0, howManyActivatesPly=0, howManyActivatesEnmy=0, theActivatedOne=0;
        
        for(int indexActivatesEnmy=0; indexActivatesEnmy<Enemys.Length; indexActivatesEnmy++){
            if(Enemys[indexActivatesEnmy].activeInHierarchy){
                howManyActivatesEnmy++;
                theActivatedOne=indexActivatesEnmy+1;
            }
        }
        for(int indexActivatesPly=0; indexActivatesPly<ActivePlys.Length; indexActivatesPly++){
            if(ActivePlys[indexActivatesPly].activeInHierarchy){
                howManyActivatesPly++;
                theActivatedOne=indexActivatesPly;
            }
        }
        howManyActivates = howManyActivatesEnmy+howManyActivatesPly;
        if(howManyActivates == 1){
            wichOneWin?.Invoke(theActivatedOne);
            playTime=false;
        }
    }
}
