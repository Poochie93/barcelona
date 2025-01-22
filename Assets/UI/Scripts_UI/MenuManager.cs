using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance;

    public static MenuManager Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        // Verificar si ya existe una instancia del menú
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Mantener el objeto entre escenas
        }
        else
        {
            Destroy(gameObject); // Si ya existe una instancia, destruir este objeto duplicado
        }
    }

    // Método para cargar la escena
    public void LoadScene(string sceneName)
    {
        // Cambiar de escena
        SceneManager.LoadScene(sceneName);
    }

    // Método para salir del juego
    public void QuitGame()
    {
        Application.Quit();
    }

    // Método que se llama cuando una nueva escena ha sido cargada
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Método que maneja la carga de una nueva escena
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Si se carga la escena llamada "Scene" (juego), desactivar el menú
        if (scene.name == "Scene")
        {
            gameObject.SetActive(false);  // Desactivar el menú cuando estamos en la escena del juego
        }
        else
        {
            // Si no estamos en la escena del juego, asegurarnos de que el menú esté activo
            gameObject.SetActive(true);
        }
    }

    // Desuscribirse del evento cuando se destruye el objeto
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Actualización en cada frame
    void Update()
    {
        // Verifica si estamos en la escena "Scene" (juego) y si se presiona Escape
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Ajustes")
        {
            // Si no estamos en la escena "Scene", mostrar el menú
            gameObject.SetActive(true); // Activar el menú
        }
    }
}