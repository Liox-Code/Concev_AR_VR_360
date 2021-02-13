using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vista_360 : MonoBehaviour
{
    public Carga_Nivel_Transicion Animacion_Transicion;

    private bool giroscopio_existe;
    private Gyroscope gyro;

    public GameObject contenedor_camara;
    private Quaternion rotacion;

    public Transform cuerpo;

    void Start()
    {
        //contenedor_camara = new GameObject("Camara Contenedor");
        //contenedor_camara.transform.position = transform.position;
        //transform.SetParent(contenedor_camara.transform);

        giroscopio_existe = activar_giroscopio();
    }

    private bool activar_giroscopio()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;

            contenedor_camara.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rotacion = new Quaternion(0, 0, 1, 0);

            return true;
        }
        return false;
    }

    void Update()
    {
        if (giroscopio_existe)
        {
            Debug.Log(transform.position);
            transform.position = new Vector3(cuerpo.position.x, transform.position.y, cuerpo.position.z);
            Debug.Log(transform.position);
            transform.localRotation = gyro.attitude * rotacion;
            cuerpo.rotation = Quaternion.Euler(0,transform.eulerAngles.y,0);
        }
    }
}
