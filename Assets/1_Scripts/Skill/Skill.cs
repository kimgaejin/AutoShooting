using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 사용할 수 있는 스킬의 추상 클래스입니다.
/// 플레이어가 여러 개의 스킬을 사용할 수 있다고 생각했습니다. 
/// <example>여러개의 화살을 날리기 + 화살을 축구공으로 바꾸기 + 간헐적으로 2초간 무적 </example>
/// </summary>
public abstract class Skill : MonoBehaviour
{
    protected int idx;  // 스킬의 중복을 막기위한 인덱스
    protected List<int> requestSkill;   // 스킬을 해금하기 위해 먼저 필요한 스킬 -미구현
    protected List<int> sufficientSkill;    // 스킬을 해금하면 해금할 수 있는 스킬 -미구현

    /// <summary>
    /// 스킬을 얻었을 때와 플레이어가 레벨업 할 때 호출합니다.
    /// 스킬마다 필요로하는 정보가 다르기 때문에 player의 능력치에서 필요한 부분을 본인이 알아서 기억하게 작성했습니다.
    /// 공격력 증가, 투사체 변경 등 1회성으로 수정해야하는 부분들도 Init에서 추가합니다.
    /// </summary>
    /// <param name="player"></param>
    public virtual void Init(Player player)
    {
        requestSkill = new List<int>();
        sufficientSkill = new List<int>();
    }

    /// <summary>
    /// 프레임마다 호출되며 n초에 1회 화살을 쏘는 등 작업을 합니다.
    /// </summary>
    /// <param name="isPlayerMoving"></param>
    /// <param name="target"></param>
    public virtual void ActRepeatly(bool isPlayerMoving, GameObject target)
    {

    }

    public int GetIdx()
    {
        return idx;
    }
}
