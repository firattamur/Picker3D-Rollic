﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelController : MonoBehaviour
{

    [SerializeField] Vector3 levelStartPosition;
    [SerializeField] List<GameObject> levelPrefabs = new List<GameObject>();

    private Vector3 levelPosition;
    private float levelOffset = 33.62f;
    private List<int> levelsIndex = new List<int>();
    private List<GameObject> levels = new List<GameObject>();

    void Awake()
    {

        LoadInitialLevels();

    }

    public void LoadInitialLevels()
    {

        int levelNumber = DBController.instance.GetLevelNumber();

        for (int i = levelNumber; i < levelNumber + levelPrefabs.Count; i++)
        {

            int index = i % levelPrefabs.Count;

            float levelPositionZ = levelStartPosition.z + (index - levelNumber) * levelOffset;
            levelPosition = new Vector3(levelStartPosition.x, levelStartPosition.y, levelPositionZ);

            GameObject level = Instantiate(levelPrefabs[index], levelPosition, Quaternion.identity);

            levels.Add(level);
            levelsIndex.Add(i);

        }

    }

    public void LoadNewLevel()
    {

        int currentLevelIndex = DBController.instance.GetLevelNumber();

        if (currentLevelIndex % levels.Count != levels.Count - 2)
            return;

        int randomIndex   = Random.Range(0, levelsIndex.Count);
        int newLevelIndex = levelsIndex[randomIndex];
        
        GameObject newLevel  = levels[newLevelIndex];

        float levelPositionZ = levelStartPosition.z + currentLevelIndex * levelOffset;
        newLevel.transform.position = new Vector3(newLevel.transform.position.x, newLevel.transform.position.y, levelPositionZ);

        if (levelsIndex.Count == 0)
            for (int i = 0; i < levels.Count; i++)
                levelsIndex.Add(i);

    }

    public void DestroyAllLevels()
    {

        
        for (int i = 0; i < levelPrefabs.Count; i++)
            Destroy(levels[i]);

        levels.Clear();
        levelsIndex.Clear();

    }

}
