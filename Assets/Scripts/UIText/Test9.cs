using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class Test9 : MonoBehaviour{
    public Transform player;
    public Transform Gaster;

    public void Awake() {            

    }

    public void Update() {
        Debug.DrawLine(Gaster.position, Gaster.position + Gaster.up, Color.red);
        Debug.DrawLine(Gaster.position, Gaster.position + Gaster.right, Color.green);
        Debug.DrawLine(Gaster.position, Gaster.position + Gaster.forward, Color.blue);
        print("gasterRight:"+Gaster.right+ "  Gaster.position + Gaster.right:"+ (Gaster.position + Gaster.right));

        Vector3 different = -Gaster.position + player.position;

        //float angle = Vector3.SignedAngle(Gaster.right, different, Vector3.forward);
        float angle = Vector3.SignedAngle(different, Gaster.right, -Vector3.forward);
        //float angle = Vector3.Angle(Gaster.right,different);

        print("angle:"+angle);
        //Debug.DrawLine(Gaster.position,Gaster.position+different,Color.white);
        //Vector3 vector3 = Gaster.rotation.ToEuler();
        //vector3.z += angle;
        //Gaster.rotation = Quaternion.Euler(vector3);
    }
}

