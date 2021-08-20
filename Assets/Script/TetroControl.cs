using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetroControl : MonoBehaviour
{

    public float speed = 1f;
    public Rigidbody2D rigid2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rigid2D.AddForce(new Vector2(-speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigid2D.AddForce(new Vector2(speed, 0), ForceMode2D.Force);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //rigid2D.AddForce(new Vector2(0, 1000f), ForceMode2D.Force);
            transform.position += new Vector3(0, -1f, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, -90);
        }
    }
}


//要怎麼改變方塊的中心，特別是O形方塊，應該要不受旋轉指令的影響
//東西撞到地面、方塊或確定跌落之後就不能再動，而且要創造出新的方塊
	//設定一個與地面平行的物件，只要方塊接觸到「該物件 or 其它方塊」，則創造新方塊
        //而且因為倒塌效果的關係，物件可能在倒了之後繼續撞到其它物件。
		//因此要在讓其碰到之後就再也不能透過接觸「該物件 or 其它方塊」來創造新方塊
		//但是接觸到跌落至平台時還是要(1)消失(2)讓玩家扣血
	//設定一個跌落的平台，只要方塊接觸到該平台，就會(1)消失(2)讓玩家扣血
//如果蓋出來的東西高到接觸到頂點，則勝利
	//如果方塊接觸到方塊的同時，也接觸到頂點的話，就會判定勝利

