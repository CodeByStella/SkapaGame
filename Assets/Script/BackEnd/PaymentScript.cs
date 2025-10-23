using System;
using System.Collections;
using UnityEngine;
using PlayDeck;
using UnityEngine.EventSystems;

public class PaymentScript : MonoBehaviour
{
    private int _smallAddCoinsCount = 50; 
    private int _mediumAddCoinsCount = 100; 
    private int _BigAddCoinsCount = 150; 

    private PlayDeckBridge _playDeckBridge;
    private string _currentExternalId;
    private MethodsAPIScript _methodsAPIScript;

    [SerializeField] private string _descriptionOrder;
    [SerializeField] private int _costOrder;

    void Start()
    {
        _playDeckBridge = FindObjectOfType<PlayDeckBridge>(); 
    }

    public void StartPayment()
    {
        _currentExternalId = Guid.NewGuid().ToString(); // ”никальный идентификатор
        var request = new PlayDeckBridge.PaymentRequestData
        {
            amount = _costOrder,
            description = _descriptionOrder,
            externalId = _currentExternalId,
        };

        _playDeckBridge.RequestPayment(request, OnPaymentRequested);
    }

    private void OnPaymentRequested(PlayDeckBridge.PaymentResponseData response)
    {
        _playDeckBridge.OpenTelegramLink(response.url);
        StartCoroutine(CheckPaymentStatus(_currentExternalId));
    }

    private IEnumerator CheckPaymentStatus(string externalId)
    {
        bool paymentChecked = false;
        float timeout = 60f;
        float checkInterval = 5f;
        float timeElapsed = 0f;

        while (!paymentChecked && timeElapsed < timeout)
        {
            yield return new WaitForSeconds(checkInterval);
            timeElapsed += checkInterval;

            var infoRequest = new PlayDeckBridge.GetPaymentInfoRequestData { externalId = externalId };
            _playDeckBridge.GetPaymentInfo(infoRequest, (infoResponse) =>
            {
                if (infoResponse.paid)
                {
                    paymentChecked = true;
                    Debug.Log("ќплата успешна!");

                    if (gameObject.name == "BuySomeCoins")
                    {
                        MethodsAPIScript.Instance.UpdateCoins(_smallAddCoinsCount);
                    }
                    else if (gameObject.name == "BuyAverageCoins")
                    {
                        MethodsAPIScript.Instance.UpdateCoins(_mediumAddCoinsCount);
                    }
                    else if (gameObject.name == "BuyLotOfCoins")
                    {
                        MethodsAPIScript.Instance.UpdateCoins(_BigAddCoinsCount);
                    }
                    else if (gameObject.name == "BuyTrickChristButton") 
                    {
                        MethodsAPIScript.Instance.PurchaseTrick(6);
                    }
                    else if (gameObject.name == "BuyTrickBenihanaButton") 
                    {
                        MethodsAPIScript.Instance.PurchaseTrick(7);
                    }
                    else if (gameObject.name == "Trick360Button") 
                    {
                        MethodsAPIScript.Instance.PurchaseTrick(8);
                    }
                    else if (gameObject.name == "BuyTrick360ChristButton") 
                    {
                        MethodsAPIScript.Instance.PurchaseTrick(9);
                    }
                    else if (gameObject.name == "BuyTrickBackFlipButton") 
                    {
                        MethodsAPIScript.Instance.PurchaseTrick(10);
                    }
                }
                else
                {
                    Debug.Log("ќплата ещЄ не завершена.");
                }
            });
        }

        if (!paymentChecked)
        {
            Debug.Log("¬рем€ проверки оплаты истекло.");
        }
    }
    public void OnPointerClicker(PointerEventData eventData)
    {
        Debug.Log(" ликнут: " + gameObject.name);
        // eventData.pointerPress Ц объект, который был нажат
    }
}
