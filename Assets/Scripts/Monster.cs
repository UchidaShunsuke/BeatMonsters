using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Player player;   //プレイヤーの情報
    private int levelMinHp = 20;    //最低レベルのHP
    private int levelMaxHp = 10000; //最大レベルのHP
    private int maxLevel = 100;     //最大レベル
    private float degree = 1.2f;    //指数
    private float coinMultiplier = 0.5f;    //コインの獲得倍率
    public TMP_Text hpLabel;    //HPテキスト
    private int hp;         //HP
    private int maxHp;      //最大HP
    public Image monsterImage;  //画像を切り替えるコンポーネント
    public Sprite[] monsterImages;  //モンスターのリスト
    public GameObject hitEffect;    //攻撃エフェクト
    public GameObject coinEffect;   //コインエフェクト
    public AudioClip coinSE;    //コイン効果音
    public AudioSource audioSource; //オーディオソース

    //モンスターのHPを計算する
    private int CalcHp()
    {
        //モンスターを倒した数に応じて何割のHPにするか
        float tmp = Mathf.Pow((float)player.kill / maxLevel, degree);

        //式に合わせてHPを決定
        int hp = (int)((levelMaxHp - levelMinHp) * tmp + levelMinHp + 0.5f);

        return hp;
    }

    
    //モンスターの初期化
    private void Setup()
    {
        maxHp = CalcHp();
        hp = maxHp;
        hpLabel.text = hp + "/" + maxHp;

        //どの画像を使うか乱数で決める
        int imageIndex = Random.Range(0, monsterImages.Length);

        //画像の変更
        monsterImage.sprite = monsterImages[imageIndex];
    }

    void Start()
    {
        Setup();
    }

    public void OnClickMonster()
    {
        //ダメージを与える
        hp -= player.level;
        hpLabel.text = hp + "/" + maxHp;

        //攻撃エフェクト
        GameObject hit = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(hit, 0.5f);

        //もし死んでいたら
        if(hp <= 0)
        {
            //コインの音を鳴らす
            audioSource.PlayOneShot(coinSE);
            //コインのエフェクトを出す
            GameObject coin = Instantiate(coinEffect, transform.position, Quaternion.identity);
            Destroy(coin, 3f);

            //プレイヤーの倒したモンスターの数を増やす
            player.kill++;
            //HPからコインの数を計算
            int amount = (int)(CalcHp() * coinMultiplier);
            //コインを追加
            player.AddCoin(amount);
            //次のモンスターを出す
            Setup();
        }
    }

    void Update()
    {
        
    }
}
