using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    GameObject Player; //�Q�ƌ�OBJ���̂��̂�����ϐ�

    PL script; //�Q�ƌ�Script������ϐ�

    private int out_P;

    private Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Sphere"); //ActionButton���I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        script = Player.GetComponent<PL>(); //OBJ�̒��ɂ���Script���擾���ĕϐ��Ɋi�[����
    }

    // Update is called once per frame
    void Update()
    {
        //�A�N�V�����{�^�����g�Ƃ��ꂼ���text�A�g�p
        out_P = script.out_p;
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "OUT:"+(out_P/3).ToString();
    }
}
