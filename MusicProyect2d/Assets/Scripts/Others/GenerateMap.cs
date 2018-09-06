using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour {

    public GameObject goRoom;
    public GameObject goBossRoom;
    public List<GameObject> aCreatedRooms;
    private int _iRoomsPlaced;
    private GameObject _goRoomInstance;
    private bool _bIsBossRoomPlaced;
    private float _fplaceBossRoomProbability;
    PlaceTeleporter ct;
   
    void Start () {
        _iRoomsPlaced = 0;
        ct = this.GetComponent<PlaceTeleporter>();
        generateMap();
        ct.placeTeleporters(aCreatedRooms);
        _bIsBossRoomPlaced = false;
        _fplaceBossRoomProbability = 0.0f;

    }
	
	void generateMap()
    {
        int a, b; //variables que guardarán un número aleatorio entre 1 y 3, 1 indicará que la habitación se colocará a la izquierda, 2 se colocará arriba, 3 se colocará a la derecha.
        while (_iRoomsPlaced < 15)
        {
            a = 0;
            b = 0;
            int w = Random.Range(1, 4);//número de habitaciones a colocar
            if(w == 1 || w == 2)
            {
                if (w == 1) //se colocará 1 habitación
                    a = Random.Range(1, 4);
                if (w == 2) //se colocarán 2 habitación
                {
                    a = Random.Range(1, 3);
                    b = Random.Range(1, 4);
                    while (a == b)
                        b = Random.Range(1, 4);
                }
                place(a,b);
            }
            if (w == 3) //se colocarán 3 habitaciones
            {
                place();
            }
        }

    }


    void place(int a=0,int b=0)
    {
        if(a==0 && b==0)
        {
            
            Vector2 v = new Vector2(this.transform.position.x - 18, this.transform.position.y);
            Vector2 v2 = new Vector2(this.transform.position.x, this.transform.position.y+10);
            Vector2 v3 = new Vector2(this.transform.position.x + 18, this.transform.position.y);
            if (factible(v))//comprobar factibilidad (no hay habitación en esa posición)
            {
                if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                {
                    _goRoomInstance = Instantiate(goBossRoom, v, this.transform.rotation);
                    aCreatedRooms.Add(_goRoomInstance);
                    _iRoomsPlaced += 1;
                    _bIsBossRoomPlaced = true;
                }
                else
                {
                    _goRoomInstance = Instantiate(goRoom, v, this.transform.rotation);
                    aCreatedRooms.Add(_goRoomInstance);
                    _iRoomsPlaced += 1;
                }
            }
            //aumentamos la probabilidad de colocar la ´sala del jefe final por cada habitación que colocamos y que no es la del jefe
            if (!_bIsBossRoomPlaced)
                _fplaceBossRoomProbability += 0.07f;
            if (factible(v2))//comprobar factibilidad (no hay habitación en esa posición)
            {
                _goRoomInstance = Instantiate(goRoom, v2, this.transform.rotation);
                aCreatedRooms.Add(_goRoomInstance);
                _iRoomsPlaced += 1;
                if (!_bIsBossRoomPlaced)
                    _fplaceBossRoomProbability += 0.07f;
            }
            if (factible(v3))//comprobar factibilidad (no hay habitación en esa posición)
            {
                _goRoomInstance = Instantiate(goRoom, v3, this.transform.rotation);
                aCreatedRooms.Add(_goRoomInstance);
                _iRoomsPlaced += 1;
                if (!_bIsBossRoomPlaced)
                    _fplaceBossRoomProbability += 0.07f;
            }
            int r = Random.Range(1, 4);
            //avanzamos el generador hacia izquierda, o arriba o a la derecha
            if (r == 1)
                this.transform.position = new Vector2(this.transform.position.x - 18, this.transform.position.y);
            if (r == 2)
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y + 10);
            if (r == 3)
                this.transform.position = new Vector2(this.transform.position.x + 18, this.transform.position.y);
        }
        else
        {
            if (a != 0)
            {
                Vector2 v;
                switch (a)
                {
                    case 1:
                        v = new Vector2(this.transform.position.x - 18, this.transform.position.y);
                        if (factible(v))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                    case 2:
                        v = new Vector2(this.transform.position.x, this.transform.position.y + 10);
                        if (factible(v))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                    case 3:
                        v = new Vector2(this.transform.position.x + 18, this.transform.position.y);
                        if (factible(v))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                }
                if (!_bIsBossRoomPlaced)
                    _fplaceBossRoomProbability += 0.07f;
            }
            if (b != 0)
            {
                Vector2 v2;
                switch (b)
                {
                    case 1:
                        v2 = new Vector2(this.transform.position.x - 18, this.transform.position.y);
                        if (factible(v2))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                    case 2:
                        v2 = new Vector2(this.transform.position.x, this.transform.position.y + 10);
                        if (factible(v2))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                    case 3:
                        v2 = new Vector2(this.transform.position.x + 18, this.transform.position.y);
                        if (factible(v2))//comprobar factibilidad (no hay una habitación en esa posición)
                        {
                            if (!_bIsBossRoomPlaced && Random.Range(0f, 1f) < _fplaceBossRoomProbability)
                            {
                                _goRoomInstance = Instantiate(goBossRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                                _bIsBossRoomPlaced = true;
                            }
                            else
                            {
                                _goRoomInstance = Instantiate(goRoom, v2, this.transform.rotation);
                                aCreatedRooms.Add(_goRoomInstance);
                                _iRoomsPlaced += 1;
                            }
                        }
                        break;
                }
                if (!_bIsBossRoomPlaced)
                    _fplaceBossRoomProbability += 0.07f;
            }
            int r;
            //avanzamos el generador hacia izquierda, o arriba o a la derecha
            if (Random.Range(0f, 1f) < 0.5f)
                r = a;
            else
                r = b;
            if(r==1)
                this.transform.position = new Vector2(this.transform.position.x-18, this.transform.position.y);
            if(r==2)
                this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y+10);
            if(r==3)
                this.transform.position = new Vector2(this.transform.position.x+18, this.transform.position.y);
        }    
    }


    private bool factible(Vector2 v)
    {
        bool f = true;
        if (aCreatedRooms.Count != 0)
            foreach (GameObject c in aCreatedRooms)
                if (Mathf.FloorToInt(v.x) == Mathf.FloorToInt(c.transform.position.x) && Mathf.FloorToInt(v.y) == Mathf.FloorToInt(c.transform.position.y))
                    f = false;
        return f;
    }
}
