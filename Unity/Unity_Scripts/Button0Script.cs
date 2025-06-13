using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button0Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }
        

    private int accumulator = 1;

    public void OnButton0Pushed()
    {
        Debug.Log($"Button 0 has be pushed :{accumulator}: times. Woot!");
        accumulator++;
    }

}
