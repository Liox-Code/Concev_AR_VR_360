using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Presionar_Boton : MonoBehaviour
{
    public GameObject btn_AR;
    public GameObject btn_VR;
    public GameObject btn_360;
    public GameObject btn_cerrar_VR;
    public GameObject panel_Modelos;
    public GameObject panel_Opciones_Vistas;

    public GameObject [] btn_modelos;
    private string[] nombres_modelos = { "Edificio_1", "Miraflores_2"};
    //public GameObject btn_Seg;

    public Carga_Nivel_Transicion Animacion_Transicion;

    void Start()
    {
        btn_AR.GetComponent<Button>().onClick.AddListener(() => seleccionar_AR());
        btn_360.GetComponent<Button>().onClick.AddListener(() => panel_modelos_vista_seleccianda("Vista_360"));
        btn_VR.GetComponent<Button>().onClick.AddListener(() => panel_modelos_vista_seleccianda("Vista_VR"));
        btn_cerrar_VR.GetComponent<Button>().onClick.AddListener(() => panel_modelos(false));

        if (Global_Session.vr_Planos_Activado)
        {
            panel_modelos(Global_Session.vr_Planos_Activado);
        }

        for (int i = 0; i < nombres_modelos.Length; i++)
        {
            int index = i;
            btn_modelos[index].GetComponent<Button>().onClick.AddListener(() => seleccionar_VR(nombres_modelos[index]));
        }
    }

    private void cambiar_escena(string nombre_escena)
    {
        Animacion_Transicion.cargar_escena(nombre_escena,1);
    }

    private void seleccionar_AR()
    {
        cambiar_escena("Vista_Realidad_Aumentada");
    }

    private void seleccionar_360()
    {
        cambiar_escena("Vista_360");
    }

    private void seleccionar_VR(string nombre_modelo)
    {
        Global_Session.nombre_Modelo_Seleccionado = nombre_modelo;
        cambiar_escena(Global_Session.Vista_Seleccionada);
    }

    private void panel_modelos_vista_seleccianda (string vista_seleccionada)
    {
        Global_Session.Vista_Seleccionada = vista_seleccionada;
        Debug.Log(vista_seleccionada);
        panel_modelos(true);
    }

    private void panel_modelos(bool activar_desactivar)
    {
        Global_Session.vr_Planos_Activado = activar_desactivar;
        panel_Modelos.SetActive(activar_desactivar);
        panel_Opciones_Vistas.SetActive(!activar_desactivar);
    }
}
