using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{

    public string[] description { get; }
    public string index { get; }



    public Page (string[] passInDescription, string passInIndex) => (description, index) = (passInDescription, passInIndex);




}
