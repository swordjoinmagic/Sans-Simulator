using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using uMVVM;
using System.Collections;

public class HPView : UnityGuiView<HPViewModel> {

    //====================================
    // 此View管理的UI控件
    public RectTransform hpImage;       // 显示血条的Image
    public Text hpText;         // 显示血条的Text
    public Text maxHpText;      // 显示最大血量的Text
    public int hpImageMaxWidth;    // 血条控件的最大长度

    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<int>("HP", OnHpValueChanged);
        binder.Add<int>("MaxHp", OnMaxHpValueChanged);
    }

    /// <summary>
    /// 血条图像的渐变变化
    /// </summary>
    /// <param name="difference">新血条和旧血条之间的差值</param>
    /// <returns></returns>
    IEnumerator HpImageChangedFade(int difference, int nowHp, int newHp, int maxHp) {
        int tempDifference = 0;
        int tempHp = nowHp;
        // 判断是加血还是减血
        bool isIncrease = newHp > nowHp ? true : false;
        // 每次变化的量
        int step = isIncrease ? 1 : -1;
        while (tempDifference != difference) {
            tempDifference += Math.Abs(step);
            // 血量变化
            tempHp += step;
            // 计算此时血量与最大血量的比值
            float rate = (float)tempHp / (float)maxHp;
            // 计算此时血条的长度
            float width = rate * hpImageMaxWidth;
            hpImage.sizeDelta = new Vector2(width, 30);
            yield return new WaitForFixedUpdate();
        }

    }
    /// <summary>
    /// 当hp变化时，执行的函数
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private void OnHpValueChanged(int oldValue, int newValue) {
        hpText.text = newValue.ToString();
        StartCoroutine(HpImageChangedFade(Math.Abs(newValue - oldValue), oldValue, newValue, int.Parse(maxHpText.text.ToString())));
    }

    /// <summary>
    /// 当最大生命值变化时，执行的函数
    /// </summary>
    /// <param name="oldValue"></param>
    /// <param name="newValue"></param>
    private void OnMaxHpValueChanged(int oldValue,int newValue) {
        maxHpText.text = newValue.ToString();
    }
}
