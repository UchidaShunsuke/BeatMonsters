using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public Player player;   //�v���C���[�̏��
    private int levelMinHp = 20;    //�Œ჌�x����HP
    private int levelMaxHp = 10000; //�ő僌�x����HP
    private int maxLevel = 100;     //�ő僌�x��
    private float degree = 1.2f;    //�w��
    private float coinMultiplier = 0.5f;    //�R�C���̊l���{��
    public TMP_Text hpLabel;    //HP�e�L�X�g
    private int hp;         //HP
    private int maxHp;      //�ő�HP
    public Image monsterImage;  //�摜��؂�ւ���R���|�[�l���g
    public Sprite[] monsterImages;  //�����X�^�[�̃��X�g

    //�����X�^�[��HP���v�Z����
    private int CalcHp()
    {
        //�����X�^�[��|�������ɉ����ĉ�����HP�ɂ��邩
        float tmp = Mathf.Pow((float)player.kill / maxLevel, degree);

        //���ɍ��킹��HP������
        int hp = (int)((levelMaxHp - levelMinHp) * tmp + levelMinHp + 0.5f);

        return hp;
    }

    
    //�����X�^�[�̏�����
    private void Setup()
    {
        maxHp = CalcHp();
        hp = maxHp;
        hpLabel.text = hp + "/" + maxHp;

        //�ǂ̉摜���g���������Ō��߂�
        int imageIndex = Random.Range(0, monsterImages.Length);

        //�摜�̕ύX
        monsterImage.sprite = monsterImages[imageIndex];
    }

    void Start()
    {
        Setup();
    }

    public void OnClickMonster()
    {
        //�_���[�W��^����
        hp -= player.level;
        hpLabel.text = hp + "/" + maxHp;

        //��������ł�����
        if(hp <= 0)
        {
            //�v���C���[�̓|���������X�^�[�̐��𑝂₷
            player.kill++;
            //HP����R�C���̐����v�Z
            int amount = (int)(CalcHp() * coinMultiplier);
            //�R�C����ǉ�
            player.AddCoin(amount);
            //���̃����X�^�[���o��
            Setup();
        }
    }

    void Update()
    {
        
    }
}
