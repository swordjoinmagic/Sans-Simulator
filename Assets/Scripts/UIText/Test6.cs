using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Test6 : MonoBehaviour{
    //public Animation animation;
    public Animator animator;
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            animator.SetTrigger("isBig"); 
        }
        //if (Input.GetKeyDown(KeyCode.E)) {
        //    animation.Play("TestAnim2");
        //}
    }
}

