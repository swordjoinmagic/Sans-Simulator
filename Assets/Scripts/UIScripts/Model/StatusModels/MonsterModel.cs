using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using uMVVM;

/// <summary>
/// 基本怪物的数据模型
/// </summary>
public class MonsterModel {
    // 血量
    int hp;
    // 攻击力
    int attack;
    Animator sansAniamtor;

    public enum MonsterFace {
        IDLE,           // 默认状态
        NoEyes,         // 无眼睛状态
        Laugh,          // 嘲笑
        AngryAndSpreadHand, //愤怒的表情,并且摊手
        CloseEyes,      // 闭眼
        LittleSad,      // 略悲伤
        LowEyes,        // 嘲讽
        SpreadHand,     // 摊手,表示无奈
        Tired,          // 疲惫
        TriedAndSmeil   // 疲惫且微笑
    }

    public int Hp {
        get {
            return hp;
        }

        set {
            hp = value;
        }
    }

    public int Attack {
        get {
            return attack;
        }

        set {
            attack = value;
        }
    }

    public Animator SansAniamtor {
        get {
            return sansAniamtor;
        }

        set {
            sansAniamtor = value;
        }
    }

    // 说话
    public void Say(string message,MonsterFace monsterFace) {
        // Sans做表情
        switch (monsterFace) {
            case MonsterFace.Laugh:
                sansAniamtor.SetBool("IsLaugh",true);
                break;
        }

        // Sans说话
        MessageAggregator<string>.Instance.Publish("EnemyMessageChanged",this,new MessageArgs<string>(message));
        
    }
}
