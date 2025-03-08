using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public enum PlayerNum{
        Player1,
        Player2,
        Player3,
        Player4
    }

    public PlayerNum playerNums;
    public float speed;

    void Update()
    {
        ControlerChange(playerNums);
    }
    void ControlerChange(PlayerNum wichPlayer){
        if(wichPlayer == PlayerNum.Player1){
            if(Input.GetKey(KeyCode.A)){
                MovingRL(-1);
            }
            if(Input.GetKey(KeyCode.S)){
                MovingRL(1);
            }
        }
        if(wichPlayer == PlayerNum.Player2){
            if(Input.GetKey(KeyCode.T)){
                MovingUD(-1);
            }
            if(Input.GetKey(KeyCode.G)){
                MovingUD(1);
            }
        }
        if(wichPlayer == PlayerNum.Player3){
            if(Input.GetKey(KeyCode.K)){
                MovingRL(-1);
            }
            if(Input.GetKey(KeyCode.L)){
                MovingRL(1);
            }
        }
        if(wichPlayer == PlayerNum.Player4){
            if(Input.GetKey(KeyCode.UpArrow)){
                MovingUD(-1);
            }
            if(Input.GetKey(KeyCode.DownArrow)){
                MovingUD(1);
            }
        }
    }
    void MovingRL(int direction){
        transform.Translate(direction*Vector3.right*speed*Time.deltaTime);
        float positionNewX = transform.position.x;
        positionNewX = Mathf.Clamp(positionNewX,-4.6f,4.6f);
        transform.position = new Vector3(positionNewX, transform.position.y, transform.position.z);
    }
    void MovingUD(int direction){
        transform.Translate(direction*Vector3.up*speed*Time.deltaTime);
        float positionNewZ = transform.position.z;
        positionNewZ = Mathf.Clamp(positionNewZ,-4.7f,4.2f);
        transform.position = new Vector3(transform.position.x, transform.position.y, positionNewZ);
    }
}
