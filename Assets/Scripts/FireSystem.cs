using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSystem : MonoBehaviour
{
    // Start is called before the first frame update
    private CircleCollider2D circle;
    
    private GameObject FireObject;
    private Player player;
    public float FireDurition;
    public float FireRadis;
    private Coroutine firecor;

    private GameObject Bullet;
    
    private Collider2D enterEnemy;

    private Coroutine cool;
    private float cooltime;
    

    
    private void Awake() {
        FireObject=Resources.Load("Prefabs/Bullet/Bullet") as GameObject;
        Debug.Log("dasdas");
        }
    
    // Start is called before the first frame update
    void Start()
    {
        cooltime=FireDurition+float.Epsilon;
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //circle=gameObject.GetComponent<CircleCollider2D>();
        //circle.radius=FireRadis;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=player.transform.position;
    }
    //private void OnDrawGizmos() {
    //    Gizmos.DrawWireSphere(transform.position,circle.radius);
    //}

    IEnumerator CoolDownTimer(){
        cooltime=float.Epsilon;
        while (cooltime<=FireDurition)
        {
            Debug.Log("冷却时间"+cooltime);
            cooltime += Time.deltaTime;
            yield return null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        
        Debug.Log("触发");
        if(collision.tag=="Enemy"){
            if(cooltime>=FireDurition){
             if(cool!=null){
                StopCoroutine(cool);
             }
            fire(collision.transform);
           
            }
            }
        }
    

    private void OnTriggerExit2D(Collider2D collision) {
        if(collision==enterEnemy){
        Debug.Log("离开");
        if(firecor  != null ){
        StopCoroutine(firecor);
        firecor=null;}}
    }

    private void fire(Transform Target){
            BulletAttr fob=CreatObj();
            fob.transform.SetParent(transform);
            fob.transform.localPosition=Vector3.zero;
            Debug.Log(Random.Range(1,4));
            fob.SetFireObjectData(Target);
            fob.Shoot();
            cool=StartCoroutine(CoolDownTimer());
    }

    private BulletAttr CreatObj(){
        GameObject fireObj=Instantiate(FireObject);
        fireObj.transform.TryGetComponent(out BulletAttr obj);
        return obj;

    }
}
