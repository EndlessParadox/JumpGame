using UnityEngine;
using UnityEngine.UI;

public class Cube1 : MonoBehaviour
{
    bool OnGround;   //是否在地面上
    float jumpPressure = 0f;  //蓄力值
    float MinjumpPressure = 2f;  //蓄力最小值
    public float MaxjumpPressure = 10f;  // 蓄力最大值
    Rigidbody rbody;

    public Text countText;
    public Text deathText;

    float coordinate;//坐标

    public GameObject objFloor;
    public GameObject objFloorRoot;
    private int count;

   
    void Start()
    {
        OnGround = true;  //初始设置在地面上
        rbody = GetComponent<Rigidbody>();  //获取组件

        coordinate = 4;//初始坐标为4，（第二个方块的位置）

         count = 0;
        countText.text = "Count:" + count;

        deathText.text = "  ";
    }

    void Update()
    {

        if (OnGround)  //判断是否在地面上
        {
            if (Input.GetButton("Jump"))  //hold  按下不放空格键
            {
                if (jumpPressure < MaxjumpPressure)
                {  //如果当前蓄力值小于最大值
                    jumpPressure = jumpPressure + Time.deltaTime * 5f; //则每帧递增当前蓄力值

                }
                else
                {  //达到最大值时，当前蓄力值就等于最大蓄力值
                    jumpPressure = MaxjumpPressure;
                }
            }

            else  //not hold  空格键松开时
            {
                if (jumpPressure > 0f)
                {   //轻轻按下就松开 当前蓄力值=最小蓄力值赋值
                    //按住不松但未大于最大蓄力值 当前蓄力值=递增蓄力值
                    jumpPressure = jumpPressure + MinjumpPressure;
                    //给一个向上速度
                    rbody.velocity = new Vector3(0.5f + jumpPressure, jumpPressure, 0f);

                    jumpPressure = 0f; //升空后 蓄力值重设
                    OnGround = false;

                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //检测是否碰撞到地面
        if (other.gameObject.tag == "Ground")
        {
            if (!OnGround)
            {
                OnGround = true;

                count++;
                countText.text = "Count:" + count;

                GameObject objNew = Instantiate(objFloor) as GameObject;
                objNew.transform.position = new Vector3(coordinate+Random.Range(3,5), 0, 0); 
                //Random.Range随机数生成
                objNew.transform.parent = objFloorRoot.transform ;
                coordinate = coordinate + Random.Range(3,5);
            }
        }
        else
        {
            deathText.text = "You are died!";
        }
    }
}

