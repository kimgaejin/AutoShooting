using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ������ �ʱ�ȭ�� �¸������� �˻��ϴ� ������Ʈ�Դϴ�.
/// </summary>
public class GameManager : MonoBehaviour
{
    #region �ܺο� �����ϴ� ������Ʈ ����
    /// <summary>
    /// ������ ������ �� �ִ� ĳ�����Դϴ�.
    /// </summary>
    /// <remarks> ���� ���� �� ������ �ʱ�ȭ�� �ҷ�����, ���� �ܺ� ���� ���� ���� ����� �ְ������ ������ �����մϴ�. </remarks>
    public Player player;
    #endregion

    #region �ϳ��� �����ϴ� ���� Ŭ����
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
