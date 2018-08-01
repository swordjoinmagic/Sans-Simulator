using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMessageView : UnityGuiView<EnemyMessageViewModel>{

    //================================
    // 此UI管理的控件
    public Text messageText;
    public AudioManagement audioManagement;
    public Animation am;

    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<string>("message",OnMessageChanged);
    }

    private void OnMessageChanged(string oldValue,string newValue) {
        StartCoroutine(UITypeWriterUtli.WordFade(messageText,newValue,1f, audioManagement.Audios["sans"]));
    }

    protected override void StartAnimatedReveal() {
        am.Play();
    }
}

