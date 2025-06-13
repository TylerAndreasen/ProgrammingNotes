using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldPostitionScript : MonoBehaviour
{
    PageLine parent;
    InputField me;

    float inputFieldOffset = 200;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("#Debug# Run InputField.InputFieldPositionScript.Start() #");
        me = GameObject.FindWithTag("IFtag");
    }

    // Update is called once per frame
    void Update()
    {
        Transform parentTransform = parent.GetComponent<Transform>();
        Transform meTransform = me.GetComponent<Transform>();
        float vert = parentTransform.position.y-meTransform.position.y;
        float hori = parentTransform.position.x+inputFieldOffset-meTransform.position.x;
        me.Translate(hori,vert,0);

    }
}
