using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    private Touch touch;

    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag") {
            SetAngle(this.defaultAngle);            
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag") {
            SetAngle(this.defaultAngle);
        }
        */
        //lesson5の追加課題「キーボード操作」↓
        /*
        if (Input.GetKeyDown(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyDown(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.A) && tag == "LeftFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.D) && tag == "RightFripperTag")
        {
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            SetAngle(this.flickAngle);
        }
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            SetAngle(this.defaultAngle);
        }
        */
        //lesson6の追加課題「タッチ操作」
        if (Input.touchCount == 0)
        {
            SetAngle(this.defaultAngle);
        }
        else if (Input.touchCount == 1)
        {
            this.touch = Input.GetTouch(0);
            if (tag == "LeftFripperTag" && touch.position.x < Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
            else if (tag == "RightFripperTag" && touch.position.x >= Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
        }
        else if (Input.touchCount == 2)
        {
            this.touch = Input.GetTouch(0);
            if (tag == "LeftFripperTag" && touch.position.x < Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
            else if (tag == "RightFripperTag" && touch.position.x >= Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
            this.touch = Input.GetTouch(1);
            if (tag == "LeftFripperTag" && touch.position.x < Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
            else if (tag == "RightFripperTag" && touch.position.x >= Screen.width / 2)
            {
                SetAngle(this.flickAngle);
            }
        }

        if (touch.phase == TouchPhase.Ended)
        {
            SetAngle(this.defaultAngle);
        }
    }

    public void SetAngle(float angle)
    {
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }
}