using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimeintoVR : MonoBehaviour
{
    public Carga_Nivel_Transicion Animacion_Transicion;
    private bool camina = false;
    GvrHeadset Vista = null;
    public float velocidadCamina;

    void Start()
    {
        Vista = Camera.main.GetComponent<GvrHeadset>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            camina = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            camina = false;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Animacion_Transicion.cargar_escena("Menu_Principal", 1);
        }
        if (camina)
        {
            Vector3 direccion = new Vector3(Vista.transform.forward.x, 0, Vista.transform.forward.z).normalized * velocidadCamina * Time.deltaTime;
            Quaternion rotacion = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotacion * direccion);
        }
    }
}
