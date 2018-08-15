using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter4 : MonoBehaviour, IChapter {

    private bool isOver = false;

    // 玩家位置
    private Transform player;

    // Gaster炮可能出现的所有位置
    public Transform[] gasterTransforms;

    // 本次关卡出现gaster炮的次数
    public int gasterCount = 20;

    // 每个gaster炮出现的最小间隔时间
    public float minIntervalTime = 0.5f;
    // 每个gaster炮出现的最大间隔时间
    public float maxIntervalTime = 1f;

    // Gaster炮预制体
    public GameObject Gaster;

    private void Awake() {
        player = GameObject.FindWithTag("Player").transform;
    }

    public IEnumerator Main() {

        for (int i=0;i<gasterCount;i++) {

            // 随机挑选位置生成Gaster炮
            int index = Random.Range(0,gasterTransforms.Length);

            Transform randomTransfrom = gasterTransforms[index];

            // 生成Gaster炮
            GameObject gaster = Instantiate(Gaster,randomTransfrom);
            GasterFire gasterFire = gaster.GetComponent<GasterFire>();
            gasterFire.zAngle = Angle(randomTransfrom);
            gasterFire.fireGasterPosition = randomTransfrom;

            yield return new WaitForSeconds(Random.Range(minIntervalTime,maxIntervalTime));
        }

        
    }

    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
    }

    /// <summary>
    /// 计算Gaster炮出现的位置和当前玩家的位置的夹角
    /// </summary>
    /// <returns></returns>
    public float Angle(Transform createTransform) {
        Vector3 different = -createTransform.position + player.position;

        float angle = Vector3.SignedAngle(different, createTransform.right, -Vector3.forward);

        return angle;
    }
}
