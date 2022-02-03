using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    GameObject Player; //参照元OBJそのものが入る変数

    PL script; //参照元Scriptが入る変数

    private int out_P;

    private Text targetText;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Sphere"); //ActionButtonをオブジェクトの名前から取得して変数に格納する
        script = Player.GetComponent<PL>(); //OBJの中にあるScriptを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        //アクションボタン自身とそれぞれのtext連携用
        out_P = script.out_p;
        this.targetText = this.GetComponent<Text>();
        this.targetText.text = "OUT:"+(out_P/3).ToString();
    }
}
