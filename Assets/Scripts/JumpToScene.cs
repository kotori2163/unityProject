using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Scene JumpTScene;
    public void JTScene(){
        SceneManager.LoadScene("MainScene");
        //Player=GameObject.Instantiate()
    }
}
