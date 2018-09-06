using UnityEngine;
using System.Collections;

public class ChangeRoom : MonoBehaviour {
    public Camera cam;
    private int _iAux;

    void Start()
    {
    }

	void OnTriggerEnter2D(Collider2D c){
        if (this.enabled)
        {
            if (c.gameObject.tag == "entrance")
            {
                _iAux = 0;
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 8);
                StartCoroutine(cameraToTheTop());
                Destroy(GameObject.Find("/Entrance"));
                GameObject.Find("/InitialRoom").GetComponent<StartLvl>().enabled = true;
                GameObject.Find("/RoomGenerator").GetComponent<GenerateMap>().enabled = true;
                GameObject.Find("/ClipManager").GetComponent<ClipManager>().activateMusic = true;
            }
            if (c.gameObject.tag == "teleporterUp")
            {
                _iAux = 0;
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 4.4f);
                StartCoroutine(cameraToTheTop());
            }
            if (c.gameObject.tag == "teleporterDown")
            {
                _iAux = 0;
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y - 4f);
                StartCoroutine(cameraToTheBottom());
            }
            if (c.gameObject.tag == "teleporterRight")
            {
                _iAux = 0;
                this.transform.position = new Vector2(this.transform.position.x + 4.7f, this.transform.position.y);
                StartCoroutine(cameraToTheRight());
            }
            if (c.gameObject.tag == "teleporterLeft")
            {
                _iAux = 0;
                this.transform.position = new Vector2(this.transform.position.x - 4.7f, this.transform.position.y);
                StartCoroutine(cameraToTheLeft());
            }
        }
    }

    IEnumerator cameraToTheLeft()
    {
        if (_iAux != -18)
        {
            yield return new WaitForSeconds(0.01f);
            cam.transform.position = new Vector3(cam.transform.position.x - 1, cam.transform.position.y, -10);
            _iAux--;
            StartCoroutine(cameraToTheLeft());
        }
    }

    IEnumerator cameraToTheRight()
    {
        if (_iAux != 18)
        {
            yield return new WaitForSeconds(0.01f);
            cam.transform.position = new Vector3(cam.transform.position.x + 1, cam.transform.position.y, -10);
            _iAux++;
            StartCoroutine(cameraToTheRight());
        }
    }

    IEnumerator cameraToTheBottom()
    {
        if (_iAux != -10)
        {
            yield return new WaitForSeconds(0.01f);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 1, -10);
            _iAux--;
            StartCoroutine(cameraToTheBottom());
        }
    }

    IEnumerator cameraToTheTop()
    {
        if (_iAux != 10)
        {
            yield return new WaitForSeconds(0.01f);
            cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 1, -10);
            _iAux++;
            StartCoroutine(cameraToTheTop());
        }
    }
}
