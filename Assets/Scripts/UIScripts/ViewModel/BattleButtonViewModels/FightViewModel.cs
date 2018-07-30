using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

class FightViewModel : ViewModelBase{
    public BindableProperty<bool> isActived = new BindableProperty<bool>();

    public FightViewModel() {
        // 向中介者订阅消息
        MessageAggregator<bool>.Instance.Subscribe("FightViewActiveChanged",ActivedChanged);
    }

    private void ActivedChanged(object sender,MessageArgs<bool> args) {
        isActived.Value = args.Item;
    }
}

