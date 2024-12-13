using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    private HingeJoint myHingeJoint;
    private float defaultAngle = 20;
    private float flickAngle = -20;

    Touch[] list = new Touch[2];

    // Start is called before the first frame update
    void Start()
    {
        this.myHingeJoint = GetComponent<HingeJoint>();
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {
        //lesson6の追加課題「タッチ操作」
        if (Input.touchCount == 0) {
            SetAngle(this.defaultAngle);
        } else {
            for (int i = 0; i < Input.touchCount; i++) {
                list[i] = Input.GetTouch(i);
                if (tag == "LeftFripperTag" && list[i].position.x < Screen.width / 2) {
                    SetAngle(this.flickAngle);
                } else if (tag == "RightFripperTag" && list[i].position.x >= Screen.width / 2) {
                    SetAngle(this.flickAngle);
                }
            }
        }

        for (int j = 0; j < Input.touchCount; j++) {
            if (tag == "LeftFripperTag" && list[j].position.x < Screen.width / 2 && list[j].phase == TouchPhase.Ended) {
                SetAngle(this.defaultAngle);
            }
            else if (tag == "RightFripperTag" && list[j].position.x >= Screen.width / 2 && list[j].phase == TouchPhase.Ended) {
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