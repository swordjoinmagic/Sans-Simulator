using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 用于骨头移动的关卡脚本
/// </summary>
class BoneMoveChapter : MonoBehaviour,IChapter {

    public Transform Left;
    public Transform Right;

    // 生成的骨头的状态
    public enum BoneMoveChapterStatus {
        ShortBone,      // 一短一长的骨头,缺口在下方
        MiddleBone,     // 两颗中等长度的骨头,缺口在中央
        ShortBone2      // 一短一长的骨头,缺口下下方偏上
    }

    private GameObject ShortBone;
    private GameObject MiddleBone;
    private GameObject ShortBone2;

    public BoneMoveChapterStatus[] boneMoveChapterStatuses = { BoneMoveChapterStatus.ShortBone,BoneMoveChapterStatus.MiddleBone,BoneMoveChapterStatus.ShortBone2 };

    // 用于判断关卡是否结束
    private bool isOver = false;

    // 本关生成的骨头数量
    public int boneCount = 0;

    // 本关生成的骨头的移动速度
    public float boneSpeed = 0.1f;

    // 每根骨头相距距离
    public float shortBoneDistance = 4;
    public float middleBoneDistance = 7;

    // 左边骨头集合
    List<Transform> leftBone = new List<Transform>();
    // 右边骨头集合
    List<Transform> rightBone = new List<Transform>();

    private void Awake() {
        // 读取预制体
        ShortBone = Resources.Load("Prefabs/shortBone1") as GameObject;
        MiddleBone = Resources.Load("Prefabs/middleBone") as GameObject;
        ShortBone2 = Resources.Load("Prefabs/shortBone2") as GameObject;

        // 随机生成骨头
        for (int i = 0; i < boneCount; i++) {

            // 当前骨头的x坐标
            float xPosition = (i + 1) * shortBoneDistance;

            //BoneMoveChapterStatus status = boneMoveChapterStatuses[Random.Range(0, boneMoveChapterStatuses.Length)];
            BoneMoveChapterStatus status = BoneMoveChapterStatus.ShortBone;
            GameObject boneLeft = null;
            GameObject boneRight = null;
            // 根据类型生成骨头
            switch (status) {
                case BoneMoveChapterStatus.ShortBone:
                    boneLeft = Instantiate(ShortBone, Left);
                    boneRight = Instantiate(ShortBone, Right);

                    // 设置Transform
                    float tempX = 0;
                    if (i != 0)
                        tempX = leftBone[i - 1].position.x;

                    boneLeft.transform.position = new Vector3(tempX-shortBoneDistance, boneLeft.transform.position.y, boneLeft.transform.position.z);

                    tempX = 0;
                    if (i != 0)
                        tempX = rightBone[i - 1].position.x;

                    boneRight.transform.position = new Vector3(tempX + shortBoneDistance, boneRight.transform.position.y, boneLeft.transform.position.z);
                    

                    break;
                case BoneMoveChapterStatus.MiddleBone:
                    boneLeft = Instantiate(MiddleBone, Left);
                    boneRight = Instantiate(MiddleBone, Right);

                    // 设置Transform
                    if (i != 0) {
                        // 设置左边的
                        tempX = leftBone[i - 1].position.x;
                        boneLeft.transform.position = new Vector3(tempX - middleBoneDistance, boneLeft.transform.position.y, boneLeft.transform.position.z);
                        // 设置右边的
                        tempX = rightBone[i - 1].position.x;
                        boneRight.transform.position = new Vector3(tempX + middleBoneDistance, boneRight.transform.position.y, boneLeft.transform.position.z);
                    } else {
                        boneRight.transform.position = new Vector3(middleBoneDistance, boneRight.transform.position.y, boneLeft.transform.position.z);
                        boneLeft.transform.position = new Vector3(-middleBoneDistance, boneLeft.transform.position.y, boneLeft.transform.position.z);
                    }

                    break;
                case BoneMoveChapterStatus.ShortBone2:
                    boneLeft = Instantiate(ShortBone2, Left);
                    boneRight = Instantiate(ShortBone2, Right);

                    // 设置Transform
                    tempX = 0;
                    if (i != 0)
                        tempX = leftBone[i - 1].position.x;

                    boneLeft.transform.position = new Vector3(tempX - shortBoneDistance, boneLeft.transform.position.y,boneLeft.transform.position.z);

                    tempX = 0;
                    if (i != 0)
                        tempX = rightBone[i - 1].position.x;

                    boneRight.transform.position = new Vector3(tempX + shortBoneDistance, boneRight.transform.position.y, boneLeft.transform.position.z);

                    break;
            }


            leftBone.Add(boneLeft.transform);
            rightBone.Add(boneRight.transform);
        }
    }

    public IEnumerator Main() {
        // 最终要移动的距离
        float finalDistance = rightBone.Last().position.x + middleBoneDistance;
        while (Left.transform.position.x < finalDistance) {
            Left.transform.Translate(new Vector2(boneSpeed,0));
            Right.transform.Translate(new Vector2(-boneSpeed,0));
            yield return new WaitForSeconds(0.02f);
        }
        isOver = true;
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

