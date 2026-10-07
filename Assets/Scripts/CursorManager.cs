using UnityEngine;

public class CursorManager : MonoBehaviour
{

    public static CursorManager Instance { get; private set;}

    [SerializeField] private Texture2D cursorTextureDefault;
    [SerializeField] private Texture2D cursorTextureHover;

    [SerializeField] private Vector2 clickPosition = Vector2.zero;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
    }

    public void SetToMode(ModeOfCursor modeOfCursor)
    {
        switch (modeOfCursor)
        {
            case ModeOfCursor.Default:
                Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
                break;
            case ModeOfCursor.Hover:
                Cursor.SetCursor(cursorTextureHover, clickPosition, CursorMode.Auto);
                break;
            default:
                Cursor.SetCursor(cursorTextureDefault, clickPosition, CursorMode.Auto);
                break;
        }
    }
}
