using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction moveAction;
    public float movementDelayTimer = 0.2f; // Delay to prevent multiple inputs
    public float sideSpeed = 5f; // Speed of side movement
    public SpawnManager spawnManager;
    public static bool IsDead { get; private set; } = false;

    private static float[] _tracks;
    private int _currentTrackIndex;
    private Vector3 _targetPosition;
    private PlayerAnimationStateController playerAnim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction.Enable();
        _tracks = new[] { 11f, 15f, 19f }; // Left, Center, Right tracks
        _currentTrackIndex = 1; // Start at the center track
        playerAnim = GetComponent<PlayerAnimationStateController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void MovePlayer()
    {
        // Update the target position with continuous forward movement
        _targetPosition = new Vector3(_tracks[_currentTrackIndex], transform.position.y, transform.position.z);
        // Smoothly move the player towards the target position
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, sideSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        Vector2 move = moveAction.ReadValue<Vector2>();

        if (move.x < 0 && _currentTrackIndex > 0) // Move left
        {
            _currentTrackIndex--;
            moveAction.Disable(); // Temporarily disable input to prevent multiple triggers
            StartCoroutine(EnableMoveActionAfterDelay());
        }
        else if (move.x > 0 && _currentTrackIndex < _tracks.Length - 1) // Move right
        {
            _currentTrackIndex++;
            moveAction.Disable(); // Temporarily disable input to prevent multiple triggers
            StartCoroutine(EnableMoveActionAfterDelay());
        }
        _targetPosition = new Vector3(_tracks[_currentTrackIndex], transform.position.y, transform.position.z);

        MovePlayer();
    }

    private IEnumerator EnableMoveActionAfterDelay()
    {
        yield return new WaitForSeconds(movementDelayTimer);
        moveAction.Enable();
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnTrack"))
        {
            spawnManager.SpawnTrack();
        }

        if (other.gameObject.name.Contains("Obstacle"))
        {
            Debug.Log("Player hit an obstacle!");
            IsDead = true;
            playerAnim.PlayDeathAnimation(IsDead);            
            sideSpeed = 0f; // Stop player movement
            StartCoroutine(DeathTimer());
        }
    }

}