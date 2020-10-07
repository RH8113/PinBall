using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{
   
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;
    private float ScreenWidth;


    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
        ScreenWidth = Screen.width;
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
       
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }

        
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }

        
        for(int i = 0; i < Input.touchCount; i++)
        {
            if((Input.GetTouch(i).position.x < Screen.width / 2) && (tag == "LeftFripperTag") && (Input.touches[i].phase == TouchPhase.Began))
            {
                SetAngle(this.flickAngle);
            }

            if ((Input.GetTouch(i).position.x > Screen.width / 2) && (tag == "RightFripperTag") && (Input.touches[i].phase == TouchPhase.Began))
            {
                SetAngle(this.flickAngle);
            }


            if ((Input.GetTouch(i).position.x < Screen.width / 2) && (tag == "LeftFripperTag") && (Input.touches[i].phase == TouchPhase.Ended))
            {
               SetAngle(this.defaultAngle);
            }


            if ((Input.GetTouch(i).position.x > Screen.width / 2) && (tag == "RightFripperTag") && (Input.touches[i].phase == TouchPhase.Ended))
            {
                SetAngle(this.defaultAngle);
            }


            if ((Input.GetTouch(i).position.x > Screen.width / 2) && (tag == "LeftFripperTag") && (Input.touches[i].phase == TouchPhase.Ended))
            {
                SetAngle(this.defaultAngle);
            }


            if ((Input.GetTouch(i).position.x < Screen.width / 2) && (tag == "RightFripperTag") && (Input.touches[i].phase == TouchPhase.Ended))
            {
                SetAngle(this.defaultAngle);
            }
        }

      
    }
   

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}
