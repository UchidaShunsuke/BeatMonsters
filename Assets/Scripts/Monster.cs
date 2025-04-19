using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public TMP_Text hpLabel;    //HPテキスト
    private int hp;         //HP
    private int maxHp;      //最大HP

    void Start()
    {
        maxHp = 10;
        hp = maxHp;
        hpLabel.text = hp + "/" + maxHp;
    }

    void Update()
    {
        
    }
}
