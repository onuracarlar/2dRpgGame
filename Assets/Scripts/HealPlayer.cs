using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealPlayer : MonoBehaviour {
   // public GameObject damageBurst;
    //public Transform hittingPoint;
    public int healToGive;
    public Text shout;
    public float moveSpeed;
    private float deleteOverTime;
    // Use this for initialization
    void Start () {
        deleteOverTime = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (shout.text == "Biraz canını doldurayım...")
        {
            deleteOverTime -= Time.deltaTime;
            if (deleteOverTime<=0)
            {
                shout.text = "";
            }
        }
        if (deleteOverTime<=0)
        {
            deleteOverTime = 3;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player")
        {

            other.gameObject.GetComponent<PlayerHealthManager>().HealPlayer(healToGive);
            //Instantiate(damageBurst, hittingPoint.position, hittingPoint.rotation);
            GetComponent<NpcMovement>().moveSpeed=0;
            
            shout.text = "Biraz canını doldurayım...";
            transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime), transform.position.z);
            


        }
       
    }
}
