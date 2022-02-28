using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyh : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;
	public MovingEnemy enemy;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

    private void Update()
    {
        if(currentHealth <= 0f)
        {
			enemy.GetComponent<MovingEnemy>().Deactivate();
        }
    }
    protected void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player bullet")
			TakeDamage(20);
	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}