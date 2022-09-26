using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : Character
{
    public float damageStrength = 5.0f;
    public float damageInterval=1.0f;
    private Coroutine damageCoroutine;

    public Image hpMeter;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpMeter.fillAmount=hp/max_hp;
        if(hp==float.Epsilon){
            Destroy(gameObject);
        }
        //hpMeter.value=/max_hp;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            Player playerrole = collision.gameObject.GetComponent<Player>();
            if(damageCoroutine == null){
                damageCoroutine=StartCoroutine(playerrole.TakeDamage(damageStrength,damageInterval));
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Player")){
            if(damageCoroutine != null){
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }

        }
        
    }
}
