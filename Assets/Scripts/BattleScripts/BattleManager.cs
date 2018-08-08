using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// 管理整个UT的战斗流程
/// </summary>
public class BattleManager : MonoBehaviour {

    public BattleView battleView;
    public BattleMessageView messageView;
    public BattleButtonsView battleButtonsView;
    public EnemyMessageView enemyMessageView;
    public AudioManagement audioManagement;
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

    // 关卡预制体
    private GameObject Chapter1;
    private GameObject Chapter2;

    /// <summary>
    /// 初始化工作
    /// </summary>
    private void Awake() {

        // 读取关卡预制体
        Chapter1 = Resources.Load("Prefabs/Chapter1") as GameObject;
        Chapter2 = Resources.Load("Prefabs/Chapter1") as GameObject;

        print("脚本初始化");
        Sans.HP.OnValueChange += OnSansInjured;
    }

    // 回合开始
    private IEnumerator StartOfRound() {
        print("回合开始");
        rounds += 1;
        yield return null;
    }

    /// <summary>
    /// 战斗开始前的准备,执行显示信息等操作
    /// </summary>
    private IEnumerator BattlePrepare() {
        if (messageView.BindingContext == null) {
            messageView.BindingContext = new BattleMessageViewModel();
        }

        // 将battleView形变
        battleView.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(746.9f, 182.6f), 0.5f);

        yield return new WaitForSeconds(0.7f);

        // 显示messageView
        messageView.Reveal(immediate: true);

        switch (rounds) {
            case 1:
                messageView.BindingContext.Message.Value = "你感觉你可能要吃点苦头了.....";
                break;
            case 2:
                messageView.BindingContext.Message.Value = "罪恶爬上了你的脊背....";
                break;
            default:
                messageView.BindingContext.Message.Value = "现在不是读这段文字的时候";
                break;
        }
        

    }

    /// <summary>
    /// 等待玩家回合结束
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForPlayerMoveOver() {
        while (!isPlayerMoveOver) {
            yield return null;
        }
        // 当玩家行动结束时,设置行动框的actived为false
        battleButtonsView.BindingContext.isActive.Value = false;
    }

    /// <summary>
    /// 玩家回合开始
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayerTurned() {
        if (battleButtonsView.BindingContext == null) battleButtonsView.BindingContext = new BattleButtonsViewModel();

        battleButtonsView.BindingContext.isActive.Value = true;

        // 等待玩家行动结束
        yield return WaitForPlayerMoveOver();

        // 清空提示信息
        messageView.BindingContext.Message.Value = "";
        // 隐藏提示信息窗口
        messageView.Hide();
    }

    /// <summary>
    /// 敌人回合预执行，执行一些在敌人回合开始之前要进行的必要操作，比如说话之类的
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemyTurnedPrepare() {
        // 如果本回合Sans受到伤害,那么他就开始讲骚话
        if (isSansInjrued) {

            yield return new WaitForSeconds(1f);

            if (enemyMessageView.BindingContext == null) enemyMessageView.BindingContext = new EnemyMessageViewModel();

            enemyMessageView.Reveal();

            yield return new WaitForSeconds(0.2f);

            // 说骚话
            switch (Sans.HP.Value) {
                case 19:
                    sansAnimator.SetBool("IsLaugh",true);
                    enemyMessageView.BindingContext.message.Value = "怎么? 你觉得我会待在这里乖乖承受?";
                    yield return WaitInputUtil.WaitForPlayerInput(KeyCode.Z);
                    sansAnimator.SetBool("IsLaugh", false);
                    break;
                default:
                    enemyMessageView.BindingContext.message.Value = "老实说,这让我提不起劲...";
                    yield return WaitInputUtil.WaitForPlayerInput(KeyCode.Z);
                    break;
            }

            // 等待说话结束
            enemyMessageView.BindingContext.message.Value = "";     // 清空
            //yield return new WaitForSeconds(1f);
        }
        yield return null;
    }

    /// <summary>
    /// 敌人回合开始
    /// </summary>
    /// <returns></returns>
    private IEnumerator EnemyTurned() {

        // 在这里根据sans的血量决定出招,
        // 每一次出招弹幕躲避框的大小都会改变,

        // 隐藏对于主角的提示窗口
        messageView.Hide();
        // 隐藏敌人对话窗口
        enemyMessageView.Hide();
        // 将弹幕躲避窗口还原
        battleView.gameObject.GetComponent<RectTransform>().DOSizeDelta(new Vector2(596.45f, 366.4f),0.5f);
        yield return new WaitForSeconds(0.5f);

        // 生成关卡
        switch (rounds) {
            case 2:
                GameObject chapter = Instantiate(Chapter2);



                yield return chapter.GetComponent<Chapter2>().WaitChapterOver();

                break;
            default:
                chapter = Instantiate(Chapter1);

                chapter.GetComponent<BoneMoveChapter>().boneSpeed = 0.18f;

                yield return chapter.GetComponent<BoneMoveChapter>().WaitChapterOver();
                break;
        }

        

    }
    IEnumerator _Main() {
        //yield return null;
        while (!Sans.IsDied()) {

            print("Main执行了1次");

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

            // 敌人回合开始
            yield return EnemyTurned();
        }
    }

    private void Start() {
        print("开始协程调用");
        StartCoroutine(_Main());
    }

    private void OnSansInjured(int oldValue,int newValue) {
        sansDodgeAnimation.Play();
        charaAnimator.SetTrigger("IsAttack");
        
        audioManagement.Audios["playerfight"].Play();
        isPlayerMoveOver = true;
        isSansInjrued = true;
    }
}
