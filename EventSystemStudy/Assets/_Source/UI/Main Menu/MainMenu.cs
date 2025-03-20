using UISystem;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private ResourceItemCreator resourceItemCreator;
    [SerializeField] private Button resetButton;

    public ResourceItemCreator ResourceItemCreator { get { return resourceItemCreator; } }
    public Button ResetButton { get { return resetButton; } }
}
