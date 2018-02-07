using System.Collections.Generic;
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
    public Text overText;

    float coordinate;//坐标

    public GameObject objFloor;
    public GameObject objFloorRoot;
    private int count;

    protected int[] lstOffsetIdx = new int[] { 0, 2, 3 };
    private int offsetIdx = 0; //偏移标识 0 ↑ 2 ← 3 → 未免交叉不允许走回头路

    void Start()
    {
        OnGround = true;  //初始设置在地面上
        rbody = GetComponent<Rigidbody>();  //获取组件

        coordinate = 4;//初始坐标为4，（第二个方块的位置）

         count = 0;
        countText.text = "Count:" + count;

        overText.text = "  ";
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
                    //offsetIdx为0时 给x轴正向速度 /offsetIdx为2时 给z轴正向速度 /offsetIdx为3时 给z轴负向速度 
                    rbody.velocity = new Vector3((0.5f + jumpPressure) * (offsetIdx == 0 ? 1 : 0), jumpPressure, (0.5f + jumpPressure) * (offsetIdx / 2 == 1 ? (offsetIdx % 2 == 0 ? 1 :  -1) : 0));

                    jumpPressure = 0f; //升空后 蓄力值重设
                    OnGround = false;

                }
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //检测是否碰撞到地面
        if (other.gameObject.tag == "Ground" && other.contacts[0].normal  == Vector3.up) //只有碰撞点的法线方向为上时才算碰撞到
        {
            if (!OnGround)
            {
                OnGround = true;

                count++;
                countText.text = "Count:" + count;

                GameObject objNew = Instantiate(objFloor) as GameObject;
                //objNew.transform.position = new Vector3(coordinate+Random.Range(3,5), 0, 0); 
                
                //将三个方向筛选后放入list中进行随机选择
                List<int> lstRandomIdx = new List<int>();
                for(int i = 0; i < lstOffsetIdx.Length; i ++)
                {
                    if(offsetIdx != 0)
                    {
                        if(lstOffsetIdx[i] == offsetIdx || lstOffsetIdx[i] == 0) //如果上一步是←或者→ 那么不允许走回头路
                        {
                            lstRandomIdx.Add(lstOffsetIdx[i]);
                        }
                    }
                    else
                    {
                        lstRandomIdx.Add(lstOffsetIdx[i]);//如果上一步是↑ 那么三个方向都可以
                    }
                }

                int nRandom = Random.Range(0, lstRandomIdx.Count); //随机出新的方向的list下标
                offsetIdx = lstRandomIdx[nRandom];

                //偏移标识 0 ↑ 1 ← 2 → 根据随机出来的标识在不同方向生成新的物体
                float fOffset = Random.Range(1.5f, 3f);
                float fOffsetX = offsetIdx / 2 == 0 ? (offsetIdx % 2 == 0 ? fOffset : 0) : 0;//只有offset为0的时候 作x轴方向的偏移
                float fOffsetZ = offsetIdx / 2 == 1 ? (offsetIdx % 2 == 0 ? fOffset : fOffset * -1) : 0;//offset为2时z轴正向偏移 为3时z轴负向偏移
                objNew.transform.position = other.transform.position + new Vector3(fOffsetX, 0, fOffsetZ);//直接在这个台子坐标的基础上作偏移
                //Random.Range随机数生成
                //objNew.transform.parent = objFloorRoot.transform ;
                //coordinate = coordinate + Random.Range(3,5);
            }
        }
        else
        {
            overText.text = "Game over!";
        }
    }
}

