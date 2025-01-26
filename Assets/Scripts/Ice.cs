using UnityEngine;

public class Ice : MonoBehaviour
{
    private bool interactable = false;
    private UIManager uimanager;
    [SerializeField] private int waterAmount = 5;
    public SpriteRenderer hint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        uimanager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && interactable)
        {
            uimanager.AddWater(waterAmount);
            interactable = false;
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            interactable = true;
            hint.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name == "Player")
            interactable = false;
            hint.gameObject.SetActive(false);
    }
}
