using System.Numerics;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PlayerScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4.0f;
    Rigidbody2D rb; 

    private float health = 200;
    private float startHealth;

    public bool turnedLeft =  false;
    public Image healthFill;
    private float healthWidth;

    public TextMeshProUGUI MainText;
    public Image redOverlay;
    public TextMeshProUGUI expText;

    private int experience = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthWidth = healthFill.sprite.rect.width;
        startHealth = health;
        MainText.gameObject.SetActive(true);
        redOverlay.gameObject.SetActive(true);
        Invoke("HideTitle", 2);
    }


    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new UnityEngine.Vector2(horizontal * speed, vertical * speed);
        turnedLeft = false;
        if(horizontal  > 0)
        {
            GetComponent<Animator>().Play("Right");
        } else if(horizontal  < 0)
        {
            GetComponent<Animator>().Play("Left");
            turnedLeft = true;
        } else if(vertical  > 0)
        {
            GetComponent<Animator>().Play("Up");
        } else if(vertical  < 0)
        {
            GetComponent<Animator>().Play("Down");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
            health -= collision.gameObject.GetComponent<EnemyScript>().GetHitStrength();
            if(health < 1)
            {
                healthFill.enabled = false;
                MainText.gameObject.SetActive(true);
                MainText.text = "Game Over";
                redOverlay.gameObject.SetActive(true);
            }
            UnityEngine.Vector2 temp = new UnityEngine.Vector2(healthWidth*(health/startHealth), healthFill.sprite.rect.height);
            healthFill.rectTransform.sizeDelta = temp;
            Invoke("HidePlayerBlood", 0.25f);
        }
        else if (collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<SpawnerScript>().GetGateway();
        }
    }
    void HidePlayerBlood()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GainExperience(int amount)
    {
        experience += amount;
        expText.text = experience.ToString();
    }
    
    void HideTitle()
    {
        MainText.gameObject.SetActive(false);
        redOverlay.gameObject.SetActive(false);
    }
}
