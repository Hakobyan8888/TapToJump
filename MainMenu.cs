using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string playGameLevel1;
    public string playGameLevel2;
    public string playGameLevel3;
    public string playGameLevel4;

    public float secondPlayerCost;
    public float thirdPlayerCost;
    public float ForthPlayerCost;

    public int secondPlayerRent;
    public int thirdPlayerRent;
    public int forthPlayerRent;

    public int SecondPlayerBought = 0;
    public int ThirdPlayerBought = 0;
    public int ForthPlayerBought = 0;

    private int Character2True = 0;

    private DiamondManager theDiamondManager;

    public GameObject CharacterMenu1;
    public GameObject CharacterMenu2;
    public GameObject VolumeOption;
    public GameObject CharacterCantBuy;

    public GameObject Help;

    public GameObject PlayerInfo1;
    public GameObject PlayerInfo2;
    public GameObject PlayerInfo3;
    public GameObject PlayerInfo4;

    private float diamondCountStore;

    public Text SecondPlayerBoughtText;
    public Text ThirdPlayerBoughtText;
    public Text ForthPlayerBoughtText;


    void Start()
    {

        if (PlayerPrefs.HasKey("SecondPlayer"))
        {
            SecondPlayerBought = PlayerPrefs.GetInt("SecondPlayer");
        }
        if (PlayerPrefs.HasKey("ThirdPlayer"))
        {
            ThirdPlayerBought = PlayerPrefs.GetInt("ThirdPlayer");
        }
        if (PlayerPrefs.HasKey("ForthPlayer"))
        {
            ForthPlayerBought = PlayerPrefs.GetInt("ForthPlayer");
        }

        Character2True = 0;

        SecondPlayerBought = 0;
        ThirdPlayerBought = 0;
        ForthPlayerBought = 0;
        theDiamondManager = FindObjectOfType<DiamondManager>();
        diamondCountStore = theDiamondManager.diamondCount;
    }
    void Update()
    {

        SecondPlayerBought = PlayerPrefs.GetInt("SecondPlayer");
        PlayerPrefs.SetInt("SecondPlayer", SecondPlayerBought);

        ThirdPlayerBought = PlayerPrefs.GetInt("ThirdPlayer");
        PlayerPrefs.SetInt("ThirdPlayer", ThirdPlayerBought);

        ForthPlayerBought = PlayerPrefs.GetInt("ForthPlayer");
        PlayerPrefs.SetInt("ForthPlayer", ForthPlayerBought);

    }


    public void PlayGame()
    {
        Time.timeScale = 0f;
        CharacterMenu1.SetActive(true);
        CharacterCantBuy.SetActive(false);

    }

    public void Options()
    {
        Time.timeScale = 0f;
        VolumeOption.SetActive(true);
    }

    public void GameHelp()
    {
        Time.timeScale = 1f;
        Help.SetActive(true);
    }
    public void GameHelpBack()
    {
        Time.timeScale = 1f;
        Help.SetActive(false);
    }


    public  void Next()
    {
        Time.timeScale = 0f;
        CharacterMenu1.SetActive(false);
        CharacterMenu2.SetActive(true);
        CharacterCantBuy.SetActive(false);
    }


    public void Previous()
    {
        Time.timeScale = 0f;
        CharacterMenu1.SetActive(true);
        CharacterMenu2.SetActive(false);
        CharacterCantBuy.SetActive(false);
    }


    public void Back()
    {
        Time.timeScale = 0f;
        CharacterMenu1.SetActive(false);
        CharacterMenu2.SetActive(false);
    }

    public void FirstPlayerInfo()
    {
        Time.timeScale = 0f;
        PlayerInfo1.SetActive(true);
    }
    public void FirstPlayerInfoBack()
    {
        Time.timeScale = 0f;
        PlayerInfo1.SetActive(false);
    }

    public void SecondPlayerInfo()
    {
        Time.timeScale = 0f;
        PlayerInfo2.SetActive(true);
    }
    public void SecondPlayerInfoBack()
    {
        Time.timeScale = 0f;
        PlayerInfo2.SetActive(false);
    }

    public void ThirdPlayerInfo()
    {
        Time.timeScale = 0f;
        PlayerInfo3.SetActive(true);
    }
    public void ThirdPlayerInfoBack()
    {
        Time.timeScale = 0f;
        PlayerInfo3.SetActive(false);
    }
    public void ForthPlayerInfo()
    {
        Time.timeScale = 0f;
        PlayerInfo4.SetActive(true);
    }
    public void ForthPlayerInfoBack()
    {
        Time.timeScale = 0f;
        PlayerInfo4.SetActive(false);
    }


    public void Character1PlayGame()
    {
        Application.LoadLevel(playGameLevel1);
        Time.timeScale = 1f;
        CharacterMenu1.SetActive(false);
        CharacterMenu2.SetActive(false);
    }

    public void RentCharacter2()
    {
        if (secondPlayerCost <= theDiamondManager.diamondCount)
        {
            Application.LoadLevel(playGameLevel2);
            Time.timeScale = 1f;
            theDiamondManager.diamondCount = diamondCountStore - secondPlayerRent;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }
    }
    public void RentCharacter3()
    {
        if (secondPlayerCost <= theDiamondManager.diamondCount)
        {
            Application.LoadLevel(playGameLevel3);
            Time.timeScale = 1f;
            theDiamondManager.diamondCount = diamondCountStore - thirdPlayerRent;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }
    }
    public void RentCharacter4()
    {
        if (secondPlayerCost <= theDiamondManager.diamondCount)
        {
            Application.LoadLevel(playGameLevel4);
            Time.timeScale = 1f;
            theDiamondManager.diamondCount = diamondCountStore - forthPlayerRent;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }
    }
    public void YouCantBuyIt()
    {
        if(secondPlayerCost< theDiamondManager.diamondCount || thirdPlayerCost < theDiamondManager.diamondCount || ForthPlayerCost < theDiamondManager.diamondCount)
        {
            Time.timeScale = 1f;
            CharacterCantBuy.SetActive(true);
            CharacterMenu1.SetActive(false);
        }
    }

    public void Character2PlayGame()
    {
        if(SecondPlayerBought==1)
        {
            Application.LoadLevel(playGameLevel2);
            Time.timeScale = 1f;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }
        while (SecondPlayerBought < 1)
        {

            if (secondPlayerCost == theDiamondManager.diamondCount)
            {
                Application.LoadLevel(playGameLevel2);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                theDiamondManager.diamondCount = diamondCountStore - secondPlayerCost;
                SecondPlayerBought = 1;
                if (SecondPlayerBought == 1)
                {
                    SecondPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("SecondPlayer", SecondPlayerBought);
            }
            else if (secondPlayerCost < theDiamondManager.diamondCount)
            {
                Application.LoadLevel(playGameLevel2);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                theDiamondManager.diamondCount = diamondCountStore - secondPlayerCost;
                SecondPlayerBought = 1;
                if (SecondPlayerBought == 1)
                {
                    SecondPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("SecondPlayer", SecondPlayerBought);
            }
        }
        if (SecondPlayerBought == 1)
        {
            Application.LoadLevel(playGameLevel2);
            Time.timeScale = 1f;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }

    }
    

    public void Character3PlayGame()
    {
        if (ThirdPlayerBought == 1)
        {
            Application.LoadLevel(playGameLevel3);
            Time.timeScale = 1f;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
            ThirdPlayerBoughtText.text = "Play";
        }
        while (ThirdPlayerBought < 1)
        {
            if (thirdPlayerCost == theDiamondManager.diamondCount)
            {
                theDiamondManager.diamondCount = 0f;
                Application.LoadLevel(playGameLevel3);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                CharacterMenu2.SetActive(false);
                ThirdPlayerBought = 1;
                if (ThirdPlayerBought == 1)
                {
                    ThirdPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("ThirdPlayer", ThirdPlayerBought);
            }
            else if (thirdPlayerCost < theDiamondManager.diamondCount)
            {
                theDiamondManager.diamondCount = diamondCountStore - thirdPlayerCost;
                Application.LoadLevel(playGameLevel3);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                CharacterMenu2.SetActive(false);
                ThirdPlayerBought = 1;
                if (ThirdPlayerBought == 1)
                {
                    ThirdPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("ThirdPlayer", ThirdPlayerBought);
            }
            
        }
    }

    public void Character4PlayGame()
    {
        if (ForthPlayerBought == 1)
        {
            ForthPlayerBoughtText.text = "Play";
        }
        if (ForthPlayerBought == 1)
        {
            Application.LoadLevel(playGameLevel4);
            Time.timeScale = 1f;
            CharacterMenu1.SetActive(false);
            CharacterMenu2.SetActive(false);
        }
        while (ForthPlayerBought < 1)
        {
            if (ForthPlayerCost == theDiamondManager.diamondCount)
            {
                theDiamondManager.diamondCount = 0f;
                Application.LoadLevel(playGameLevel4);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                CharacterMenu2.SetActive(false);
                ForthPlayerBought = 1;
                if (ForthPlayerBought == 1)
                {
                    ForthPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("ForthPlayer", ForthPlayerBought);
            }
            else if (ForthPlayerCost < theDiamondManager.diamondCount)
            {
                theDiamondManager.diamondCount = diamondCountStore - ForthPlayerCost;
                Application.LoadLevel(playGameLevel4);
                Time.timeScale = 1f;
                CharacterMenu1.SetActive(false);
                CharacterMenu2.SetActive(false);
                ForthPlayerBought = 1;
                if (ForthPlayerBought == 1)
                {
                    ForthPlayerBoughtText.text = "Play";
                }
                PlayerPrefs.SetInt("ForthPlayer", ForthPlayerBought);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
