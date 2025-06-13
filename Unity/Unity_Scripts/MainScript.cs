using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    private bool globalDebug = true;

    [SerializeField] GameObject lineInitPos, mainObject;
    [SerializeField] List<GameObject> viewLinePrefab;

    Transform initPos;
    private int lineViewX = -1000, lineViewY = -1000, lineViewSpacing = -1;

    //private List<GameObject. viewLines;

    // Start is called before the first frame update
    void Start()
    {
        bool methodDebug = true;
        initPos = lineInitPos.GetComponent<Transform>();
        lineViewX = (int) initPos.position.x;
        lineViewY = (int) initPos.position.y;
        if (globalDebug || methodDebug) { Debug.Log($"MainScript.Start() Found Starting Coordinates to be :{lineViewX}, {lineViewY}:. Planned Spacing is {lineViewSpacing}"); }
    }

    // Update is called once per frame
    void Update() { }


    

    private int 
        viewLineCount = 1,
        accumulator1 = 1,
        accumulator2 = 1,
        accumulator3 = 1,
        accumulator4 = 1;

    public void OnButton0Pushed()
    {
        bool methodDebug = false;
        if (globalDebug || methodDebug) { Debug.Log($"Button 0 has be pushed :{viewLineCount}: times. Woot! Trying Instantiate()."); }
        Instantiate(viewLinePrefab[viewLineCount], initPos);
        viewLineCount++;
    }
    public void OnButton1Pushed()
    {
        bool methodDebug = false;
        if (globalDebug || methodDebug)
        {
            Debug.Log($"Button 1 has be pushed :{accumulator1}: times. Woot!");
            accumulator1++;
        }
    }
    public void OnButton2Pushed()
    {
        bool methodDebug = false;
        if (globalDebug || methodDebug)
        {
            Debug.Log($"Button 2 has be pushed :{accumulator2}: times. Woot!");
            accumulator2++;
        }
    }
    public void OnButton3Pushed()
    {
        bool methodDebug = false;
        if (globalDebug || methodDebug)
        {
            Debug.Log($"Button 3 has be pushed :{accumulator3}: times. Woot!");
            accumulator3++;
        }
    }
    public void OnButton4Pushed()
    {
        bool methodDebug = false;
        if (globalDebug || methodDebug)
        {
            Debug.Log($"Button 4 has be pushed :{accumulator4}: times. Woot!");
            accumulator4++;
        }
    }
}
