using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour
{
    public GameObject objectRotate;

    public float rotateSpeed = 50f;
    bool rotateStatus = false;

    // Start is called before the first frame update
    public void ToggleRotateStatus(){

    if(rotateStatus==false){
        rotateStatus = true;
    }
    else{
        rotateStatus = false;
    }
}


    // Update is called once per frame
    void Update()
    {
        if (rotateStatus == true){
            objectRotate.transform.Rotate (Vector3.up, rotateSpeed*Time.deltaTime);
        }
    }
}
