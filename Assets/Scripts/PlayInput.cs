using UnityEngine;


public class PlayInput : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public Joystick joystick;
    
    [SerializeField] private bool isJoyStick;


    private float verticalMove;
    private float horizontalDirection;
    private bool isJumpButtonPressed;

    private void Awake()
    {
        Debug.Log(PlayerPrefs.GetInt("isJoyStick"));
        _playerMovement = GetComponent<PlayerMovement>();
        if(isJoyStick = System.Convert.ToBoolean(PlayerPrefs.GetInt("isJoyStick"))){
            joystick.gameObject.SetActive(isJoyStick);
        }
        else{
            joystick.gameObject.SetActive(isJoyStick);
        }
    }

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("isJoyStick"));
        Debug.Log(System.Convert.ToBoolean(PlayerPrefs.GetInt("isJoyStick")));
        if (System.Convert.ToBoolean(PlayerPrefs.GetInt("isJoyStick"))){
            joystick.gameObject.SetActive(true);
            verticalMove = joystick.Vertical;
            horizontalDirection = joystick.Horizontal;
            isJumpButtonPressed = verticalMove > 0.6f;
            _playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }
        else{
            joystick.gameObject.SetActive(false);
            horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);
            _playerMovement.Move(horizontalDirection, isJumpButtonPressed);
        }
    }

} 
