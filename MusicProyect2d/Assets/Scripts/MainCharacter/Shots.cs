using UnityEngine;

public class Shots : MonoBehaviour
{
    public GameObject goMainCharacter;
    public Rigidbody2D rbNote;
    public GameObject goMouth;
    public GameObject goFrontHead;
    public GameObject goRightHead;
    public GameObject goLeftHead;
    public GameObject goBackHead;
    public GameObject goAfroWig;
    public GameObject goRastaHat;
    public Transform tShotInstantiator;
    public float fForce;
    public AudioSource asShot;
    public float fShotSize;
    public GameObject goVinyl;
    private float _fInstantiationTimer = 0f;
    private Vector2 _aShotInstantiatorInitialPosition;
    private bool audioAsigned;

    void Start()
    {
        LoadStats l = goMainCharacter.GetComponent<LoadStats>();
        fForce = l.c.fShotForce;
        fShotSize = l.c.fShotSize;
    }

    //Left Shots

    public void leftShot(bool _bIsShoting)
    {
        if (GameObject.Find("/MainCharacter/Items/queenvinyl").gameObject.activeSelf)
            rbNote = goVinyl.GetComponent<Rigidbody2D>();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf && !audioAsigned)
        {
            asShot.clip = GameObject.Find("/MainCharacter/Items/guitar").GetComponent<AudioSource>().clip;
            audioAsigned = true;
        }
        _aShotInstantiatorInitialPosition = goFrontHead.transform.position;
        if (_bIsShoting)
        {
            if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
                GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("PlayGuitar");
            if (goAfroWig.activeSelf)
            {
                goAfroWig.transform.Find("front").gameObject.SetActive(false);
                goAfroWig.transform.Find("back").gameObject.SetActive(false);
                goAfroWig.transform.Find("right").gameObject.SetActive(false);
                goAfroWig.transform.Find("left").gameObject.SetActive(true);
            }
            if (goRastaHat.activeSelf)
            {
                goRastaHat.transform.Find("front").gameObject.SetActive(false);
                goRastaHat.transform.Find("back").gameObject.SetActive(false);
                goRastaHat.transform.Find("right").gameObject.SetActive(false);
                goRastaHat.transform.Find("left").gameObject.SetActive(true);
            }
            goRightHead.SetActive(false);
            goFrontHead.SetActive(false);
            goBackHead.SetActive(false);
            goLeftHead.SetActive(true);
            tShotInstantiator.position = _aShotInstantiatorInitialPosition;
            tShotInstantiator.position = new Vector2(tShotInstantiator.position.x - 0.5f, tShotInstantiator.position.y);
            _fInstantiationTimer -= Time.deltaTime;
            if (_fInstantiationTimer <= 0)
            {
                LoadStats l = goMainCharacter.GetComponent<LoadStats>();
                fForce = l.c.fShotForce;
                fShotSize = l.c.fShotSize;
                if (!asShot.isPlaying)
                    asShot.Play();
                Rigidbody2D noteInstance;
                goMouth.SetActive(true);
                goLeftHead.SetActive(true);
                goFrontHead.SetActive(false);
                noteInstance = Instantiate(rbNote, tShotInstantiator.position, tShotInstantiator.rotation) as Rigidbody2D;
                if (goRastaHat.activeSelf)
                    noteInstance.GetComponent<Animator>().Play("wave");
                noteInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                noteInstance.velocity = (-tShotInstantiator.right * fForce);
                _fInstantiationTimer = 0.5f;
            }
        }
    }


    public void leftToDefaultState()
    {
        asShot.Stop();
        goMouth.SetActive(false);
        goFrontHead.SetActive(true);
        goRightHead.SetActive(false);
        goLeftHead.SetActive(false);
        goBackHead.SetActive(false);
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
            GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("Normal");
        if (goAfroWig.activeSelf)
        {
            goAfroWig.transform.Find("front").gameObject.SetActive(true);
            goAfroWig.transform.Find("back").gameObject.SetActive(false);
            goAfroWig.transform.Find("right").gameObject.SetActive(false);
            goAfroWig.transform.Find("left").gameObject.SetActive(false);
        }
        if (goRastaHat.activeSelf)
        {
            goRastaHat.transform.Find("front").gameObject.SetActive(true);
            goRastaHat.transform.Find("back").gameObject.SetActive(false);
            goRastaHat.transform.Find("right").gameObject.SetActive(false);
            goRastaHat.transform.Find("left").gameObject.SetActive(false);
        }
        tShotInstantiator.position = _aShotInstantiatorInitialPosition;
    }





    //-----------
    //Right Shots




    public void rightShot(bool _bIsShoting)
    {
        if (GameObject.Find("/MainCharacter/Items/queenvinyl").gameObject.activeSelf)
            rbNote = goVinyl.GetComponent<Rigidbody2D>();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf && !audioAsigned)
        {
            asShot.clip = GameObject.Find("/MainCharacter/Items/guitar").GetComponent<AudioSource>().clip;
            audioAsigned = true;
        }
        _aShotInstantiatorInitialPosition = goFrontHead.transform.position;
        if (_bIsShoting)
        {
            if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
                GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("PlayGuitar");
            if (goAfroWig.activeSelf)
            {
                goAfroWig.transform.Find("front").gameObject.SetActive(false);
                goAfroWig.transform.Find("back").gameObject.SetActive(false);
                goAfroWig.transform.Find("right").gameObject.SetActive(true);
                goAfroWig.transform.Find("left").gameObject.SetActive(false);
            }
            if (goRastaHat.activeSelf)
            {
                goRastaHat.transform.Find("front").gameObject.SetActive(false);
                goRastaHat.transform.Find("back").gameObject.SetActive(false);
                goRastaHat.transform.Find("right").gameObject.SetActive(true);
                goRastaHat.transform.Find("left").gameObject.SetActive(false);
            }
            goLeftHead.SetActive(false);
            goFrontHead.SetActive(false);
            goBackHead.SetActive(false);
            goRightHead.SetActive(true);
            tShotInstantiator.position = _aShotInstantiatorInitialPosition;
            tShotInstantiator.position = new Vector2(tShotInstantiator.position.x + 0.5f, tShotInstantiator.position.y);
            _fInstantiationTimer -= Time.deltaTime;
            if (_fInstantiationTimer <= 0)
            {
                LoadStats l = goMainCharacter.GetComponent<LoadStats>();
                fForce = l.c.fShotForce;
                fShotSize = l.c.fShotSize;
                if (!asShot.isPlaying)
                    asShot.Play();
                Rigidbody2D noteInstance;
                goMouth.SetActive(true);
                goRightHead.SetActive(true);
                goFrontHead.SetActive(false);
                noteInstance = Instantiate(rbNote, tShotInstantiator.position, tShotInstantiator.rotation) as Rigidbody2D;
                if (goRastaHat.activeSelf)
                    noteInstance.GetComponent<Animator>().Play("wave");
                noteInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                noteInstance.velocity = (tShotInstantiator.right * fForce);
                _fInstantiationTimer = 0.5f;
            }
        }
    }

    public void rightToDefaultState()
    {
        asShot.Stop();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
            GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("Normal");
        if (goAfroWig.activeSelf)
        {
            goAfroWig.transform.Find("front").gameObject.SetActive(true);
            goAfroWig.transform.Find("back").gameObject.SetActive(false);
            goAfroWig.transform.Find("right").gameObject.SetActive(false);
            goAfroWig.transform.Find("left").gameObject.SetActive(false);
        }
        if (goRastaHat.activeSelf)
        {
            goRastaHat.transform.Find("front").gameObject.SetActive(true);
            goRastaHat.transform.Find("back").gameObject.SetActive(false);
            goRastaHat.transform.Find("right").gameObject.SetActive(false);
            goRastaHat.transform.Find("left").gameObject.SetActive(false);
        }
        goMouth.SetActive(false);
        goFrontHead.SetActive(true);
        goRightHead.SetActive(false);
        goLeftHead.SetActive(false);
        goBackHead.SetActive(false);
        tShotInstantiator.position = _aShotInstantiatorInitialPosition;
    }


    //--------
    //Up Shots



    public void upShot(bool _bIsShoting)
    {
        if (GameObject.Find("/MainCharacter/Items/queenvinyl").gameObject.activeSelf)
            rbNote = goVinyl.GetComponent<Rigidbody2D>();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf && !audioAsigned)
        {
            asShot.clip = GameObject.Find("/MainCharacter/Items/guitar").GetComponent<AudioSource>().clip;
            audioAsigned = true;
        }
        _aShotInstantiatorInitialPosition = goFrontHead.transform.position;
        if (_bIsShoting)
        {
            if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
            {
                GameObject.Find("/MainCharacter/body/leftHand").GetComponent<Renderer>().sortingOrder = 6;
                GameObject.Find("/MainCharacter/body/rightHand").GetComponent<Renderer>().sortingOrder = 6;
                GameObject.Find("/MainCharacter/Items/guitar").GetComponent<Renderer>().sortingOrder = 7;
                GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("PlayGuitar");
            }
            if (goAfroWig.activeSelf)
            {
                goAfroWig.transform.Find("front").gameObject.SetActive(false);
                goAfroWig.transform.Find("back").gameObject.SetActive(true);
                goAfroWig.transform.Find("right").gameObject.SetActive(false);
                goAfroWig.transform.Find("left").gameObject.SetActive(false);
            }
            if (goRastaHat.activeSelf)
            {
                goRastaHat.transform.Find("front").gameObject.SetActive(false);
                goRastaHat.transform.Find("back").gameObject.SetActive(true);
                goRastaHat.transform.Find("right").gameObject.SetActive(false);
                goRastaHat.transform.Find("left").gameObject.SetActive(false);
            }
            goRightHead.SetActive(false);
            goLeftHead.SetActive(false);
            goFrontHead.SetActive(false);
            goBackHead.SetActive(true);
            tShotInstantiator.position = _aShotInstantiatorInitialPosition;
            tShotInstantiator.position = new Vector2(tShotInstantiator.position.x, tShotInstantiator.position.y + 0.5f);
            _fInstantiationTimer -= Time.deltaTime;
            if (_fInstantiationTimer <= 0)
            {
                LoadStats l = goMainCharacter.GetComponent<LoadStats>();
                fForce = l.c.fShotForce;
                fShotSize = l.c.fShotSize;
                if (!asShot.isPlaying)
                    asShot.Play();
                Rigidbody2D noteInstance;
                if (!GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
                    goMouth.SetActive(true);
                noteInstance = Instantiate(rbNote, tShotInstantiator.position, tShotInstantiator.rotation) as Rigidbody2D;
                if (goRastaHat.activeSelf)
                    noteInstance.GetComponent<Animator>().Play("waveUpDown");
                noteInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                noteInstance.velocity = (tShotInstantiator.up * fForce);
                _fInstantiationTimer = 0.5f;
            }
        }
    }

    public void upToDefaultState()
    {
        asShot.Stop();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
        {
            GameObject.Find("/MainCharacter/Items/guitar").GetComponent<Renderer>().sortingOrder = 10;
            GameObject.Find("/MainCharacter/body/leftHand").GetComponent<Renderer>().sortingOrder = 11;
            GameObject.Find("/MainCharacter/body/rightHand").GetComponent<Renderer>().sortingOrder = 11;
            GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("Normal");
        }
        if (goAfroWig.activeSelf)
        {
            goAfroWig.transform.Find("front").gameObject.SetActive(true);
            goAfroWig.transform.Find("back").gameObject.SetActive(false);
            goAfroWig.transform.Find("right").gameObject.SetActive(false);
            goAfroWig.transform.Find("left").gameObject.SetActive(false);
        }
        if (goRastaHat.activeSelf)
        {
            goRastaHat.transform.Find("front").gameObject.SetActive(true);
            goRastaHat.transform.Find("back").gameObject.SetActive(false);
            goRastaHat.transform.Find("right").gameObject.SetActive(false);
            goRastaHat.transform.Find("left").gameObject.SetActive(false);
        }
        goMouth.SetActive(false);
        goFrontHead.SetActive(true);
        goRightHead.SetActive(false);
        goLeftHead.SetActive(false);
        goBackHead.SetActive(false);
        tShotInstantiator.position = _aShotInstantiatorInitialPosition;
    }


    //-----------
    //Down shots



    public void downShot(bool _bIsShoting)
    {
        if (GameObject.Find("/MainCharacter/Items/queenvinyl").gameObject.activeSelf)
            rbNote = goVinyl.GetComponent<Rigidbody2D>();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf && !audioAsigned)
        {
            asShot.clip = GameObject.Find("/MainCharacter/Items/guitar").GetComponent<AudioSource>().clip;
            audioAsigned = true;
        }
        _aShotInstantiatorInitialPosition = goFrontHead.transform.position;
        if (_bIsShoting)
        {
            if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
                GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("PlayGuitar");
            if (goAfroWig.activeSelf)
            {
                goAfroWig.transform.Find("front").gameObject.SetActive(true);
                goAfroWig.transform.Find("back").gameObject.SetActive(false);
                goAfroWig.transform.Find("right").gameObject.SetActive(false);
                goAfroWig.transform.Find("left").gameObject.SetActive(false);
            }
            if (goRastaHat.activeSelf)
            {
                goRastaHat.transform.Find("front").gameObject.SetActive(true);
                goRastaHat.transform.Find("back").gameObject.SetActive(false);
                goRastaHat.transform.Find("right").gameObject.SetActive(false);
                goRastaHat.transform.Find("left").gameObject.SetActive(false);
            }
            goRightHead.SetActive(false);
            goLeftHead.SetActive(false);
            goBackHead.SetActive(false);
            goFrontHead.SetActive(true);
            tShotInstantiator.position = _aShotInstantiatorInitialPosition;
            _fInstantiationTimer -= Time.deltaTime;
            if (_fInstantiationTimer <= 0)
            {
                LoadStats l = goMainCharacter.GetComponent<LoadStats>();
                fForce = l.c.fShotForce;
                fShotSize = l.c.fShotSize;
                if (!asShot.isPlaying)
                    asShot.Play();
                Rigidbody2D noteInstance;
                if (!GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
                    goMouth.SetActive(true);
                noteInstance = Instantiate(rbNote, tShotInstantiator.position, tShotInstantiator.rotation) as Rigidbody2D;
                if (goRastaHat.activeSelf)
                    noteInstance.GetComponent<Animator>().Play("waveUpDown");
                noteInstance.transform.localScale += new Vector3(fShotSize, fShotSize, 0);
                noteInstance.velocity = (-tShotInstantiator.up * fForce);
                _fInstantiationTimer = 0.5f;
            }
        }
    }

    public void downToDefaultState()
    {
        asShot.Stop();
        if (GameObject.Find("/MainCharacter/Items/guitar").gameObject.activeSelf)
            GameObject.Find("/MainCharacter").GetComponent<Animator>().Play("Normal");
        if (goAfroWig.activeSelf)
        {
            goAfroWig.transform.Find("front").gameObject.SetActive(true);
            goAfroWig.transform.Find("back").gameObject.SetActive(false);
            goAfroWig.transform.Find("right").gameObject.SetActive(false);
            goAfroWig.transform.Find("left").gameObject.SetActive(false);
        }
        if (goRastaHat.activeSelf)
        {
            goRastaHat.transform.Find("front").gameObject.SetActive(true);
            goRastaHat.transform.Find("back").gameObject.SetActive(false);
            goRastaHat.transform.Find("right").gameObject.SetActive(false);
            goRastaHat.transform.Find("left").gameObject.SetActive(false);
        }
        goMouth.SetActive(false);
        goFrontHead.SetActive(true);
        goRightHead.SetActive(false);
        goLeftHead.SetActive(false);
        goBackHead.SetActive(false);
        tShotInstantiator.position = _aShotInstantiatorInitialPosition;
    }
}
