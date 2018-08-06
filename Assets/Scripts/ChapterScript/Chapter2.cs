using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter2 : MonoBehaviour,IChapter {

    public GameObject bone;

    private bool isOver = false;

    public IEnumerator Main() {
        while (bone.transform.position.x > -12) {
            bone.transform.Translate(new Vector2(-0.1f, 0));
            yield return new WaitForSeconds(0.02f);
        }

        while (bone.transform.position.x < 4) {
            bone.transform.Translate(new Vector2(0.13f, 0));
            yield return new WaitForSeconds(0.02f);
        }

        isOver = true;
    }

    public IEnumerator WaitChapterOver() {
        while (!isOver) {
            yield return null;
        }
    }
}
