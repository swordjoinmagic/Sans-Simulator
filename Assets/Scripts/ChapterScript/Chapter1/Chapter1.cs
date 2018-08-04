using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : MonoBehaviour,IChapter {

    private bool IsOver = false;

    public GameObject Right;
    public GameObject Left;

    public float Speed = 0.1f;

    public IEnumerator Main() {
        print("关卡Main开始");
        print("Left.transform.position.x:"+ Left.transform.position.x);
        while (Left.transform.position.x < 4.5) {
            Right.transform.Translate(new Vector2(-Speed, 0));
            Left.transform.Translate(new Vector2(Speed, 0));
            yield return new WaitForSeconds(0.02f);
        }
        IsOver = true;
    }

    public IEnumerator WaitChapterOver() {
        while (!IsOver) {
            yield return null;
        }
    }

    // Use this for initialization
    void Start () {
        //StartCoroutine(Main());
    }
}
