using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerControllerExam03 : MonoBehaviour
{
    public float speed;
    public float xRange = 10;
    public GameObject projectilePrefab;

    public bool enableAutoFireMode;
    public float autoFireInterval = 0.1f;

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private Coroutine autoFireCoroutine;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        // Move
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        // Clamp X
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        // กดครั้งเดียว
        if (shootAction.triggered)
        {
            if (enableAutoFireMode)
            {
                // ป้องกันการ Start ซ้ำ
                if (autoFireCoroutine == null)
                    autoFireCoroutine = StartCoroutine(AutoFire());
            }
            else
            {
                Instantiate(projectilePrefab, transform.position, transform.rotation);
            }
        }
    }

    IEnumerator AutoFire()
    {
        while (true)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(autoFireInterval);
        }
    }
}