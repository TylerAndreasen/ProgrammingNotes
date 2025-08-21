using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("#Debug# Run Glia.MotionScript.Start() #");
        testNeuron = GameObject.FindWithTag("NeuroTag");
    }

    public float playerVSpeed = 3f;
    public float playerHSpeed = 3f;

    GameObject testNeuron;

    

    // Update is called once per frame
    void Update()
    {
        //Get info about key presses; The Input.GetAxis() is Unity's fast way of getting indication of indicated motion.
        //In the short term this is simple and makes this part super easy, but if I intend to release this I will want to ensure that the player can alter key inputs and make these more dynamic.
        float vert = Input.GetAxis("Vertical") * playerVSpeed * Time.deltaTime;
        float hori = Input.GetAxis("Horizontal") * playerHSpeed * Time.deltaTime;

        /*
        if (vert != 0 && hori != 0)
        {
            Debug.Log("#Debug# Glia.MotionScript.Update() Motion Detected : Vert -"+vert+" Hori: -"+hori);
        }
        */
        
        if (!testNeuron)
        {
            return;
        }
        Transform transformHolder = testNeuron.GetComponent<Transform>();
        
        RaycastHit eastRay;
        

        transform.Translate(hori,vert,0);
        
        if (Physics.Raycast(transform.position, Vector3.left, out eastRay, 1.0f))
            Debug.Log("Found an object at distance"+eastRay.distance);

    }
}
//https://unity3d.com/earn/tutorials/projects/space-shooter/moving-the-player?playlist=17147