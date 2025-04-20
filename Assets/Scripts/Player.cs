using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMP_Text coinLabel;  //コインテキスト
    public TMP_Text levelLabel; //レベルテキスト
    public int coin;    //現在の所持コイン
    public int level;   //現在のレベル
    public int kill;    //敵を倒した数
    public Button powerUpBtn;   //パワーアップボタン
    public TMP_Text powerUpCoinText;    //パワーアップに必要なコインの数

    //パワーアップに必要なコインを計算
    public int PowerUpCoin()
    {
        return (level - 1) * 20 + 100;
    }

    public void UpdateUI()
    {
        //コインのテキスト
        coinLabel.text = "Coin: " + coin;

        //現在のレベル
        levelLabel.text = "Level: " + level;

        //パワーアップボタン
        int require = PowerUpCoin();
        if(coin < require)
        {
            powerUpBtn.interactable = false;
        }
        else
        {
            powerUpBtn.interactable = true;
        }

        //パワーアップに必要なコインのテキスト
        powerUpCoinText.text = "Coin: " + require;
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        UpdateUI();
        //セーブ機能（今回はOFFにする）
        //SaveData();
    }

    /*セーブ
    public void SaveData()
    {
        PlayerPrefs.SetInt("coin", coin);
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("kill", kill);
    }
    */

    public void OnPowerUp()
    {
        int require = PowerUpCoin();
        if(coin >= require)
        {
            level++;
            AddCoin(-require);
        }
    }

    /*ロード
    private void Awake()
    {
        coin = PlayerPrefs.GetInt("coin", coin);
        level = PlayerPrefs.GetInt("level", level);
        kill = PlayerPrefs.GetInt("kill", kill);
    }
    */

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        
    }
}
