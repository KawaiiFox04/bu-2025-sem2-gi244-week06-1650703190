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
        // หาค่ากึ่งกลาง
        float midX = (player1Pos.x + player2Pos.x) / 2f;
        float midZ = (player1Pos.z + player2Pos.z) / 2f;

        transform.position = new Vector3(midX, transform.position.y, midZ + offset);

        // คำนวณระยะห่างจริง
        float distance = Vector3.Distance(player1Pos, player2Pos);

        // ปรับ zoom
        targetCamera.orthographicSize = distance;
    }
}
