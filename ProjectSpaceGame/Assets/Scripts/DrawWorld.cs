/*
    Klasa odpowiedzialna za generowaanie nowych obiektów.
    Obiektem posiadającym ten skrypt jest niewidzialna płaszczyzna przed kamerą.
    Jeśli obiekty inne niż statek gracza wpadną na tą płaszczyznę to:
    *   Wyłączają się, trafiając spowrotem do puli obiektów
        oraz zostaje wylosowany kolejny obiekt z puli na ich miejsce
    *   Jeśli obiektem jest asteroida, która jest w tle (BGasteroid) 
        to zostanie ona przesunięta na koniec łańcucha asteroid w tle (900 jednostek)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWorld : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        if ((other.gameObject.tag != "Player") && (other.gameObject.tag != "BGasteroid"))
        {
            other.gameObject.SetActive(false);
            GenerateWorld.gw.GenerateSectors();
        }
        if (other.gameObject.tag == "BGasteroid")
        {
            other.gameObject.transform.position += new Vector3(0f, 0f, 900f);
            other.gameObject.SetActive(true);
        }
    }
}