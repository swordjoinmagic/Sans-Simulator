using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


/// <summary>
/// 根据Gaster炮开炮的位置与角度放置Gaster炮
/// </summary>
public class GasterFire : MonoBehaviour, IChapter {

    // Gaster开炮的位置
    public Transform fireGasterPosition;
    // Gaster开炮角度
    public float zAngle;

    // 光波动画
    private Animation animationLight;
    // 开炮动画
    private Animator animationFire;

    // 音频管理器
    private AudioManagement audioManagement;

    private bool isOver = false;


    private void Awake() {

        audioManagement = GameObject.FindWithTag("Managerment").GetComponent<AudioManagement>();

        animationFire = GetComponent<Animator>();
        animationLight = GetComponentInChildren<Animation>();

    }

    public IEnumerator Main() {

        while (fireGasterPosition == null) {
            yield return null;
        }

        // Gaster移动到开炮的位置
        transform.DOMove(fireGasterPosition.position, 0.3f);
        transform.DORotate(new Vector3(0,0,zAngle), 0.3f);
        yield return new WaitForSeconds(0.1f);
        audioManagement.Audios["gasterblaster"].Play();
        yield return new WaitForSeconds(0.3f);

        // 等待开炮
        yield return new WaitForSeconds(0.3f);

        // Gaster开炮
        animationFire.SetTrigger("Fire");
        yield return new WaitForSeconds(0.2f);

        // 光波
        animationLight.Play();
        audioManagement.Audios["gasterblast"].Play();
        yield return new WaitForSeconds(0.2f);

        transform.DOBlendableMoveBy(-transform.right*2, 0.3f);
        //transform.DOBlendableMoveBy(-new Vector3(2,0,0)*(zAngle==0?1:-1),0.3f);
        yield return new WaitForSeconds(0.4f);

        isOver = true;
        //yield return WaitChapterOver();
    }

    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
        Destroy(this);
    }
}
