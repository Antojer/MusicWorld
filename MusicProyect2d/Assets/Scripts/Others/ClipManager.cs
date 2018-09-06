using System.Collections.Generic;
using UnityEngine;

public class ClipManager : MonoBehaviour {
    public List<AudioClip> aacClips;
    public bool activateMusic;
    private AudioSource _asMusicSource;
    // Use this for initialization
    void Start () {
        activateMusic = false;
         _asMusicSource = GameObject.Find("/MusicSource").GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update () {
        if(activateMusic)
            if (!_asMusicSource.isPlaying && !GameObject.Find("BossRoom(Clone)").GetComponent<BossGeneratorAndController>().bGenerated)
            {
                int iIndex = Random.Range(0, aacClips.Count);
                _asMusicSource.clip = aacClips[iIndex];
                _asMusicSource.Play();
            }
            else
                this.gameObject.SetActive(false);
	}
}
