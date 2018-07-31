using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 基本怪物的数据模型
/// </summary>
public class MonsterModel {
    // 血量
    int hp;
    // 攻击力
    int attack;

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
}
