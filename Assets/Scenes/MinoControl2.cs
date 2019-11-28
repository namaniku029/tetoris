using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoControl2 : MonoBehaviour
{
    readonly Block[] minos = new Block[]{
        new Block(
             new Vector2[,] { 
                {new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0),new Vector2(2,0) },
                {new Vector2(0,-1),new Vector2(0,0),new Vector2(0,1),new Vector2(0,2) }
              }
        ),
        new Block(
             new Vector2[,] {
                {new Vector2(0,1),new Vector2(0,0),new Vector2(0,-1),new Vector2(-1,-1)},
                {new Vector2(1,0),new Vector2(0,0),new Vector2(-1,0),new Vector2(-1,1) },
                {new Vector2(0,-1),new Vector2(0,0),new Vector2(0,1),new Vector2(1,1) },
                {new Vector2(-1,0),new Vector2(0,0),new Vector2(1,0),new Vector2(1,-1) }
              }
        ),


    };
    //ステージの配列化
    float[,] stage = new float[12, 25];
 

    // Start is called before the first frame update
    void Start()
    {
        //ステージの壁部分に１(壁)を代入
        for (int i = 0;i<12;i++)
            for (int j =0;j<25;j++ )
                if (i == 0 || i==11 ||j ==0)
                    stage[i, j] = 1;
        

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0;i<4000;i++) {
            if (i /2 == 0 ) {
                minos[0].MinoStartPos();
            }
        }
    }
}

class Block : MinoControl2
{
    GameObject mino;
    public Vector2[,] Mino;
    public Block(Vector2[,] Mino)
    {
        this.Mino = Mino;
    }

    public void MinoStartPos()
    {
        Vector2 StartPos = new Vector2(6.5f, 22.5f);
        transform.Translate(StartPos.x,StartPos.y,0,Space.World);
    }
}
