using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PoolManager : MonoSingleton<PoolManager>
{
    public Transform stageParent;
    public List<GameObject> stagePrefabs;
    private List<GameObject> stages = new List<GameObject>();
    private Queue<GameObject> poolQueue = new Queue<GameObject>();

    void Start()
    {
        Initialization();
    }

    void Initialization()
    {
        foreach (var stage in stagePrefabs)
        {
            GameObject initStage = Instantiate(stage);
            initStage.transform.parent = stageParent;
            initStage.SetActive(false);
            stages.Add(initStage);
        }
    }

    public void RandomSpawnStage(Vector2 jointPos)
    {
        int index = Random.Range(0, stages.Count - 1);
        stages[index].transform.position = jointPos;

        if (!stages[index].activeSelf)
        {
            stages[index].SetActive(true);
        }
    }

    public void RandomSpawnStageTest(Vector2 jointPos)
    {
        int index = Random.Range(0, stages.Count);
        GameObject newStage = Instantiate(stagePrefabs[index]);
        newStage.transform.parent = stageParent;
        newStage.transform.position = jointPos;
    }
}
