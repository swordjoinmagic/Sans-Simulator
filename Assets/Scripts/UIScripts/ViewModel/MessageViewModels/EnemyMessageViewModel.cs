using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

/// <summary>
/// 敌人消息窗口ViewModel,用来管理敌人说的话
/// </summary>
public class EnemyMessageViewModel : ViewModelBase{
    public BindableProperty<string> message = new BindableProperty<string>();

    public EnemyMessageViewModel() {
        // 订阅消息
        MessageAggregator<string>.Instance.Subscribe("EnemyMessageChanged",MessageChanged); 
    }

    private void MessageChanged(object sender,MessageArgs<string>messageArgs) {
        message.Value = messageArgs.Item;
    }
}

