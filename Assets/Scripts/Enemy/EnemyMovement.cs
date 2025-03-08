using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum WichEnemy{
        Enemy2,
        Enemy3,
        Enemy4
    }
    public WichEnemy enemyWich;
    public float speed;
    public void MovingRL(int direction){
        transform.Translate(direction*Vector3.up*speed*Time.deltaTime);
        float positionNewX = transform.position.x;
        positionNewX = Mathf.Clamp(positionNewX,-5.2f,4.1f);
        transform.position = new Vector3(positionNewX, transform.position.y, transform.position.z);
    }
    public void MovingUD(int direction){
        transform.Translate(direction*Vector3.up*speed*Time.deltaTime);
        float positionNewZ = transform.position.z;
        positionNewZ = Mathf.Clamp(positionNewZ,-4.7f,4.2f);
        transform.position = new Vector3(transform.position.x, transform.position.y, positionNewZ);
    }

}
