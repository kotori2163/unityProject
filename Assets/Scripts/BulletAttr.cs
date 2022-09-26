using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{
    // Start is called before the first frame update
    public float FireObjectSpeed=10.0f;
    public float FireObjectDamage=10.0f;
    public bool IsTrace=true;
    private Transform FireTarget;
    private Vector3 TargetPosition=Vector3.zero;
    private float distanceToTarget=0.0f;
    private Rigidbody2D rb2d;
    private Rigidbody2D player;
    Vector2 newPosition;
    private Coroutine damageCoroutine;

    public void SetFireObjectData(Transform target){
        FireTarget=target;
        TargetPosition=FireTarget.position;

        
        
    }
    
    public void Shoot(){
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        rb2d=gameObject.GetComponent<Rigidbody2D>();
        newPosition=player.position;
        StartCoroutine(Parabola());
    }

    IEnumerator Parabola(){
        while (true&&transform!=null)
        {
            if(IsTrace&&FireTarget!=null){
                TargetPosition=FireTarget.position;
            }
            
            Vector3 direction=TargetPosition-transform.position;
            float angle_1=360-Mathf.Atan2(direction.x,direction.y)*Mathf.Rad2Deg;
            transform.eulerAngles=new Vector3(0,0,angle_1);
            transform.rotation=transform.rotation*Quaternion.Euler(0,0,18);
            transform.Translate(Vector3.up*FireObjectSpeed*Time.deltaTime);
            //newPosition = Vector2.MoveTowards(newPosition,TargetPosition,FireObjectSpeed*Time.fixedDeltaTime);
            Debug.Log(transform.position+":"+TargetPosition);
            if(FireTarget==null)
            {
                Destroy(gameObject);
            }
            //rb2d.position=newPosition;
            yield return new WaitForFixedUpdate();
        }
    }

   private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Enemy")){
            Debug.Log("Projectile Collision with " + collision.gameObject);
            StopCoroutine(Parabola());
            Enemy enemyrole = collision.gameObject.GetComponent<Enemy>();
            if(damageCoroutine == null){
                damageCoroutine=StartCoroutine(enemyrole.TakeDamage(FireObjectDamage,0.0f));
            }
            Destroy(gameObject);

        }
    }
}
