using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class THIMDataScript
{

    [SerializeField] TMP_Text valueDescription, userValue;

    THIMDataScript(string header)
    {
        this.valueDescription.text = header;
    }

    string GetDescription() { return this.valueDescription.text; }
    string GetUserValue() { return this.userValue.text; }
}
