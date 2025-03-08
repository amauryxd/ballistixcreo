using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : EnemyMovement
{
    public float distance;
    public int segments;
    public LayerMask layerMask;

    void Update()
    {
        RayCastToUp();
        RayCastToDown();
    }
    public void SelectEnemyToMove(int dir){
        if(enemyWich == WichEnemy.Enemy2){
            MovingUD(dir);
        }
        if(enemyWich == WichEnemy.Enemy3){
            MovingRL(-dir);
        }
        if(enemyWich == WichEnemy.Enemy4){
            MovingUD(dir);
        }
    }

    void RayCastToUp()
    {
        float startAngle = gameObject.transform.localEulerAngles.y;
        float angleStep = 90f / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle = startAngle + (i * angleStep);
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 origin = transform.position+new Vector3(0,1f,0);

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, distance, layerMask))
            {
                SelectEnemyToMove(-1);
            }
        }
    }
    void RayCastToDown()
    {
        float startAngle = gameObject.transform.localEulerAngles.y+270f;
        
        float angleStep = 90f / segments;

        for (int i = 0; i < segments; i++)
        {
            float angle = startAngle + (i * angleStep);
            Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad));
            Vector3 origin = transform.position+new Vector3(0,1f,0);

            RaycastHit hit;
            if (Physics.Raycast(origin, direction, out hit, distance, layerMask))
            {
                SelectEnemyToMove(1);
            }

        }
    }
}
