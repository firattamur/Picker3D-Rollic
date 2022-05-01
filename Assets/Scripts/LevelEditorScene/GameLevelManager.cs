using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameLevelManager: MonoBehaviour
{
    
    [SerializeField] 
    List<GameLevelObjectPrefab> levelObjectPrefabs = new List<GameLevelObjectPrefab>();
    
    Dictionary<GameLevelObjectType, GameObject> typeToPrefab = new Dictionary<GameLevelObjectType, GameObject>();

    public static GameLevelManager instance;

    // use singleton pattern
    void Awake()
    {

        if (!GameLevelManager.instance)
        {
            GameLevelManager.instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        foreach(GameLevelObjectPrefab obj in levelObjectPrefabs)
            typeToPrefab[obj.type] = obj.prefab;

    }

    public GameObject GetPrefabForType(GameLevelObjectType type)
    {
        return typeToPrefab[type];
    }

}
