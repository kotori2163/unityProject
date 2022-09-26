using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public float wanderIntervalTime=3.0f;
    public float wanderSpeed=2.0f;
    private Rigidbody2D rb2d;
    private Coroutine moveCoroutine;
    private Vector2 endPointPosition;
    private Transform playerTransform;
    private Rigidbody2D player;
    // Start is called before the first frame update
    void Start()
    {
        rb2d=gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(WanderCoroutine());
        player=GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WanderCoroutine(){
        while (true)
        {
            ChooseEndPoint();
            moveCoroutine=StartCoroutine(MoveCoroutine());
            yield return new WaitForSeconds(wanderIntervalTime);
        }

    }

    void ChooseEndPoint(){
        if (player !=null){
        endPointPosition=player.position;
        }
        
    }

    IEnumerator MoveCoroutine(){
        while (true)
        {
            Vector2 newPosition = Vector2.MoveTowards(rb2d.position,endPointPosition,wanderSpeed*Time.fixedDeltaTime);
            rb2d.MovePosition(newPosition);
            yield return new WaitForFixedUpdate();
        }
    }

}
