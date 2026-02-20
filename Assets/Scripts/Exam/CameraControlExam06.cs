using UnityEngine;

public class CameraControlExam06 : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public float offset;
    public Camera targetCamera;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 player1Pos = player1.transform.position;
        Vector3 player2Pos = player2.transform.position;

        // Student code ...
        // หาจุดกึ่งกลางของผู้เล่นทั้งสอง
        float midX = player1Pos.x;
        float midZ = player2Pos.z;

        Vector3 newPosition = new Vector3(midX, transform.position.y, midZ + offset);
        transform.position = newPosition;

        // คำนวณระยะห่างเพื่อใช้ zoom
        float distance = Mathf.Abs(player1Pos.x - player2Pos.z);

        // ปรับขนาดกล้อง (zoom)
        targetCamera.orthographicSize = distance;
    }
}
