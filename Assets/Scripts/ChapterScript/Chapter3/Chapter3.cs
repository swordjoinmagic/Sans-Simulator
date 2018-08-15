using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Chapter3 : MonoBehaviour, IChapter {

    // Gaster炮发射的位置
    public Transform[] GasterFireRandomTransfrom;

    // Gaster炮一开始出现的位置
    public Transform[] GasterCreateTransfrom;

    public GameObject Gaster;

    // 砖块
    public Transform Bricks;
    // 砖块协程
    public IEnumerator brcksCourtine;
    // 砖块速度
    public float bricksSpeed = 2f;

    // 龙骨炮出现次数
    public int GasterCount = 20;
    // 龙骨炮出现间隔
    public float GasterIntervalMin = 1f;
    public float GasterIntervalMax = 1.5f;

    private bool isOver = false;

    public IEnumerator BricksMove() {

        Transform[] bricksChild = Bricks.GetComponentsInChildren<Transform>();

        // 砖块重复移动
        while (!isOver) {

            foreach (Transform brick in bricksChild) {

                if (brick == Bricks || !brick.name.Contains("brick")) continue;

                brick.Translate(new Vector2(1,0)*Time.deltaTime*bricksSpeed);
                if (brick.position.x > 2.8f) {
                    brick.position = new Vector3(-2.7f,brick.position.y,brick.position.z);
                }
            }

            yield return new WaitForSeconds(0.02f);
        }
    }

    private void Start() {
        StartCoroutine(BricksMove());
    }

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
            yield return new WaitForSeconds(Random.Range(GasterIntervalMin, GasterIntervalMax));
        }
        isOver = true;

        yield return WaitChapterOver();
    }

    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
    }
}
