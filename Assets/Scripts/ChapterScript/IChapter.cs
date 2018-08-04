using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IChapter {
    /// <summary>
    /// 用来等待本次关卡结束的协程函数
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitChapterOver();

    /// <summary>
    /// 关卡触发函数,用于触发本次关卡
    /// </summary>
    IEnumerator Main();
}

