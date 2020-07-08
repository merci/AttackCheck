using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻击范围检测
/// </summary>
public class AttackCheck
{

    /// <summary>
    /// 圆形范围检测
    /// </summary>
    /// <param name="attacked"></param>
    /// <param name="skillPosition"></param>
    /// <param name="radius"></param>
    /// <returns></returns>
    private bool CircleAttackCheck(Transform scr, Transform des,float radius)
    {
        float distance = Vector3.Distance(scr.position, des.position);
        return distance <= radius;
    }

    /// <summary>
    /// 矩形范围检测
    /// </summary>
    /// <param name="scr"></param>
    /// <param name="des"></param>
    /// <param name="forwardDistance"></param>
    /// <param name="rightDistance"></param>
    /// 判断条件：目标在玩家前面，目标在攻击范围内
    /// <returns></returns>
    private bool RectangleAttackCheck(Transform scr, Transform des,float forwardDistance,float rightDistance)
    {
        //得到原点到目标的向量
        Vector3 vertorA = des.position - scr.position;
        float dotB = Vector3.Dot(scr.right, vertorA);
        float dotA = Vector3.Dot(scr.forward, vertorA);
        //dotA > 0 表示目标在原点前方，反之在后方
        if (dotA > 0 && (dotA <= forwardDistance)
            && (Mathf.Abs(dotB) < rightDistance))
        {
            return true;

        }
        return false;
    }

    /// <summary>
    /// 扇形范围检测
    /// </summary>
    /// <param name="src"></param>
    /// <param name="des"></param>
    /// <param name="radius"></param>
    /// <param name="attackAngle"></param>
    /// 判断条件：距离在攻击范围，玩家与目标的角度在攻击角度内
    /// <returns></returns>
    private bool SectorAttackCheck(Transform src, Transform des, float radius,float attackAngle)
    {
 
        float distance = Vector3.Distance(src.position, des.position);
        float angle = Vector3.Angle(src.forward, (des.position - src.position));
        if(distance <= radius && angle <= attackAngle /2)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /**************************unity自带的物理系统检测***********************/
    private bool SphereColliderCheck(Transform src,float radius,int layermask)
    {
        Collider[] colliders= Physics.OverlapSphere(src.position, radius, layermask);
        if(colliders.Length <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool BoxColliderCheck(Transform src,int layermask)
    {
        Collider[] colliders = Physics.OverlapBox(src.position, src.localScale/2,Quaternion.identity, layermask);
        if (colliders.Length <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private bool CapsuleColliderCheck(Transform src, int layermask,float radius,float height)
    {
        //src.position中心点在底下
        Vector3 pointButtom = src.position + src.up * radius;
        Vector3 pointTop = src.position + src.up * (height - radius);
        Collider[] colliders = Physics.OverlapCapsule(pointButtom, pointTop, radius, layermask);
        if (colliders.Length <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
