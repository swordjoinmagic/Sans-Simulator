using System;
using System.Collections;
using System.Linq;
using System.Text;
using UnityEngine;

class WaitInputUtil {
    /// <summary>
    /// 等待玩家按下某按键继续游戏
    /// </summary>
    /// <param name="keyCode"></param>
    /// <returns></returns>
    public IEnumerator WaitForPlayerInput(KeyCode keyCode) {
        while (true) {
            bool isInput = Input.GetKeyDown(keyCode);
            if (isInput)
                yield break;
            else
                yield return null;
        }
    }
}

