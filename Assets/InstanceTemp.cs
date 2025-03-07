using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceTemp : MonoBehaviour
{
    public GameObject instance;
    // Start is called before the first frame update
    void Start()
    {
        instanciarPelota();
    }

    [ContextMenu("EjectuarInstancia")]
    void instanciarPelota(){
        Instantiate(instance,transform.position,transform.rotation);
    }
}
