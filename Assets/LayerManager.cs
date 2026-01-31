using UnityEngine;
using UnityEngine.UI;

public class LayerManager : MonoBehaviour
{
    private Layer layer1;
    private Layer layer2;
    private Layer layer3;
    private Layer layer4;
    private Layer layer5;
    [SerializeField] Slider verticalSlider;
    [SerializeField] Slider horizontalSlider;
    public float moveValue;
    private Layer currentLayer;

    public static LayerManager Instance {  get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        verticalSlider.gameObject.SetActive(false);
        horizontalSlider.gameObject.SetActive(false);
    }

    public void InitLayers()
    {
        verticalSlider.gameObject.SetActive(false);
        horizontalSlider.gameObject.SetActive(false);   
        layer1 = GameObject.FindGameObjectWithTag("Layer1").GetComponent<Layer>();
        layer2 = GameObject.FindGameObjectWithTag("Layer2").GetComponent<Layer>();
        layer3 = GameObject.FindGameObjectWithTag("Layer3").GetComponent<Layer>();
        layer4 = GameObject.FindGameObjectWithTag("Layer4").GetComponent<Layer>();
        layer5 = GameObject.FindGameObjectWithTag("Layer5").GetComponent<Layer>();
    }

    public void LayerButton1()
    {
        currentLayer = layer1;
        if(layer1.canToggle) 
        {
            layer1.gameObject.SetActive(!layer1.gameObject.activeSelf);
            verticalSlider.gameObject.SetActive(false);
            horizontalSlider.gameObject.SetActive(false);
        }
        if (layer1.canMove)
        {
            verticalSlider.gameObject.SetActive(true);
            horizontalSlider.gameObject.SetActive(true);
            verticalSlider.SetValueWithoutNotify(layer1.vertical);
            horizontalSlider.SetValueWithoutNotify(layer1.horizontal);
        }
    }

    public void LayerButton2()
    {
        currentLayer = layer2;
        if (layer2.canToggle)
        {
            layer2.gameObject.SetActive(!layer2.gameObject.activeSelf);
            verticalSlider.gameObject.SetActive(false);
            horizontalSlider.gameObject.SetActive(false);
        }
        if (layer2.canMove)
        {
            verticalSlider.gameObject.SetActive(true);
            horizontalSlider.gameObject.SetActive(true);
            verticalSlider.SetValueWithoutNotify(layer2.vertical);
            horizontalSlider.SetValueWithoutNotify(layer2.horizontal);
        }         
    }

    public void LayerButton3()
    {
        currentLayer = layer3;
        if (layer3.canToggle)
        {
            layer3.gameObject.SetActive(!layer3.gameObject.activeSelf);
            verticalSlider.gameObject.SetActive(false);
            horizontalSlider.gameObject.SetActive(false);
        }
        if (layer3.canMove)
        {
            verticalSlider.gameObject.SetActive(true);
            horizontalSlider.gameObject.SetActive(true);
            verticalSlider.SetValueWithoutNotify(layer3.vertical);
            horizontalSlider.SetValueWithoutNotify(layer3.horizontal);
        }
    }

    public void LayerButton4()
    {
        currentLayer = layer4;
        if (layer4.canToggle)
        {
            layer4.gameObject.SetActive(!layer4.gameObject.activeSelf);
            verticalSlider.gameObject.SetActive(false);
            horizontalSlider.gameObject.SetActive(false);
        }
        if (layer4.canMove) 
        {
            verticalSlider.gameObject.SetActive(true);
            horizontalSlider.gameObject.SetActive(true);
            verticalSlider.SetValueWithoutNotify(layer4.vertical);
            horizontalSlider.SetValueWithoutNotify(layer4.horizontal);
        }
    }

    public void LayerButton5()
    {
        currentLayer = layer5;
        if (layer5.canToggle)
        {
            layer5.gameObject.SetActive(!layer5.gameObject.activeSelf);
            verticalSlider.gameObject.SetActive(false);
            horizontalSlider.gameObject.SetActive(false);
        }
        if (layer5.canMove)
        {
            verticalSlider.gameObject.SetActive(true);
            horizontalSlider.gameObject.SetActive(true);
            verticalSlider.SetValueWithoutNotify(layer5.vertical);
            horizontalSlider.SetValueWithoutNotify(layer5.horizontal);
        }
    }

    public void OnHorizontalSliderChanged()
    {
        if (currentLayer == null) return;
        currentLayer.MoveH(horizontalSlider.value);
    }

    public void OnVerticalSliderChanged()
    {
        if (currentLayer == null) return;
        currentLayer.MoveV(verticalSlider.value);
    }
}
