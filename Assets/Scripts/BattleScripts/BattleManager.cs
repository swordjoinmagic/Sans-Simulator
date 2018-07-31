using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {

    public BattleView battleView;
    public BattleMessageView messageView;
    public BattleButtonsView battleButtonsView;
    public EnemyMessageView enemyMessageView;

    // Boss的数据模型
    private MonsterViewModel Sans = new MonsterViewModel(hp:20,attack:1);
    // Boss的动画模型
    public Animator sansAnimator;
    // chara攻击的动画模型
    public Animator charaAnimator;
    // Boss闪躲的动画
    public Animation sansDodgeAnimation;

    // 回合数
    private int rounds = 0;
    // 玩家是否行动结束
    private bool isPlayerMoveOver = false;
    // 敌人是否行动结束
    private bool isEnermyMoveOver = false;
    // sans本回合是否受到攻击
    private bool isSansInjrued = false;

    /// <summary>
    /// 初始化工作
    /// </summary>
    private void Awake() {
        Sans.HP.OnValueChange += OnSansInjured;
    }

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
            yield return null;
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
            yield return null;
        }
    }
    /// <summary>
    /// 敌人回合预执行，执行一些在敌人回合开始之前要进行的必要操作，比如说话之类的
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemyTurnedPrepare() {
        // 如果本回合Sans受到伤害,那么他就开始讲骚话
        if (isSansInjrued) {

            yield return new WaitForSeconds(2f);

            if (enemyMessageView.BindingContext == null) enemyMessageView.BindingContext = new EnemyMessageViewModel();
            enemyMessageView.Reveal();

            yield return new WaitForSeconds(0.4f);

            // 说骚话
            enemyMessageView.BindingContext.message.Value = "怎么? 你觉得我会待在这里乖乖承受?";

            
        }
        yield return null;
    }

    IEnumerator Main() {
        while (true) {
            // 重置属性
            isSansInjrued = false;
            isPlayerMoveOver = false;
            isEnermyMoveOver = false;
            // 回合开始
            yield return StartOfRound();

            // 回合前准备
            yield return BattlePrepare();

            // 玩家回合
            yield return PlayerTurned();

            // 敌人回合预执行
            yield return EnemyTurnedPrepare();
        }
    }

    private void Start() {
        StartCoroutine(Main());
    }

    private void OnSansInjured(int oldValue,int newValue) {
        sansDodgeAnimation.Play();
        charaAnimator.SetTrigger("IsAttack");
        isPlayerMoveOver = true;
        isSansInjrued = true;
    }
}
