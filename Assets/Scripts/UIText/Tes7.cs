using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Tes7 : MonoBehaviour{
    public void FixedUpdate() {
        float v = Input.GetAxis("Vertical");
        float raw_v = Input.GetAxisRaw("Vertical");
        print("v:"+v+"  raw_v:"+raw_v);
    }
}

