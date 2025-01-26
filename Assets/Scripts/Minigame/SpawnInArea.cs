using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class SpawnInArea : MonoBehaviour
{
    public Transform a;
    public Transform b;

    public List<Ingredient> spawnPool;

    public GameObject spawnPrefab;
    public Vector2 TimeDelayBounds;
    public float timeToSpawn;
    public float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resetTimer();
        spawnPool = new List<Ingredient>(MiniGameManager.activeOrder.Ingredients);
        Ingredient[] all = Resources.LoadAll<Ingredient>("Ingredients");
        spawnPool.Append(all[Random.Range(0, all.Length)]);
        spawnPool.Append(all[Random.Range(0, all.Length)]);
    }
    private void resetTimer() {
        timeToSpawn = Random.Range(TimeDelayBounds.x, TimeDelayBounds.y);
        timer = 0f;
    }
    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.gameStarted) { return; }
        if (timer >= timeToSpawn) { 
            GameObject g = Instantiate(spawnPrefab,new Vector3(Random.Range(a.position.x, b.position.x), Random.Range(a.position.y, b.position.y), Random.Range(a.position.z, b.position.z)), Quaternion.identity);
            g.GetComponent<BubbleWithIngredient>().i = spawnPool[Random.Range(0,spawnPool.Count)];
            resetTimer();
        }
        timer += Time.deltaTime;
    }
}
