using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Carga_Nivel_Transicion : MonoBehaviour
{
    public Animator transicion;
    public void cargar_escena(string nombre_escena, int duracion)
    {
        StartCoroutine(transicion_cargar_escena(nombre_escena, duracion));
    }

    IEnumerator transicion_cargar_escena(string nombre_escena, int duracion)
    {
        transicion.SetTrigger("Comensar");
        yield return new WaitForSeconds(duracion);
        SceneManager.LoadScene(nombre_escena);
    }
}
