using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public float delayTime=0.0f;
    public float repeatInterval=1.0f;
    public GameObject prefabToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject",delayTime,repeatInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    GameObject SpawnObject(){
        if(prefabToSpawn){
            GameObject prefabObject=Instantiate(prefabToSpawn,transform.position,Quaternion.identity);
            return prefabObject;
        }
        return null;
    }
}
