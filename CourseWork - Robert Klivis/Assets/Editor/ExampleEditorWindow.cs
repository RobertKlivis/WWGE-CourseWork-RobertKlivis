using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Xml.Serialization;

public class ExampleEditorWindow : EditorWindow {

    static ExampleEditorWindow window;

    string npcInput1= "";
    string npcInput2 = "";
    string npcInput3 = "";
    string playerInput1 = "";
    string playerInput2 = "";
    string playerInput3 = "";

    [MenuItem("MyCustomWindows/DialogueWindow")]
    static void Init()
    {
        window = (ExampleEditorWindow)EditorWindow.GetWindow(typeof(ExampleEditorWindow));
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Put in the text for dialogue!");


        GUI.TextArea(new Rect(10, 25, 50, 20), "NPC:");

        GUI.TextArea(new Rect(10, 50, 50, 20), "Player:");

        GUI.TextArea(new Rect(10, 75, 50, 20), "NPC:");

        GUI.TextArea(new Rect(10, 100, 50, 20), "Player:");

        GUI.TextArea(new Rect(10, 125, 50, 20), "NPC:");

        GUI.TextArea(new Rect(10, 150, 50, 20), "Player:");

        GUI.Button(new Rect(100, 75, 125, 25), "That's good to hear.");

        GUI.Button(new Rect(200, 75, 125, 25), "Aww, that's a shame.");

        GUI.Button(new Rect(300, 75, 125, 25), "No need to brag about it.");

        GUI.Button(new Rect(100, 100, 100, 25), "Bye.");

        GUI.Button(new Rect(200, 100, 100, 25), "Bye.");

        GUI.Button(new Rect(300, 125, 125, 25), "Sorry, I'm not in a great mood today.");

        GUI.Button(new Rect(300, 150, 100, 25), "Bye.");


        if (GUI.Button(new Rect(200, 25, 125, 25), "Hey, how's it going?"))
        {
            npcInput1 = "Hey, how's it going?";
        }


        if (GUI.Button(new Rect(300, 100, 125, 25), "Then why did you ask?"))
        {
            playerInput2 = "Then why did you ask?";
            npcInput3 = "Sorry, I'm not in a great mood today.";
            playerInput3 = "Bye";
        }

        if (GUI.Button(new Rect(400, 100, 125, 25), "Bye."))
        {
            playerInput2 = "Bye";
        }


        if (GUI.Button(new Rect(100, 50, 125, 25), "I'm doing okay."))
        {
            npcInput1 = "Hey, how's it going?";
            playerInput1 = "I'm doing okay.";
            npcInput2 = "That's good to hear.";
            playerInput2 = "Bye";
        }

        else if (GUI.Button(new Rect(200, 50, 125, 25), "I'm doing terribly."))
        {
            npcInput1 = "Hey, how's it going?";
            playerInput1 = "I'm doing terribly.";
            npcInput2 = "Aww, that's a shame.";
            playerInput2 = "Bye";
        }

        else if (GUI.Button(new Rect(300, 50, 125, 25), "I'm doing Great!"))
        {
            npcInput1 = "Hey, how's it going?";
            playerInput1 = "I'm doing Great!";
            npcInput2 = "No, need to brag about it";
        }

        if (GUI.Button(new Rect(0, 200, position.width, 30), "Set Dialogue!"))
        {
            DialogueDataClass ddc = new DialogueDataClass("Dialogue Text", npcInput1, playerInput1, npcInput2, playerInput2, npcInput3, playerInput3);
            XmlSerializer x = new XmlSerializer(ddc.GetType());

            System.IO.FileStream file = System.IO.File.Create("DialogueFile.xml");

            x.Serialize(file, ddc);
            file.Close();

        }
        
    }

}
