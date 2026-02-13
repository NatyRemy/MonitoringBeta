using UnityEngine;
using UnityEngine.UI;

public class LookAtShadow : MonoBehaviour
{
    public Camera playerCamera;
    public Image screenImage;

    [Header("Fade")]
    public float fadeSpeed = 2f;

    float currentAlpha = 0f;
    Collider col;

    void Start()
    {
        col = GetComponent<Collider>();

        if (!playerCamera)
            playerCamera = Camera.main;

        SetImageAlpha(0f);
    }

    void Update()
    {
        bool isLooking = IsPlayerLookingAtShadow();

        if (isLooking)
            currentAlpha += fadeSpeed * Time.deltaTime;
        else
            currentAlpha -= fadeSpeed * Time.deltaTime;

        currentAlpha = Mathf.Clamp01(currentAlpha);
        SetImageAlpha(currentAlpha);
    }

    bool IsPlayerLookingAtShadow()
    {
        if (!playerCamera || !col) return false;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.collider == col;
        }

        return false;
    }

    void SetImageAlpha(float a)
    {
        if (!screenImage) return;

        Color c = screenImage.color;
        c.a = a;
        screenImage.color = c;
    }

    // DEBUG opcional
    void OnDrawGizmos()
    {
        if (!playerCamera) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 10f);
    }
}
