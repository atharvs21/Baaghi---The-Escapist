using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	
	public Animator animator;

	// Start is called before the first frame update
	void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }
    
    // Update is called once per frame
    /*void Update()
    {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
    }*/
    protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Enemy")
		TakeDamage(20);
	}
	
	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
		if (currentHealth <= 0)
		{
			animator.SetTrigger("death");
		}
	}
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "Enemy")
			TakeDamage(100);
	}
}
