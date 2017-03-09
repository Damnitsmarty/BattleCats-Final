using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStatsScript : MonoBehaviour
{

    public int BattleCatCoins;
    public int CatNip;
    public int NumberOfCats;
    public GameObject CatNipButtonOn;
    public GameObject CatNipButtonOff;
    public bool CatNipMode = false;
    public Text BattleCatCoinsText;
    public Text CatNipText;






    // Use this for initialization
    void Start()
    {
        BattleCatCoins = PlayerPrefs.GetInt("BattleCatCoinsFile");
        CatNip = PlayerPrefs.GetInt("CatNipFile");
        NumberOfCats = PlayerPrefs.GetInt("NumberOfCatsFile");
    }

    // Update is called once per frame
    void Update()
    {
        BattleCatCoinsText.text = BattleCatCoins.ToString();
        CatNipText.text = CatNip.ToString();
    }
    public void CatNipUsed()
    {
        CatNip = CatNip - 1;
    }
    public void CatNipModeActivated()
    {
        CatNipMode = true;
        CatNipButtonOn.SetActive(false);
        CatNipButtonOff.SetActive(true);

    }


    public void CatNipModeDeactivated()
    {
        CatNipMode = false;
        CatNipButtonOn.SetActive(true);
        CatNipButtonOff.SetActive(false);

    }

    public void GymBuilt()
    {
        BattleCatCoins = BattleCatCoins - 200;

    }

    public void GymUpgradedLevel2()
    {
        BattleCatCoins = BattleCatCoins - 100;

    }

    public void GymUpgradedLevel3()
    {
        BattleCatCoins = BattleCatCoins - 300;
    }

    public void ArcadeBuilt()
    {
        BattleCatCoins = BattleCatCoins - 200;

    }

    public void ArcadeUpgradedLevel2()
    {
        BattleCatCoins = BattleCatCoins - 100;

    }

    public void ArcadeUpgradedLevel3()
    {
        BattleCatCoins = BattleCatCoins - 300;
    }


    public void KitchenBuilt()
    {
        BattleCatCoins = BattleCatCoins - 200;

    }

    public void KitchenUpgradedLevel2()
    {
        BattleCatCoins = BattleCatCoins - 100;

    }

    public void KitchenUpgradedLevel3()
    {
        BattleCatCoins = BattleCatCoins - 300;
    }





    void OnApplicationPause()
    {
        PlayerPrefs.SetInt("BattleCatCoinFile", BattleCatCoins);
        PlayerPrefs.SetInt("CatNipFile", CatNip);
        PlayerPrefs.SetInt("NumberOfCatsFile",NumberOfCats);

    }





}