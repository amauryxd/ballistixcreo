using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsInstanceManager : BallsPoolInstance
{
    
    public Vector3[] objectsPositions;
    public float[] gradeRotations;
    public List<GameObject> spawnGameObjects;
    public override void StartFunction()
    {
        CreateSpawnPoints();
        StartCoroutine(WaitBallSapwn());
    }

    public IEnumerator WaitBallSapwn(){
        while(true){
            int randIndex;
            randIndex = Random.Range(0, spawnGameObjects.Count);
            GameObject actualBall = AskForBall();
            actualBall.transform.rotation = spawnGameObjects[randIndex].transform.rotation;
            actualBall.transform.position = spawnGameObjects[randIndex].transform.position;
            yield return new WaitForSeconds(5);
            actualBall.SetActive(true);
        }
    }
    void CreateSpawnPoints(){
        for (int indexSpawns = 0; indexSpawns < 4; indexSpawns++){
            GameObject pointSpawn = new GameObject();
            pointSpawn.name = "SpawnPoint "+indexSpawns;
            pointSpawn.transform.position = objectsPositions[indexSpawns];
            pointSpawn.transform.eulerAngles = new Vector3(0,gradeRotations[indexSpawns],0);
            pointSpawn.transform.parent = gameObject.transform;
            spawnGameObjects.Add(pointSpawn);
        }
    }
}
