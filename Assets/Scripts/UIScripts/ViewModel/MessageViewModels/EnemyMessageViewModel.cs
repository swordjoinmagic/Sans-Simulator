﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using uMVVM;

public class EnemyMessageViewModel : ViewModelBase{
    public BindableProperty<string> message = new BindableProperty<string>();
}

