using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine;    

public class BattleView : UnityGuiView<ViewModelBase>{
    //========================
    // 此View管理的控件
    public Animation transferAnimation;

    private void Awake() {
        BindingContext = new ViewModelBase();
    }

    protected override void StartAnimatedHide() {
        canvasGroup.interactable = false;
        transferAnimation.Play();
        canvasGroup.alpha = 0;
    }
}

