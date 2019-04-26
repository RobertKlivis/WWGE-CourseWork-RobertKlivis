using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDataClass {

    public string name;
    public string input1;
    public string input2;
    public string input3;
    public string input4;
    public string input5;
    public string input6;

    DialogueDataClass()
    {

    }

    public DialogueDataClass(string s1, string s2, string s3, string s4, string s5, string s6, string s7)
    {
        name = s1;
        input1 = s2;
        input2 = s3;
        input3 = s4;
        input4 = s5;
        input5 = s6;
        input6 = s7;
    }
}
