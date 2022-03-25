using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkySun : MonoBehaviour
{
    private float DurationTime = 7.2f;                    //SkySun��Ŀ�����ڵ�ʱ��
    private float DownSpeed = 3.8f;                       //�����ٶ�
    private float MoveSpeed = 12.8f;                      //�ƶ��ٶ�
    private float MinHeight = -3.4f, MaxHeight = 1.7f;    //����߶ȷ�Χ
    private float TargetY;                                //����߶�
    private bool IsArrived = false;                       //SkySun�Ƿ񵽴�Ŀ���
    private bool IsObtaining = false;                     //SkySun�Ƿ����ڱ���ȡ
    private void Start()
    {
        //��ʼ��Ŀ��߶�
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