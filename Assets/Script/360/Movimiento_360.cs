using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_360 : MonoBehaviour
{
    private bool camina = false;
    public float velocidadCamina;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        if (camina)
        {
            //transform.Translate(transform.forward * Time.deltaTime);
             
            Vector3 direccion = new Vector3( transform.forward.x, 0, transform.forward.z).normalized * velocidadCamina * Time.deltaTime;
            Quaternion rotacion = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
            transform.Translate(rotacion * direccion);
        }
    }
}
