using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoControl : MonoBehaviour
{
    GameObject[] minos;
    float[] minoX = new float[260];
    float[] minoY = new float[260];
    float span = 1.0f;
    float delta = 0;


    // Start is called before the first frame update
    void Start()
    {

        this.minos = GameObject.FindGameObjectsWithTag("mino");
        int i = 0;
        foreach (GameObject mino in this.minos)
        {
            //丸め誤差解消
            this.minoX[i] = Mathf.RoundToInt(mino.transform.position.x * 10.0f) / 10.0f;
            this.minoY[i] = Mathf.RoundToInt(mino.transform.position.y * 10.0f) / 10.0f;
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int a = 0;
        //ミノを自然落下させる
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            transform.Translate(0, -1, 0, Space.World);

        }
        //ミノの移動操作
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.Translate(-1f, 0f, 0f, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.Translate(1f, 0f, 0f, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.transform.Translate(0f, -1f, 0f, Space.World);
        }
        //回転
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (transform.position.x <=2.5 || transform.position.x >=-2.5)
            {
                transform.Rotate(0, 0, 90.0f);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.X))
            if (transform.position.x <= 2.5 || transform.position.x >= -2.5)
            {
                transform.Rotate(0, 0, -90.0f);
            }

        a = 0;
        //親オブジェクトの下にミノがあった場合そこで止まる
        /*foreach (GameObject mino in this.minos) {
            if (transform.position.x == this.minoX[a] && transform.position.y == this.minoY[a] + 1.0f){
                gameObject.transform.DetachChildren();    //親子関係の解除
                Destroy(gameObject);     //minoセットオブジェクト（親）を削除
                return;
            }
            
            foreach (Transform child in transform){
                if (child.gameObject.transform.position.x == this.minoX[a] && child.gameObject.transform.position.x == this.minoY[a]) {
                    gameObject.transform.DetachChildren();    //親子関係の解除
                    Destroy(gameObject);     //minoセットオブジェクト（親）を削除
                    return;
                }
            }

            a++;
        }*/
        //地面についたとき親解除
        if (transform.position.y == 0.5f)
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }


    }
}
    

