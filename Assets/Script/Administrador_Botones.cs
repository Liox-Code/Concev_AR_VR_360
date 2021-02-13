using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Administrador_Botones : MonoBehaviour
{

    public GameObject btn_Atras;
    public Carga_Nivel_Transicion Animacion_Transicion;

    void Start()
    {
        btn_Atras.GetComponent<Button>().onClick.AddListener(() => Volver_Atras());
    }

    public void Volver_Atras()
    {
        Animacion_Transicion.cargar_escena("Menu_Principal",1);
    }
}
