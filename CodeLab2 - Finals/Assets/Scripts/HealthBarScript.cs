using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour {

    Image healthBar;
    float maxHealth = 100f;
    public static float health;

	// Use this for initialization
	void Start () {
        healthBar = GetComponent<Image>();
        health = maxHealth;

	}
	
	// Update is called once per frame
	void Update () {

        healthBar.fillAmount = health / maxHealth;
        if (health == 0)
        {
            SceneManager.LoadScene(3);
        }
	}
}
