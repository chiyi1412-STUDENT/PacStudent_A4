using UnityEngine;
using System.Collections;

public class PacStudentMover : MonoBehaviour
{
    public Transform[] points;          
    public float speedUnitsPerSec = 3f;
    public Animator animator;
    public AudioSource moveAudio;

    void Start()
    {

        if (points == null || points.Length < 2)
        {
            Debug.LogError($"[PacStudentMover] Need >=2 points, got {(points == null ? 0 : points.Length)}");
            enabled = false; return;
        }
        for (int k = 0; k < points.Length; k++)
        {
            if (points[k] == null) { Debug.LogError($"[PacStudentMover] points[{k}] is null"); enabled = false; return; }
        }

        transform.position = points[0].position;

        if (moveAudio != null) { moveAudio.loop = true; moveAudio.Play(); }
        StartCoroutine(LoopPath());
    }

    IEnumerator LoopPath()
    {
        int i = 0;
        while (true)
        {
            int next = (i + 1) % points.Length;
            Vector3 a = points[i].position;
            Vector3 b = points[next].position;

            SetAnimForSegment(a, b);

            float dist = Vector3.Distance(a, b);
            float duration = dist / Mathf.Max(0.0001f, speedUnitsPerSec);
            float t = 0f;

            while (t < duration)
            {
                t += Time.deltaTime;
                transform.position = Vector3.Lerp(a, b, Mathf.Clamp01(t / duration));
                yield return null;
            }
            i = next; 
        }
    }

    void SetAnimForSegment(Vector3 a, Vector3 b)
    {
        if (animator == null) return;
        Vector3 dir = (b - a).normalized;
        if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
        {
            animator.Play(dir.x > 0 ? "Walk_Right" : "Walk_Left");
        }
        else
        {
            animator.Play(dir.y > 0 ? "Walk_Up" : "Walk_Down");
        }
    }
}
