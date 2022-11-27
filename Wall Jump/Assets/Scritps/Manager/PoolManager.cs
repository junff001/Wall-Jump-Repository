using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoSingleton<PoolManager>
{
    public PoolDictionary poolDictionary = new PoolDictionary();

    public void SpawnGrid(string tag, Vector2 position)
    {

    }
}
