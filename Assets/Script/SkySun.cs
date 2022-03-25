using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySun : MonoBehaviour
{
    private float DurationTime = 7.2f;                    //SkySun在目标点存在的时间
    private float DownSpeed = 3.8f;                       //下落速度
    private float MoveSpeed = 12.8f;                      //移动速度
    private float MinHeight = -3.4f, MaxHeight = 1.7f;    //下落高度范围
    private float TargetY;                                //下落高度
    private bool IsArrived = false;                       //SkySun是否到达目标点
    private bool IsObtaining = false;                     //SkySun是否正在被获取
    private void Start()
    {
        //初始化目标高度
        TargetY = Random.Range(MinHeight, MaxHeight);
    }

    private void FixedUpdate()
    {
        SunMove();
        if (IsArrived)
        {
            Invoke(nameof(Vanish), DurationTime);
        }
    }

    void VanishWarn()
    {

    }

    void Vanish()
    {
        Destroy(gameObject);
    }

    void SunMove()
    {
        if (IsObtaining)
        {
            if (transform.localPosition != Vector3.zero)
            {
                Vector3 vector3 = Vector3.MoveTowards(transform.localPosition, Vector3.zero, MoveSpeed * Time.fixedDeltaTime);
                transform.localPosition = vector3;
            }
            else
            {
                Vanish();
            }
        }
        else
        {
            if (transform.position.y > TargetY)
            {
                transform.Translate(0, -DownSpeed * Time.fixedDeltaTime, 0);
            }
            else
            {
                IsArrived = true;
                return;
            }
        }
    }

    private void OnMouseEnter()
    {
        ObtainSun();
    }

    void ObtainSun()
    {
        IsObtaining = true;
        SunManagement.TotalSun += 50;
        Debug.Log(SunManagement.TotalSun);
    }
}