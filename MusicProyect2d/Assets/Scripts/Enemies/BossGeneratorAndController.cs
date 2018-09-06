using UnityEngine;

public class BossGeneratorAndController : MonoBehaviour {
    
    public int iEnemyCount;
    public GameObject goBoss;
    public GameObject goBox;
    public GameObject goDoor;
    public AudioClip acBossSong;
    public bool bGenerated;
    private GameObject _goEnemyInstance;    
    private GameObject _goMainCharacter;
    private AudioSource _asMusicSource;
    private AudioClip _acPreviousClip;

    void Start()
    {
        iEnemyCount = 1;
        bGenerated = false;
        _asMusicSource = GameObject.Find("/MusicSource").GetComponent<AudioSource>();
        _asMusicSource.Stop();
        _acPreviousClip = _asMusicSource.clip;
        _asMusicSource.clip=acBossSong;
        _asMusicSource.Play();
    }

    public void generateEnemies()
    {
        _goEnemyInstance = Instantiate(goBoss, goBox.transform.position, this.transform.rotation);
        _goEnemyInstance.transform.parent = this.transform;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainCharacter" && bGenerated == false)
        {
            _goMainCharacter = coll.gameObject;
            _goMainCharacter.GetComponent<ChangeRoom>().enabled = false;
            generateEnemies();
            this.enabled = true;
            bGenerated = true;
            
        }
    }


    void OnTriggerStay2D(Collider2D coll)
    {
        if (this.enabled)
        {
            bGenerated = true;
            if (coll.tag == "mainCharacter" && bGenerated==true && iEnemyCount == 0)
            {
                coll.GetComponent<ChangeRoom>().enabled = true;
                _asMusicSource = GameObject.Find("/MusicSource").GetComponent<AudioSource>();
                _asMusicSource.Stop();
                _asMusicSource.clip = _acPreviousClip;
                _asMusicSource.Play();
                if (this.transform.Find("stage") != null)
                    this.transform.Find("stage").gameObject.SetActive(false);
                goDoor.transform.Find("Closed").gameObject.SetActive(false);
                goDoor.transform.Find("Opened").gameObject.SetActive(true);
                this.GetComponent<BossGeneratorAndController>().enabled = false;
            }
        }
    }
}
