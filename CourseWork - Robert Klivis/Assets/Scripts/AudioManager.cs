using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip destroyBlockSound;
    public AudioClip placeBlockSound1;
    public AudioClip placeBlockSound2;
    public AudioClip placeBlockSound3;
    public AudioClip placeBlockSound4;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayDestroyBlockSound()
    {
        GetComponent<AudioSource>().PlayOneShot(destroyBlockSound);
    }

    void PlayPlaceBlockSound1()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSound1);
    }

    void PlayPlaceBlockSound2()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSound2);
    }

    void PlayPlaceBlockSound3()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSound3);
    }

    void PlayPlaceBlockSound4()
    {
        GetComponent<AudioSource>().PlayOneShot(placeBlockSound4);
    }

    void OnEnable()
    {
        VoxelChunk.OnEventBlockDestroyed += PlayDestroyBlockSound;
        VoxelChunk.OnEventBlockPlaced1 += PlayPlaceBlockSound1;
        VoxelChunk.OnEventBlockPlaced2 += PlayPlaceBlockSound2;
        VoxelChunk.OnEventBlockPlaced3 += PlayPlaceBlockSound3;
        VoxelChunk.OnEventBlockPlaced4 += PlayPlaceBlockSound4;
    }

    void OnDisable()
    {
        VoxelChunk.OnEventBlockDestroyed -= PlayDestroyBlockSound;
        VoxelChunk.OnEventBlockPlaced1 -= PlayPlaceBlockSound1;
        VoxelChunk.OnEventBlockPlaced2 -= PlayPlaceBlockSound2;
        VoxelChunk.OnEventBlockPlaced3 -= PlayPlaceBlockSound3;
        VoxelChunk.OnEventBlockPlaced4 -= PlayPlaceBlockSound4;
    }

}
