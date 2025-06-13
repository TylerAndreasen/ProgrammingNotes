using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button3Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
        

    private int accumulator = 1;

    public void OnButton3Pushed()
    {
        Debug.Log($"Button 3 has be pushed :{accumulator}: times. Woot!");
        accumulator++;
    }
}
