using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleView battleView;
    public BattleMessageView messageView;
    public BattleButtonsView battleButtonsView;

    // 回合数
    private int rounds = 0;
    // 玩家是否行动结束
    private bool isPlayerMoveOver = false;
    // 敌人是否行动结束
    private bool isEnermyMoveOver = false;


    // 回合开始
    private IEnumerator StartOfRound() {
        rounds += 1;
        yield return null;
    }

    /// <summary>
    /// 战斗开始前的准备,执行显示信息等操作
    /// </summary>
    private IEnumerator BattlePrepare() {
        // 隐藏battleView
        battleView.OnHidden();

        yield return new WaitForSeconds(0.7f);

        if (messageView.BindingContext == null) {
            messageView.BindingContext = new BattleMessageViewModel();
        }

        // 显示messageView
        messageView.Reveal(immediate: true);

        messageView.BindingContext.Message.Value = "你感觉你可能要吃点苦头了.....";

    }

    /// <summary>
    /// 等待玩家回合结束
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForPlayerMoveOver() {
        while (!isPlayerMoveOver) {
            yield return new WaitForFixedUpdate();
        }
    }

    /// <summary>
    /// 玩家回合开始
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayerTurned() {
        if (battleButtonsView.BindingContext == null) battleButtonsView.BindingContext = new BattleButtonsViewModel();
        battleButtonsView.BindingContext.isActive.Value = true;
        yield return WaitForPlayerMoveOver();
    }


    private IEnumerator WaitForEnemyMoveOver() {
        while (!isEnermyMoveOver) {
            yield return new WaitForFixedUpdate();
        }
    }
    /// <summary>
    /// 敌人回合预执行，执行一些在敌人回合开始之前要进行的必要操作，比如说话之类的
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemyTurnedPrepare() {
        yield return null;
    }

    IEnumerator Main() {

        // 回合开始
        yield return StartOfRound();

        // 回合前准备
        yield return BattlePrepare();

        // 玩家回合
        yield return PlayerTurned();


    }

    private void Start() {
        StartCoroutine(Main());
    }
}
