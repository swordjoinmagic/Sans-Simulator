using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chapter3 : MonoBehaviour, IChapter {

    // Gaster炮发射的位置
    public Transform[] GasterFireRandomTransfrom;

    // Gaster炮一开始出现的位置
    public Transform[] GasterCreateTransfrom;

    public GameObject Gaster;

    // 龙骨炮出现次数
    public int GasterCount = 20;

    private bool isOver = false;

    public IEnumerator Main() {
        GameObject newGaster;
        for (int i = 0; i < GasterCount; i++) {
            int range = Random.Range(0, GasterFireRandomTransfrom.Length);
            if (range >= GasterFireRandomTransfrom.Length / 2) {
                // 右
                newGaster = Instantiate(Gaster, GasterCreateTransfrom[1]);
                newGaster.GetComponent<GasterFire>().zAngle = 180;

            } else {
                // 左
                newGaster = Instantiate(Gaster, GasterCreateTransfrom[0]);
                newGaster.GetComponent<GasterFire>().zAngle = 0;
            }
            newGaster.GetComponent<GasterFire>().fireGasterPosition = GasterFireRandomTransfrom[range];
            //yield return newGaster.GetComponent<GasterFire>().WaitChapterOver();

            // 等待随机时间
            yield return new WaitForSeconds(Random.Range(0.3f, 1f));
        }
        isOver = true;
    }

    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
    }
}
