using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10;
    public bool hit;
    private BoxCollider2D boxCollider;
    private Animator anim;
    private float direction;
    private float lifetime;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if(lifetime > 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetTrigger("Hit");
        hit = true;
        boxCollider.enabled = false;
        
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        hit = false;
        gameObject.SetActive(true);
        boxCollider.enabled = true;

        float localscalex = transform.localScale.x;
        if(Mathf.Sign(localscalex) != _direction)
        {
            localscalex = -localscalex;
        }

        transform.localScale = new Vector3(localscalex, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
