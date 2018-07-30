using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uMVVM;

public class CharacterStatusView : UnityGuiView<CharacterStatusViewModel>{

    //==================================
    // 此View管理的UI控件
    public Text NameText;       // 姓名
    public Text LevelText;      // 等级
    public HPView hPView;       // 子视图

    private void Awake() {
        BindingContext = new CharacterStatusViewModel();

        // 显示
        Reveal();
    }


    protected override void OnInitialize() {
        base.OnInitialize();

        binder.Add<string>("Name",OnNameValueChanged);
        binder.Add<string>("Level",OnLevelValueChanged);
        binder.Add<HPModel>("HPModel",OnHpModelValueChanged);
    }

    private void OnNameValueChanged(string oldValue,string newValue) {
        NameText.text = newValue;
    }
    private void OnLevelValueChanged(string oldValue,string newValue) {
        LevelText.text = "Level "+newValue;
    }
    private void OnHpModelValueChanged(HPModel oldValue,HPModel newValue) {
        if (hPView.BindingContext == null) {
            hPView.BindingContext = new HPViewModel();
        }
        hPView.BindingContext.Init(newValue);
    }
}
