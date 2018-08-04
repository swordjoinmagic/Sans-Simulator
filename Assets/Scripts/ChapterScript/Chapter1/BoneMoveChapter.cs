using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于骨头移动的关卡脚本
/// </summary>
class BoneMoveChapter : MonoBehaviour,IChapter {

    // 生成的骨头的状态
    public enum BoneMoveChapterStatus {
        ShortBone,      // 一短一长的骨头,缺口在下方
        MiddleBone,     // 两颗中等长度的骨头,缺口在中央
        ShortBone2      // 一短一长的骨头,缺口下下方偏上
    }

    public BoneMoveChapterStatus[] boneMoveChapterStatuses = { BoneMoveChapterStatus.ShortBone,BoneMoveChapterStatus.MiddleBone,BoneMoveChapterStatus.ShortBone2 };

    // 用于判断关卡是否结束
    private bool isOver = false;

    // 本关生成的骨头数量
    public int boneCount = 0;

    //// 本关生成的骨头的移动速度
    //public float boneSpeed = 0;

    // 每根骨头相距距离
    public float boneDistance = 4;

    // 左边骨头集合
    List<Transform> leftBone;
    // 右边骨头集合
    List<Transform> rightBone;

    private void Start() {
        // 随机生成骨头
        for (int i=0;i<boneCount;i++) {
            BoneMoveChapterStatus status = boneMoveChapterStatuses[Random.Range(0, boneMoveChapterStatuses.Length)];
            GameObject bone;
            // 根据类型生成骨头
            switch (status) {
                case BoneMoveChapterStatus.ShortBone:
                    
                    break;
                case BoneMoveChapterStatus.MiddleBone:
                    break;
                case BoneMoveChapterStatus.ShortBone2:
                    break;
            }
        }
    }

    public IEnumerator Main() {
        yield return null;    
    }

    /// <summary>
    /// 等待关卡执行完毕
    /// </summary>
    /// <returns></returns>
    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
    }
}

