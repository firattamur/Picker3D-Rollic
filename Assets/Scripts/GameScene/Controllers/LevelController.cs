using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject poolTop;
    [SerializeField] GameObject poolGateLeft;
    [SerializeField] GameObject poolGateRight;
    [SerializeField] TextMeshPro levelTitleText;
    [SerializeField] TextMeshPro requiredLevelObjectCountText;
    [SerializeField] int requiredLevelObjectCount;

    GameLevel gameLevel;
    List<GameObject> levelObjects;
    private int collectedLevelObjectsCount = 0;

    void Start()
    {

        SetLevel();

    }

    // create game level objects and set transform values
    void SetLevel()
    {

        levelTitleText.text = gameObject.name;
        requiredLevelObjectCountText.text = "00/" + requiredLevelObjectCount.ToString();

    }


    // void reset level objects with new game level
    public void ResetLevel(GameLevel level)
    {

        gameLevel = level;
        SetLevel();

    }


    // check collided object and count objects other then the player
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
            GameController.instance.SetState(GameState.POOL);
        else
            collectedLevelObjectsCount++;

        requiredLevelObjectCountText.text = collectedLevelObjectsCount.ToString() + "/" + requiredLevelObjectCount.ToString();

        Invoke("CheckIfLevelPassed", 3);

    }

    void CheckIfLevelPassed()
    {

        if (collectedLevelObjectsCount >= requiredLevelObjectCount)
        {

            // activate pool top to allow pass for player
            poolTop.SetActive(true);

            // FIXME: rotation make object skewed this is because gate built from cylinder and cube which parent scale is not uniform
            poolGateLeft.transform.Rotate(  new Vector3(0, -10.0f, 0) );
            poolGateRight.transform.Rotate( new Vector3(0, -10.0f, 0) );

            // TODO: add level unlock increase number of level with game controller
            GameController.instance.SetState(GameState.PLAY);

        }
        else
        {

            // TODO: call game lose function via game controller

        }

    }

}
