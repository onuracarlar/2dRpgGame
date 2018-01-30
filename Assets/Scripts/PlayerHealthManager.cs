using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour {

    public int playerMaxHealth;
    public int playerCurrentHealth;
    public Text cupcup;

	// Use this for initialization
	void Start () {
        playerCurrentHealth = playerMaxHealth;

	}
	
	// Update is called once per frame
	void Update () {
        if (playerCurrentHealth<=0)
        {
            gameObject.SetActive(false);
            

        }
        cupcup.text = "Health: "+ playerCurrentHealth.ToString();
        if (playerCurrentHealth>playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
	}
    public void HealPlayer(int healToGive)
    {
        playerCurrentHealth += healToGive;
    }
    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
    }
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }

}
