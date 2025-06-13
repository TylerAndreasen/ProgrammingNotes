using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_I_Pos_Script : MonoBehaviour
{

    public GameObject parent; //Unused Currently
    public Transform parentTransform;
    [SerializeField] Public int xOffset, int myIndex;


    // Start is called before the first frame update
    void Start()
    {
        xOffset = parent.GetComponent<Script>().getIndecies();
        parentTransform = parent.GetComponent<Transform>();
        //transform.setParent(parentTransform);
        transform.postion += new Vector3(xOffset,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
