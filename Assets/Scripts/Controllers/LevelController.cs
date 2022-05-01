using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelController : MonoBehaviour
{

    [SerializeField] Vector3 levelStartPosition;
    [SerializeField] List<GameObject> levelPrefabs = new List<GameObject>();

    private Vector3 levelPosition;
    private float levelOffset = 33.62f;
    private List<GameObject> levels     = new List<GameObject>();
    private List<GameObject> levelsCopy = new List<GameObject>();


    void Awake()
    {

        LoadInitialLevels();

    }

    public void LoadInitialLevels()
    {

        int levelNumber = DBController.instance.GetLevelNumber();

        for (; levelNumber < levelNumber + levelPrefabs.Count; levelNumber++)
        {

            levelNumber %= levelPrefabs.Count;

            float levelPositionZ = levelStartPosition.z + levelNumber * levelOffset;
            levelPosition = new Vector3(levelStartPosition.x, levelStartPosition.y, levelPositionZ);

            GameObject level = Instantiate(levelPrefabs[levelNumber], levelPosition, Quaternion.identity);

        }

    }

    public void LoadNewLevel()
    {

        int currentLevel = DBController.instance.GetLevelNumber();

        if (currentLevel % levels.Count != levels.Count - 2)
            return;

        int randomLevelIndex = Random.Range(0, levelsCopy.Count);

        GameObject newLevel = levelsCopy[randomLevelIndex];

        float levelPositionZ = levelStartPosition.z + currentLevel * levelOffset;
        newLevel.transform.position = new Vector3(newLevel.transform.position.x, newLevel.transform.position.y, levelPositionZ);

        if (levelsCopy.Count == 0)
            levelsCopy = new List<GameObject>(levels);

    }

}
