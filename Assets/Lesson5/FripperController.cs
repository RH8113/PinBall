using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour
{

    private HingeJoint myHingeJoint; 
    private float defaultAngle = 20;
    private float flickAngle = -20;

    private const int FRIPPER_STATE_DOWN = 0;
    private const int FRIPPER_STATE_UP = 1;
    int fripperState = FRIPPER_STATE_DOWN;

    int? fripperControlTouchId = null;
    Touch fripperControlTouch;
    float fripperControlTouchMaxX = 0.0f;
    float fripperControlTouchMinX = 0.0f;

    void Start()
    {
        
            if (tag == "LeftFripperTag")
            {
                fripperControlTouchMaxX = Screen.width / 2.0f;
                fripperControlTouchMinX = 0.0f;
            }
            else if (tag == "RightFripperTag")
            {
                fripperControlTouchMaxX = (float)Screen.width;
                fripperControlTouchMinX = Screen.width / 2.0f;
            }
        

        
        fripperControlTouch = new Touch();
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

   
    private void MoveFripperOnIphone()
    {
       
        if (fripperState == FRIPPER_STATE_DOWN)
        {
            Debug.Log("Fripper(tag:" + tag + ") is already down.");
        }

        else
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Debug.Log("touches[" + i + "]");
                Debug.Log("  position.x : " + Input.touches[i].position.x);
                Debug.Log("  phase : " + Input.touches[i].phase);

                if (Input.touches[i].fingerId == fripperControlTouchId)
                {
                    fripperControlTouch.phase = Input.touches[i].phase;

                    if (fripperControlTouch.phase == TouchPhase.Ended)
                    {
                       
                        DownFripper();
                        
                        fripperControlTouchId = null;
                       
                        fripperState = FRIPPER_STATE_DOWN;
                        Debug.Log("Fripper(tag:" + tag + ") is down.");
                        break;
                    }

                }
            }
        }

        if (fripperState == FRIPPER_STATE_UP)
        {
            Debug.Log("Fripper(tag:" + tag + ") is already up.");
        }
        else
        {
           
            for (int i = 0; i < Input.touchCount; i++)
            {
                Debug.Log("touches[" + i + "]");
                Debug.Log("  position.x : " + Input.touches[i].position.x);
                Debug.Log("  phase : " + Input.touches[i].phase);

                
                if (Input.touches[i].phase == TouchPhase.Began &&
                    (Input.touches[i].position.x >= fripperControlTouchMinX) &&
                    (Input.touches[i].position.x < fripperControlTouchMaxX))
                {
                   
                    UpFripper();
                  
                    fripperControlTouchId = Input.touches[i].fingerId;
                    fripperState = FRIPPER_STATE_UP;
                    Debug.Log("Fripper(tag:" + tag + ") is up.");
                    break;
                }
            }
        }
    }

    
    private void UpFripper()
    {
        SetAngle(this.flickAngle);
    }

    private void DownFripper()
    {
        SetAngle(this.defaultAngle);
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}