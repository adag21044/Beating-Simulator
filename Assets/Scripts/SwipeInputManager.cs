using UnityEngine;

public class SwipeInputManager : MonoBehaviour
{
    private static SwipeInputManager _instance;
    public static SwipeInputManager Instance => _instance;

    public Vector2 StartTouch { get; private set; }
    public Vector2 EndTouch { get; private set; }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool DetectSwipe(out Vector2 swipeDelta)
    {
        swipeDelta = Vector2.zero;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                StartTouch = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                EndTouch = touch.position;
                swipeDelta = EndTouch - StartTouch;
                return true;
            }
        }
        return false;
    }
}
