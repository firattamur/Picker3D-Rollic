using TMPro;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameLevel : MonoBehaviour
{

    [SerializeField] GameObject poolTop;
    [SerializeField] GameObject poolGateLeft;
    [SerializeField] GameObject poolGateRight;
    [SerializeField] TextMeshPro levelTitleText;
    [SerializeField] TextMeshPro requiredLevelObjectCountText;
    [SerializeField] int requiredLevelObjectCount;
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
    public void ResetLevel()
    {

        SetLevel();

    }


    // check collided object and count objects other then the player
    void OnTriggerEnter(Collider other)
    {

        Debug.Log(other.tag);

        if (other.tag == "Player")
        {
            Invoke("CheckIfLevelPassed", 2);
            GameController.instance.SetState(GameState.POOL);
        }  
        else
        {
            collectedLevelObjectsCount++;
        }
            
        requiredLevelObjectCountText.text = collectedLevelObjectsCount.ToString() + "/" + requiredLevelObjectCount.ToString();

    }

    void CheckIfLevelPassed()
    {

        if (collectedLevelObjectsCount >= requiredLevelObjectCount)
        {

            // activate pool top to allow pass for player
            poolTop.SetActive(true);

            // FIXME: rotation make object skewed this is because gate built from cylinder and cube which parent scale is not uniform
            poolGateLeft.transform.Rotate(  new Vector3(0, -90.0f, 0) );
            poolGateRight.transform.Rotate( new Vector3(0, -90.0f, 0) );

            // TODO: add level unlock increase number of level with game controller
            GameController.instance.LevelPassed();

        }
        else
        {

            // TODO: call game lose function via game controller
            GameController.instance.LoseGame();

        }

    }

    void OnValidate()
    {

        requiredLevelObjectCountText.text = "00/" + requiredLevelObjectCount.ToString();

    }

}
