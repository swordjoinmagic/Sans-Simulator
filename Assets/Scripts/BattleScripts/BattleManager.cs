using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleView battleView;
    public BattleMessageView messageView;

    // 回合数
    private int rounds = 0;

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
        messageView.Reveal(immediate:true);

        messageView.BindingContext.Message.Value = "你感觉你可能要吃点苦头了.....";

    }

    /// <summary>
    /// 玩家回合开始
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayerTurned() {
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
