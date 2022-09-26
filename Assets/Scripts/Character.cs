using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float max_hp=100;
    public float hp=100;
    public float max_exp=100;
    public float exp=0;
    virtual public void characterDie(){
        Destroy(gameObject);
    }

    virtual public IEnumerator TakeDamage(float damageAmount,float interval){
        Debug.Log("受伤"+damageAmount);
        while(true){
            hp -= damageAmount;
            if(hp <= float.Epsilon){
                characterDie();
                break;
            }
            if(interval > float.Epsilon){
                yield return new WaitForSeconds(interval);
                
            }
            else
            {
                break;
            }

        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
