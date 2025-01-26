using UnityEngine;

public class SpawnInArea : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public Ingredient[] spawnPool;

    public GameObject spawnPrefab;

    public Vector2 TimeDelayBounds;
    public float timeToSpawn;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetTimer();   
    }
    private void resetTimer() {
        timeToSpawn = Random.Range(TimeDelayBounds.x, TimeDelayBounds.y);
        timer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (timer >= timeToSpawn) { 
            var g = Instantiate(spawnPrefab,new Vector3(Random.Range(a.position.x, b.position.x), Random.Range(a.position.y, b.position.y), Random.Range(a.position.z, b.position.z)), Quaternion.identity);
            g.GetComponent<BubbleWithIngredient>().i = spawnPool[Random.Range(0,spawnPool.Length)];
        }
        timer += Time.deltaTime;
    }
}
