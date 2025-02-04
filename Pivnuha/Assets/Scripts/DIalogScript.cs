using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DIalogScript : MonoBehaviour
{
    [SerializeField] private GameObject journal;

    [SerializeField] private GameObject dialogWindow;
    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private GameObject messageQuestDone;
    [SerializeField] private TextMeshProUGUI textMessage;

    [SerializeField] private GameObject messageDayDone;
    [SerializeField] private Image udivlinie;

    [SerializeField] private Image done1;
    [SerializeField] private Image done2;
    [SerializeField] private Image done3;
    [SerializeField] private Image done4;

    private bool isNPC = false;

    bool quest1 = false;
    bool quest2 = false;
    bool quest3 = false;
    bool quest4 = false;

    bool dayDone = false;

    private GameObject NPC;

    void Start()
    {
        StartCoroutine(monologWithStranger());
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q) && !journal.activeSelf)
        {
            journal.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Q) && journal.activeSelf)
        {
            journal.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.E) && isNPC)
        {
            switch (NPC.tag)
            {
                case "NPCPasha":
                    StartCoroutine(dialogWithPasha(NPC.GetComponent<NPCScript>().Message()));
                    break;
                case "NPCVlad":
                    StartCoroutine(dialogWithVlad(NPC.GetComponent<NPCScript>().Message()));
                    break;
                case "NPCKirill":
                    StartCoroutine(dialogWithKirill(NPC.GetComponent<NPCScript>().Message()));
                    break;
                case "NPCLera":
                    StartCoroutine(dialogWithLera(NPC.GetComponent<NPCScript>().Message()));
                    break;
                case "NPCKollector":
                    NPC.GetComponent<NPCScript>().Message();
                    StartCoroutine(dialogWithStranger());
                    break;
            }
        }

        if (Input.GetKeyUp(KeyCode.R) && isNPC)
        {
            NPC.GetComponent<NPCScript>().Message1();
        }
    }

    IEnumerator monologWithStranger()
    {
        yield return new WaitForSeconds(2f);
        dialogWindow.SetActive(true);
        text.text = "Краем галаза вы замечаете как в таверну заходит незнакомец в капюшоне.";
        yield return new WaitForSeconds(3f);
        text.text = "Грузный мужчина суровым взглядом осматривает помещение.";
        yield return new WaitForSeconds(3f);
        text.text = "Его взгляд останавливается на вас. Вам не по себе.";
        yield return new WaitForSeconds(3f);
        text.text = "Его длинный наряд не позволяет рассмотреть что у него под мантией.";
        yield return new WaitForSeconds(3f);
        text.text = "Явно опасные предметы.";
        yield return new WaitForSeconds(2f);
        text.text = "Ваше состязание взглядов окончилось тем, что он хмыкнув побрел в тихий и темный угол таверны.";
        yield return new WaitForSeconds(4f);
        text.text = "Вы с опаской следите за ним.";
        yield return new WaitForSeconds(3f);
        text.text = "Все же собираетесь с мыслями и решаетесь взять у него заказ.";
        yield return new WaitForSeconds(3f);
        dialogWindow.SetActive(false);
    }
    IEnumerator dialogWithStranger()
    {
        yield return new WaitForSeconds(1.9f);
        dialogWindow.SetActive(true);
        text.text = "Дмитрий: Опять реклама.";
        yield return new WaitForSeconds(2.1f);
        udivlinie.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        udivlinie.gameObject.SetActive(false);
        text.text = "Дмитрий: А какие? Какие!?";
        yield return new WaitForSeconds(6.3f);
        text.text = "Дмитрий: Единовременно?!";
        yield return new WaitForSeconds(3.2f);
        text.text = "Дмитрий: Какие? Засадные?";
        yield return new WaitForSeconds(3.3f);
        text.text = "Дмитрий: А можно с челубеем, натяну монголов!";
        yield return new WaitForSeconds(8f);
        text.text = "Дмитрий: И репу для фистинга пожалуйста!";
        yield return new WaitForSeconds(4f);
        text.text = "Дмитрий: Пойду потешать петрушку.";
        yield return new WaitForSeconds(2.5f);
        dialogWindow.SetActive(false);
    }
    IEnumerator dialogWithPasha(float timeMessage)
    {
        yield return new WaitForSeconds(timeMessage);
        dialogWindow.SetActive(true);
        text.text = "Дмитрий: Пива налей";
        yield return new WaitForSeconds(3f);
        text.text = "Дмитрий: Спс, пойду к Владу. ББ";
        yield return new WaitForSeconds(3f);
        dialogWindow.SetActive(false);

        if (!quest1)
        {
            quest1 = true;
            messageQuestDone.SetActive(true);
            done1.gameObject.SetActive(true);
            textMessage.text = "Красавчик блять, набухался, а лучшеб работу нашел";
            yield return new WaitForSeconds(3f);
            messageQuestDone.SetActive(false);
        }

        CheckDoneDay();
    }
    IEnumerator dialogWithVlad(float timeMessage)
    {
        yield return new WaitForSeconds(timeMessage);
        dialogWindow.SetActive(true);
        text.text = "Дмитрий: Чет ты сегодня не в настроенни, пойду лучше к мусорку";
        yield return new WaitForSeconds(3f);
        dialogWindow.SetActive(false);

        if (!quest2)
        {
            quest2 = true;
            messageQuestDone.SetActive(true);
            done2.gameObject.SetActive(true);
            textMessage.text = "Агрессив мен какойто";
            yield return new WaitForSeconds(3f);
            messageQuestDone.SetActive(false);
        }

        CheckDoneDay();
    }
    IEnumerator dialogWithKirill(float timeMessage)
    {
        yield return new WaitForSeconds(timeMessage);
        dialogWindow.SetActive(true);
        text.text = "Дмитрий: Бот ебаный, иди людей вяжи, хатьфу тебе в ебало";
        yield return new WaitForSeconds(3f);
        dialogWindow.SetActive(false);

        if (!quest3)
        {
            quest3 = true;
            messageQuestDone.SetActive(true);
            done3.gameObject.SetActive(true);
            textMessage.text = "Попустил мусора!";
            yield return new WaitForSeconds(3f);
            messageQuestDone.SetActive(false);
        }

        CheckDoneDay();
    }
    IEnumerator dialogWithLera(float timeMessage)
    {
        yield return new WaitForSeconds(timeMessage);
        dialogWindow.SetActive(true);
        text.text = "Дмитрий: Мда, Лера в ахуе с происходящего";
        yield return new WaitForSeconds(3f);
        dialogWindow.SetActive(false);

        if (!quest4)
        {
            quest4 = true;
            messageQuestDone.SetActive(true);
            done4.gameObject.SetActive(true);
            textMessage.text = "А че она здесь забыла?";
            yield return new WaitForSeconds(3f);
            messageQuestDone.SetActive(false);
        }

        CheckDoneDay();
    }

    private void CheckDoneDay()
    {
        if (quest1 && quest2 && quest3 && quest4 && !dayDone)
        {
            dayDone = true;
            StartCoroutine(DayDone());
        }
    }

    IEnumerator DayDone()
    {
        messageDayDone.SetActive(true);
        yield return new WaitForSeconds(3f);
        messageDayDone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.StartsWith("NPC"))
        {
            isNPC = true;
            NPC = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            isNPC = false;
            NPC = null;
        }
    }
}
