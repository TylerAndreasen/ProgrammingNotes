using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDelveFiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("C:\\Users\\CanaDev\\DelveFileCreation\\Assets\\delve.pages"))
            {
                // Read the stream as a string, and write the string to the console.
                Debug.Log(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
        try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("C:\\Users\\CanaDev\\DelveFileCreation\\Assets\\delve.directories"))
            {
                // Read the stream as a string, and write the string to the console.
                Debug.Log(sr.ReadToEnd());
            }
        }
        catch (IOException e)
        {
            Debug.Log("The file could not be read:");
            Debug.Log(e.Message);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
