using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public Grid grid;
    public List<GameObject> pools;
    private Dictionary<string, GameObject> poolDictionary = new Dictionary<string, GameObject>();

    void Start()
    {
        foreach (var pool in pools)
        {
            GameObject obj = Instantiate(pool);
            obj.SetActive(false);
            poolDictionary.Add(pool.name, obj);
        }

        SpawnStage("2 Stage", new Vector2(0, 26));
    }

    public void SpawnStage(string tag, Vector2 position)
    {
        if (poolDictionary.ContainsKey(tag))
        {
            poolDictionary[tag].SetActive(true);
            poolDictionary[tag].transform.parent = grid.transform;
            poolDictionary[tag].transform.position = position;
        }
    }
}
