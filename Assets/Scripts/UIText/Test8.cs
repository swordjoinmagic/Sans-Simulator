using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Test8 : MonoBehaviour{

    public Transform Left;

    GameObject ShortBone;

    public void Awake() {
        //ShortBone = Resources.Load("Prefabs/shortBone1") as GameObject;
        //GameObject gameObject = Instantiate(ShortBone,Left);
        print("awake");
    }
    public void Start() {
        print("start");
    }
    public void Main() {
        print("main");
    }
}
