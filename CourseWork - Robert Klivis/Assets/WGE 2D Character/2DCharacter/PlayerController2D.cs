using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour {

    public delegate void JumpInput();
    public delegate void JumpReleaseInput();
    public delegate void JumpPressedInput();
    public delegate void HorizontalMoveInput(float x);
    public delegate void DashPressedInput(Vector2 direction);

    public event JumpInput _jumpInput;
    public event JumpReleaseInput _jumpReleaseInput;
    public event HorizontalMoveInput _hMoveInput;
    public event JumpPressedInput _jumpPressedInput;
    public event DashPressedInput _dashPressedInput;

    public GameObject Camera;
    public GameObject dialoge;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;

    public bool activate;
    public float timer;

    public Text dialogueText;
    public Text buttonText1;
    public Text buttonText2;
    public Text buttonText3;
    public Text buttonText4;

    // Use this for initialization
    void Start () {

        activate = false;

        Camera.GetComponent<CameraShake>().enabled = false;
        Camera.GetComponent<CameraFollow>().enabled = true;

        timer = 0f;

        dialoge.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        button3.SetActive(false);
        button4.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
        {
            _jumpPressedInput();
        }
        if (Input.GetButton("Jump"))
        {
            _jumpInput();
        }
        if(Input.GetButtonUp("Jump"))
        {
            _jumpReleaseInput();
        }
        if(Input.GetButtonDown("Fire1"))
        {
            _dashPressedInput(new Vector2(hMove, vMove));
        }

        _hMoveInput(hMove);

        if (activate == true)
        {
            Camera.GetComponent<CameraShake>().enabled = true;
            Camera.GetComponent<CameraFollow>().enabled = false;
            timer += Time.deltaTime;
        }

        else if (activate == false)
        {
            Camera.GetComponent<CameraShake>().enabled = false;
            Camera.GetComponent<CameraFollow>().enabled = true;
            timer = 0f;
        }

        if (timer > 0f)
        {
            Camera.GetComponent<CameraShake>().Shake = true;
        }

        if (timer > 0.2f)
        {
            Camera.GetComponent<CameraShake>().Shake = false;
        }

	}

    public void ButtonClicked1 ()
    {
        dialogueText.text = "That's good to hear.";

        buttonText1.text = "Bye";

        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void ButtonClicked2 ()
    {
        dialogueText.text = "Aww, that's a shame.";

        buttonText1.text = "Bye";

        button2.SetActive(false);
        button3.SetActive(false);
    }

    public void ButtonClicked3 ()
    {
        dialogueText.text = "No need to brag about it.";

        buttonText4.text = "Then why did you ask?";
        buttonText2.text = "Bye.";

        button4.SetActive(true);

        button1.SetActive(false);
        button3.SetActive(false);
    }

    public void ButtonClicked4 ()
    {
        dialogueText.text = "Sorry, I'm not in a great mood today.";

        button4.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform")
        {
            activate = true;
        }

        if (coll.gameObject.tag == "npc")
        {
            dialoge.SetActive(true);
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(true);

            dialogueText.text = "Hey, how's it going?";

            buttonText1.text = "I'm doing okay.";
            buttonText2.text = "I'm doing terribly.";
            buttonText3.text = "I'm doing Great!";
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "platform")
        {
            activate = false;
        }

        if (coll.gameObject.tag == "npc")
        {
            dialoge.SetActive(false);
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(false);
        }
    }

}
