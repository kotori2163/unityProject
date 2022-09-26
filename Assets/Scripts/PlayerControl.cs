using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3.0f;
    private Vector2 movDir = new Vector2();
    private Animator anmi;
    // Start is called before the first frame update
    void Start()
    {
        anmi=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        updateStae();
    }

    private void FixedUpdate() {
        ContrlCharacter();
    }

    private void ContrlCharacter(){
        
        movDir.x=Input.GetAxisRaw("Horizontal");
        movDir.y=Input.GetAxisRaw("Vertical");
        movDir.Normalize();
        transform.position  += new Vector3(movDir.x,movDir.y,0.0f)*moveSpeed*Time.deltaTime;
    }

    private void updateStae(){
        if(Mathf.Approximately(movDir.x,0.0f)&&Mathf.Approximately(movDir.y,0.0f)){
            return;
            

        }
        else if(movDir.x<0){
            anmi.SetBool("isLeft",true);
            anmi.SetBool("isRight",false);
            anmi.SetBool("isFront",false);
            anmi.SetBool("isBack",false);
        }
        else if(movDir.x>0)
        {
            anmi.SetBool("isLeft",false);
            anmi.SetBool("isRight",true);
            anmi.SetBool("isFront",false);
            anmi.SetBool("isBack",false);
        }
        else if(movDir.y<0)
        {
            anmi.SetBool("isLeft",false);
            anmi.SetBool("isRight",false);
            anmi.SetBool("isFront",true);
            anmi.SetBool("isBack",false);
        }
        else
        {
            anmi.SetBool("isLeft",false);
            anmi.SetBool("isRight",false);
            anmi.SetBool("isFront",false);
            anmi.SetBool("isBack",true);
        }

    }
}
