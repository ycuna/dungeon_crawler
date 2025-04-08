using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] spawners;
    private int level = 1;
    private int zombieCount = 0;
    private int zombieLimit = 10;

    public GameObject player;
    public GameObject weapon;
    public GameObject hudCanvas;
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        int rnd = Random.Range(0, spawners.Length);
        spawners[rnd].GetComponent<SpawnerScript>().SetGateway(true);
        foreach(GameObject spawner in spawners)
        {
            spawner.GetComponent<SpawnerScript>().SetHealth(level + Random.Range(3,6));
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(player.gameObject);
        DontDestroyOnLoad(weapon.gameObject);
        DontDestroyOnLoad(hudCanvas.gameObject);
    }

    public void SetZombieCount(int amount)
    {
        zombieCount += amount;
    }

    public int GetZombieCount()
    {
        return zombieCount;
    }

    public int GetZombieLimit()
    {
        return zombieLimit;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
