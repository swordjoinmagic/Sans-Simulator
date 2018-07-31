using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 实现UI的打字机特效
/// </summary>
public class UITypeWriterUtli {
    /// <summary>
    /// 为一个文字控件执行打字节效果
    /// </summary>
    /// <param name="text">该文字控件</param>
    /// <param name="words">需要显示的文字</param>
    /// <param name="duration">这一段文字总共需要多长时间出现</param>
    /// <param name="audioClip">每个字出现时，播放的音乐</param>
    /// <returns></returns>
    public static IEnumerator WordFade(Text text, string words, float duration, AudioSource audio) {

        int length = words.Length;

        // 清空Text控件
        text.text = "";

        yield return new WaitForFixedUpdate();

        foreach (char ch in words) {
            // 文字浮现
            text.text += ch;
            // 播放文字出现时的音乐
            if (audio != null) audio.Play();

            // 等待一段时间
            yield return new WaitForSeconds(duration / (float)length);
        }
    }

}

