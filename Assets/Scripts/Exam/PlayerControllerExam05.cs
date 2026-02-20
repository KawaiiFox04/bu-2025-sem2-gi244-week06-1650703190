using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerExam05 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    // Exam 05
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 4f;

    private int currentBulletCount;
    private bool isReloading;
    private float reloadTimer;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Start()
    {
        currentBulletCount = maxBulletCount;
    }

    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Reload logic
        if (isReloading)
        {
            reloadTimer += Time.deltaTime;

            if (reloadTimer >= bulletRegenerateCooldown)
            {
                currentBulletCount = maxBulletCount;
                isReloading = false;
                reloadTimer = 0f;

                Debug.Log("Bullet regenerated!");
            }
        }

        // Shoot logic
        if (shootAction.triggered && !isReloading)
        {
            if (currentBulletCount > 0)
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
                currentBulletCount--;

                Debug.Log("Shoot! Bullets left: " + currentBulletCount);

                if (currentBulletCount <= 0)
                {
                    isReloading = true;
                    reloadTimer = 0f;
                    Debug.Log("Out of bullets! Reloading...");
                }
            }
        }
    }
}