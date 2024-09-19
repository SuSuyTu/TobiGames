using UnityEngine;
using TMPro;
using Image = UnityEngine.UI.Image;

public class BotIndicator : MonoBehaviour
{
    public CharacterCtrl target;
    public Transform targetTf;

    [SerializeField] private TMP_Text enemyName;

    // [SerializeField] private GameObject enemyIcon;
    // [SerializeField] private GameObject arrowIcon;
    [SerializeField] private GameObject canvasBotIndicator;

    private Transform characterTf;
    // private Transform enemyTf;
    // private Transform arrowTf;

    // [SerializeField] private Image enemyColor;
    // [SerializeField] private Image arrowColor;

    // private Vector3 screenCentre;
    private Vector3 offset = new Vector3(-1.5f, 1.5f, 0);

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
        // enemyTf = enemyIcon.transform;
        // arrowTf = arrowIcon.transform;
        //characterTf = characterInfo.transform;
        //screenCentre = new Vector3(Screen.width, Screen.height, 0) / 2;
    }
    // private void OnEnable()
    // {
    //     enemyColor.color = target.CharacterSkin.SkinRenderer.material.color;
    //     arrowColor.color = target.CharacterSkin.SkinRenderer.material.color;
    // }
    public void OnInit(CharacterCtrl bot, Transform botTf)
    {
        target = bot;
        targetTf = botTf;
        canvasBotIndicator.transform.rotation = Quaternion.Euler(50f, 0, 0);

        // characterTf = targetTf;
        // enemyName.SetText(target.characterName);
        // enemyColor.color = bot.CharacterSkin.SkinRenderer.material.color;
        // arrowColor.color = bot.CharacterSkin.SkinRenderer.material.color;
    }
    private void Update()
    {
        // Vector3 screenPosition = GetScreenPosition(mainCamera, targetTf.position);
        // bool isTargetVisible = IsTargetVisible(screenPosition);
        enemyName.SetText(target.characterName);

        canvasBotIndicator.transform.position = targetTf.position + offset + new Vector3(0, target.transform.localScale.x * 2f, 0);
        
        
        
        //transform.parent.position = CharacterPos;
        // if (isTargetVisible)
        // {
        //     enemyIcon.SetActive(false);
        //     arrowIcon.SetActive(false);
        // }
        // else
        // {
        //     enemyIcon.SetActive(true);
        //     arrowIcon.SetActive(true);
        //     MoveArrow();
        //     MoveIcon();

        // }

    }

    // private void OnEnable() {
    //     enemyName.SetText(target.characterName);
    // }
    // public void MoveArrow()
    // {
    //     float minX = arrowTf.localScale.x / 2 + 50;
    //     float minY = arrowTf.localScale.y / 2 + 50;

    //     float maxX = Screen.width - minX - 50;
    //     float maxY = Screen.height - minY - 50;

    //     Vector3 pos = mainCamera.WorldToScreenPoint(targetTf.position + offset);

    //     if (pos.z < 0)
    //     {
    //         pos.y = Screen.height - pos.y;
    //         pos.x = Screen.width - pos.x;
    //     }

    //     pos.x = Mathf.Clamp(pos.x, minX, maxX);
    //     pos.y = Mathf.Clamp(pos.y, minY, maxY);
    //     pos.z = 0;

    //     arrowTf.position = pos;

    //     Vector2 direction = new Vector2(pos.x - screenCentre.x, pos.y - screenCentre.y);
    //     float angle = Vector3.Angle(Vector2.up, direction);
    //     Vector3 cross = Vector3.Cross(Vector2.up, direction);

    //     if (cross.z < 0) angle = -angle;

    //     arrowTf.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    // }
    // public void MoveIcon()
    // {
    //     float minX = enemyTf.localScale.x / 2 + 100;
    //     float minY = enemyTf.localScale.y / 2 + 80;

    //     float maxX = Screen.width - minX - 80;
    //     float maxY = Screen.height - minY - 100;

    //     Vector3 pos = mainCamera.WorldToScreenPoint(targetTf.position + offset);

    //     if (pos.z < 0)
    //     {
    //         pos.y = Screen.height - pos.y;
    //         pos.x = Screen.width - pos.x;
    //     }

    //     pos.x = Mathf.Clamp(pos.x, minX, maxX);
    //     pos.y = Mathf.Clamp(pos.y, minY, maxY);
    //     pos.z = 0;

    //     enemyTf.position = pos;
    // }

    // public static Vector3 GetScreenPosition(Camera mainCamera, Vector3 targetPosition)
    // {
    //     Vector3 screenPosition = mainCamera.WorldToScreenPoint(targetPosition);
    //     return screenPosition;
    // }

    // public static bool IsTargetVisible(Vector3 screenPosition)
    // {
    //     bool isTargetVisible = screenPosition.z > 0 && screenPosition.x > 0 && screenPosition.x < Screen.width && screenPosition.y > 0 && screenPosition.y < Screen.height;
    //     return isTargetVisible;
    // }

}
