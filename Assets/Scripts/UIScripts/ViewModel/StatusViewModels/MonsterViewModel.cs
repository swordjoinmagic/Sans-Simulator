using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

class MonsterViewModel : ViewModelBase{
    public BindableProperty<int> HP = new BindableProperty<int>();
    public BindableProperty<int> Attack = new BindableProperty<int>();

    public MonsterViewModel(int hp,int attack) {
        HP.Value = hp;
        Attack.Value = attack;

        // 订阅消息
        MessageAggregator<int>.Instance.Subscribe("SansInjured",(object sender,MessageArgs<int> temp)=> { HP.Value -= 1; });
    }


    public bool IsDied() {
        return HP.Value <= 0 ? true : false;
    }

}

