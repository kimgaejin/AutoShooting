using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  게임의 초기화와 승리조건을 검사하는 컴포넌트입니다.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region 외부에 존재하는 오브젝트 참조
    /// <summary>
    /// 유저가 제어할 수 있는 캐릭터입니다.
    /// </summary>
    /// <remarks> 게임 시작 시 생성과 초기화로 불러오기, 게임 외부 스탯 버프 등의 기능을 넣고싶으나 볼륨상 생략합니다. </remarks>
    public Player player;
    #endregion

    #region 하나만 존재하는 관리 클래스
    private KeyboardInput keyboardInput = new KeyboardInput();

    public ProjectileManager projectileManager;
    public MonsterManager monsterManager;
    #endregion

    private void Start()
    {
        projectileManager.Init();
        monsterManager.Init();

        player.Init(50, 10, 2);
    }

    private void FixedUpdate()
    {
        Vector2 moveVec = keyboardInput.GetKeyboardArrow();
        bool isPlayerMoving = player.Move(moveVec);
        player.CallSkill(isPlayerMoving);

        projectileManager.CallMove();

    }

    private void Update()
    {

    }

}
