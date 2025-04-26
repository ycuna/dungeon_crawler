using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    private bool hasHit;
    private float weaponDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hasHit == false)
        {
            float angle = Mathf.Atan2(rb.linearVelocityY, rb.linearVelocityX) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    [System.Obsolete]
    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasHit = true;
        rb.linearVelocity = Vector2.zero;
        rb.isKinematic = true;
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        weaponDamage = 20;
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().TakeDamage(weaponDamage);
        }
        if(collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<SpawnerScript>().TakeDamage(weaponDamage);
        }
    }

}
