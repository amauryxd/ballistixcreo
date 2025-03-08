using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWallBall : MonoBehaviour
{
    public int plyNum;
    public delegate void CollisionWithBall(int plyNum);
    public static CollisionWithBall onCollisionWithBall;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball")){
            onCollisionWithBall?.Invoke(plyNum);
            other.gameObject.SetActive(false);
            other.transform.position = Vector3.zero;
            other.transform.eulerAngles = Vector3.zero;
        }
    }
}
