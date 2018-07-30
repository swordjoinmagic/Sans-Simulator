using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

public class HPViewModel : ViewModelBase{
    public BindableProperty<int> HP = new BindableProperty<int>();
    public BindableProperty<int> MaxHp = new BindableProperty<int>();
    

    public void Init(HPModel hPModel) {
        MaxHp.Value = hPModel.maxHp;
        HP.Value = hPModel.hp;
    }
}

