using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectHeroTip : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] characterPrefabs;

    public GameObject SelectBox;
    private GameObject[] characterGameObjects;
    private GameObject SelectBX;
    private int selectedIndex=0;
    private int length;

    private void Start() {
        length=characterPrefabs.Length;
        characterGameObjects=new GameObject[length];
        
    }

    public void updateCharacterShow(){
        if(SelectBX==null){
            SelectBX=GameObject.Instantiate(SelectBox,UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.position,Quaternion.identity);
            SelectBX.transform.SetParent(GameObject.FindGameObjectWithTag("canvas").transform);
        }
        
        SelectBX.transform.position=UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.position;
        Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject);
    }

    


    
}
