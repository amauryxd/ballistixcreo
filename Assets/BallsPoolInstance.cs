using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsPoolInstance : MonoBehaviour
{
    public int startingObjectsCount;
    public GameObject prefabToCreate;
    public List<GameObject> createdObjects;
    public virtual void StartFunction(){}
    void Start()
    {
        FillObjectPoolBalls();
        StartFunction();
    }

    void FillObjectPoolBalls(){
        for (int indexBalls = 0; indexBalls < startingObjectsCount; indexBalls++){
            GameObject ballsPrefab = Instantiate(prefabToCreate);
            ballsPrefab.SetActive(false);
            createdObjects.Add(ballsPrefab);
        }
    }

    public GameObject AskForBall(){
        GameObject objectToReturn = null;

        for(int indexBallsObjects = 0; indexBallsObjects < createdObjects.Count; indexBallsObjects++){
            if(!createdObjects[indexBallsObjects].activeInHierarchy){
                objectToReturn = createdObjects[indexBallsObjects];
                break;
            }
        }

        return objectToReturn;
    }
}
