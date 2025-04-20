using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TMP_Text coinLabel;  //�R�C���e�L�X�g
    public TMP_Text levelLabel; //���x���e�L�X�g
    public int coin;    //���݂̏����R�C��
    public int level;   //���݂̃��x��
    public int kill;    //�G��|������
    public Button powerUpBtn;   //�p���[�A�b�v�{�^��
    public TMP_Text powerUpCoinText;    //�p���[�A�b�v�ɕK�v�ȃR�C���̐�

    //�p���[�A�b�v�ɕK�v�ȃR�C�����v�Z
    public int PowerUpCoin()
    {
        return (level - 1) * 20 + 100;
    }

    public void UpdateUI()
    {
        //�R�C���̃e�L�X�g
        coinLabel.text = "Coin: " + coin;

        //���݂̃��x��
        levelLabel.text = "Level: " + level;

        //�p���[�A�b�v�{�^��
        int require = PowerUpCoin();
        if(coin < require)
        {
            powerUpBtn.interactable = false;
        }
        else
        {
            powerUpBtn.interactable = true;
        }

        //�p���[�A�b�v�ɕK�v�ȃR�C���̃e�L�X�g
        powerUpCoinText.text = "Coin: " + require;
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        UpdateUI();
        //�Z�[�u�@�\�i�����OFF�ɂ���j
        //SaveData();
    }

    /*�Z�[�u
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

    /*���[�h
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
