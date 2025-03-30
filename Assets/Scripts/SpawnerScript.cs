using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawnPoints;
    private float timer;
    private int spawnIndex;
    public int health = 5;
    public Sprite deathSprite;
    public Sprite gateway;
    public bool isGateway = false;

    public Sprite[] sprites;
    void Start()
    {
        // Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
        // Instantiate(enemyPrefab, spawnPoints[1].transform.position, Quaternion.identity);
        timer = Time.time + 7.0f;
        int rnd = UnityEngine.Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[rnd];   
    }
    void Update()
    {
        if(timer < Time.time)
        {
            // Instantiate(enemyPrefab, spawnPoints[spawnIndex % 2].transform.position, Quaternion.identity);
            timer = Time.time + 7.0f;
            spawnIndex++;
        }
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        GetComponent<SpriteRenderer>().color = Color.red;
        if(health < 0)
        {
            GetComponent<SpriteRenderer>().sprite = deathSprite;
            if(isGateway)
            {
                Invoke("OpenGateway", 0.5f);
            } else
            {
                Destroy(gameObject);
            }

        }
        Invoke("DefaultColor", 0.3f);
    }

    private void OpenGateway()
    {
        GetComponent<SpriteRenderer>().sprite = gateway;
    }

    private void DefaultColor()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
