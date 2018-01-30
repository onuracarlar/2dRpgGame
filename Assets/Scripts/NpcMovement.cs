using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NpcMovement : MonoBehaviour {

    public float moveSpeed;
    private float moveSpeedDuzeltme;

    public bool npcMoving;
    
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    float testo;
    
    public float waitToReload;

    private Animator npcAnim;
    private Vector2 npcLastMove;
    private Rigidbody2D npcRigidbody;
    
    private Vector3 moveDirection;

    // Use this for initialization
    void Start () {
        npcAnim = GetComponent<Animator>();
        npcRigidbody = GetComponent<Rigidbody2D>();
        // timeBetweenMoveCounter = timeBetweenMove;
        // timeToMoveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
        moveSpeedDuzeltme = 5;
    }
	
	// Update is called once per frame
	void Update () {
        if (moveSpeed<=0)
        {
            moveSpeedDuzeltme -= Time.deltaTime;
            if (moveSpeedDuzeltme<=0)
            {
                moveSpeed = 3;
                moveSpeedDuzeltme = 5;
            }
        }
        if (npcMoving)
        {
            
            timeToMoveCounter -= Time.deltaTime;
            npcRigidbody.velocity = moveDirection;
            
            if (timeToMoveCounter < 0f)
            {
                npcMoving = false;
                testo = Random.Range(0f, 1f);
                // timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            npcRigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0f)
            {
                npcMoving = true;
                // timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                
                if (testo>0.75f)
                {
                    moveDirection = new Vector3(0f, Random.Range(0.75f, 1f) * moveSpeed, 0f);
                }
                if ((testo > 0.5f)&&(testo<0.75f))
                {
                    moveDirection = new Vector3(0f, Random.Range(-0.75f, -1f) * moveSpeed, 0f);
                }
                if (testo<0.5f&&testo>0.25f)
                {
                    moveDirection = new Vector3(Random.Range(-1f, -0.75f) * moveSpeed, 0f, 0f);
                }
                if (testo < 0.25f)
                {
                    moveDirection = new Vector3(Random.Range(0.75f, 1f) * moveSpeed, 0f, 0f);
                }
                // moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                npcLastMove =new Vector2 (moveDirection.x, moveDirection.y);
            }
        }
        npcAnim.SetFloat("NpcMoveX", moveDirection.x);
        npcAnim.SetFloat("NpcMoveY", moveDirection.y);
        npcAnim.SetFloat("NpcLastMoveX", npcLastMove.x);
        npcAnim.SetFloat("NpcLastMoveY", npcLastMove.y);
        npcAnim.SetBool("NpcMoving", npcMoving);
       
        
    }
}
