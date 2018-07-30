using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;
using UnityEngine.UI;
using UnityEngine;

public class BattleButtonsViewModel : ViewModelBase{
    // 表示该View是否处于活动状态
    public BindableProperty<bool> isActive = new BindableProperty<bool>();

    public BattleButtonsViewModel() {
        // 向中介者订阅该消息
        MessageAggregator<bool>.Instance.Subscribe("ChangeBattleButtonsViewActive",ActiveChanged);
    }

    private void ActiveChanged(object sender,MessageArgs<bool> args) {
        isActive.Value = args.Item;
    }
}

