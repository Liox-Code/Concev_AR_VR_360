using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Seleccionar_Modelo : MonoBehaviour
{
    public GameObject[] modelos;

    void Start()
    {
        if (Global_Session.Vista_Seleccionada == "Vista_VR")
        {
            StartCoroutine(EnableCardboard());
        }
        if(Global_Session.nombre_Modelo_Seleccionado != null)
        {
            if (Global_Session.nombre_Modelo_Seleccionado == "Edificio_1")
            {
                modelos[0].SetActive(true);
            }
            else if (Global_Session.nombre_Modelo_Seleccionado == "Miraflores_2")
            {
                modelos[1].SetActive(true);
            }
        }
    }

    public IEnumerator EnableCardboard()
    {
        XRSettings.LoadDeviceByName("CardBoard");
        yield return null;
        XRSettings.enabled = true;
    }
}
