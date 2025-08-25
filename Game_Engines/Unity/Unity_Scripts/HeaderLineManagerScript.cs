using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderLineManagerScript : MonoBehaviour
{
    //These are the locations of the left side of the Line headers relative to the Header_Line_Parent, which this script is attached to
    [SerializeField]
    Public int indecies = 0;// {get;}
    [SerializeField]
    public int desc = 100;// {get;}
    public int actions = 475;// {get;}
    public int dest = 800;// {get;}
    public int traits = 1000;// {get;}
    public int effects = 1200;// {get;}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}