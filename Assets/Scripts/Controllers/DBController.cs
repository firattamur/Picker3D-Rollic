using UnityEngine;


public class DBController
{

    // the only object from this class that will be used to access the functions 
    private static readonly DBController shared = new DBController();

    // explicit static constructor to tell C# compiler not to mark type as before field init
    // more info: https://csharpindepth.com/articles/singleton
    static  DBController() {}

    // the constructor is private no one can create new instance from this class
    private DBController() {

    }

    // return the only class object to access class functions    
    public static DBController instance
    {
        get
        {
            return shared;
        }
    }

    public void SetLevelNumber(int levelNumber)
    {
        PlayerPrefs.SetInt("levelNumber", levelNumber);
    }

    public int GetLevelNumber()
    {
        return PlayerPrefs.GetInt("levelNumber", 0);
    }


}
