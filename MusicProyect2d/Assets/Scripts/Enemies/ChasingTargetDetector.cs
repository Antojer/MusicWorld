using UnityEngine;

public class ChasingTargetDetector : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "mainCharacter")
            //Buscamos el índice del elemento con nombre igual a la casilla con la que el jugador se encuentra
            this.GetComponentInParent<AIMapping>().iTargetBoxIndex = this.GetComponentInParent<AIMapping>().agoBoxes.FindIndex(x => x.gameObject.name == this.gameObject.name);
    }
}
