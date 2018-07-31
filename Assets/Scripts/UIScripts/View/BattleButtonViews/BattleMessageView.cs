using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BattleMessageView : UnityGuiView<BattleMessageViewModel>{

    //=================================================
    // 此View管理的控件
    public Text message;
    public AudioManagement audioManagement;

    protected override void OnInitialize() {
        base.OnInitialize();
        binder.Add<string>("Message",OnMessageChanged);
    }



    private void OnMessageChanged(string oldValue,string newValue) {
        StartCoroutine(UITypeWriterUtli.WordFade(message,newValue,1,audioManagement.Audios["battletext"]));
    }
}
