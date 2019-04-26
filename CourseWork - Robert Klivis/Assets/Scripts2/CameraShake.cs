using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public Transform camTransform;

    public float shakeDuration;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public bool Shake;

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    // Use this for initialization
    void Start () {

        shakeDuration = 0f;
        Shake = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }

        if (Shake == true)
        {
            shakeDuration = 0.2f;
        }
        else if (Shake == false)
        {
            shakeDuration = 0f;
        }
		
	}
}
