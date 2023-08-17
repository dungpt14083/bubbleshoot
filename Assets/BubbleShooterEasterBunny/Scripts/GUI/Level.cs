using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level : MonoBehaviour {
    public int number;
    public Text label;
    public GameObject lockimage;
    private bool LevelUnlock;

    public bool getLevelUnlock()
    {
        return LevelUnlock;
    }

	// Use this for initialization
	void Start ()
    {
        if (PlayerPrefs.GetInt("Score" + (number - 1)) > 0 || number == 1)
        {
            LevelUnlock = true;
            lockimage.gameObject.SetActive(false);
            label.text = "" + number;
            SaveLastUnlockedLevel(number);
        }
        else LevelUnlock = false;

        int stars = PlayerPrefs.GetInt( string.Format( "Level.{0:000}.StarsCount", number ), 0 );

        if( stars > 0 )
        {
            for( int i = 1; i <= stars; i++ )
            {
                transform.Find( "Star" + i ).gameObject.SetActive( true );
            }

        }

	}
    
	// Update is called once per frame
	void Update () {
	
	}

    public void StartLevel()
    {
        InitScriptName.InitScript.Instance.OnLevelClicked( number );
    }
    public void SaveLastUnlockedLevel(int levelNumber)
    {
        PlayerPrefs.SetInt("LastUnlockedLevel", levelNumber);
        PlayerPrefs.Save();
    }
}
