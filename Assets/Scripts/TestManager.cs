using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public GameObject[] buildings;
    private GameObject currentGo;

    public GameObject CurrentGo { get => currentGo; set => currentGo = value; }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && CurrentGo ==null) {

          CurrentGo =  Instantiate(buildings[0]);
           

        } else if (Input.GetKeyDown(KeyCode.W) && CurrentGo == null)
        {

          CurrentGo = Instantiate(buildings[1]);

        }else if (Input.GetKeyDown(KeyCode.E) && CurrentGo == null)
        {

          CurrentGo = Instantiate(buildings[2]);
        }
    }
}
