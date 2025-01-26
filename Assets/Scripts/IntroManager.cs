using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public GameObject button;
    public Image fade;
    [SerializeField] private float fadeTime;

    public GameObject launching;
    public GameObject rocket;
    [SerializeField] Vector3 rocket_launch_pos;
    [SerializeField] float rocket_launch_time;

    public GameObject spaceTraveling;
    public GameObject rocket2;
    [SerializeField] Vector3 rocket_travel_move_pos;
    [SerializeField] float rocket_travel_time;

    public GameObject landing;
    public GameObject rocket3;
    [SerializeField] Vector3 rocket_land_pos;
    [SerializeField] Vector3 rocket_land_scale;
    [SerializeField] float rocket_land_time;


    public void OnButtonClick()
    {
        if (launching.activeSelf)
            StartCoroutine(Launch());
        else if (spaceTraveling.activeSelf)
            StartCoroutine(SpaceTravel());
        else if (landing.activeSelf)
            StartCoroutine(Landing());
    }

    private IEnumerator Launch()
    {
        button.SetActive(false);

        yield return Move(rocket, rocket_launch_pos, rocket_launch_time);

        yield return Fade(true);

        launching.SetActive(false);
        spaceTraveling.SetActive(true);

        yield return Fade(false);

        button.SetActive(true);
    }

    private IEnumerator SpaceTravel()
    {
        button.SetActive(false);

        yield return Move(rocket2, rocket_travel_move_pos, rocket_travel_time);

        yield return Fade(true);

        spaceTraveling.SetActive(false);
        landing.SetActive(true);

        yield return Fade(false);

        button.SetActive(true);        
    }

    private IEnumerator Landing()
    {
        button.SetActive(false);

        Scale(rocket3, rocket_land_scale, rocket_land_time);
        yield return Move(rocket3, rocket_land_pos, rocket_land_time);

        yield return Fade(true);

        SceneManager.LoadScene(1);
    }

    private Coroutine Move(GameObject obj, Vector3 pos, float time)
    {
        return StartCoroutine(MoveAnimation(obj, pos, time));
    }
    private IEnumerator MoveAnimation(GameObject obj, Vector3 pos, float time)
    {
        var startPos = obj.transform.localPosition;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time;

            obj.transform.localPosition = Vector3.Lerp(startPos, pos, t);

            yield return null;
        }
    }

    private Coroutine Scale(GameObject obj, Vector3 scale, float time)
    {
        return StartCoroutine(ScaleRoutine(obj, scale, time));
    }
    private IEnumerator ScaleRoutine(GameObject obj, Vector3 scale, float time)
    {
        var startScale = obj.transform.localScale;

        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / time;

            obj.transform.localScale = Vector3.Lerp(startScale, scale, t);

            yield return null;
        }
    }

    private Coroutine Fade(bool b)
    {
        return StartCoroutine(FadeRoutine(b));
    }
    private IEnumerator FadeRoutine(bool b)
    {
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / fadeTime;

            float alpha = t;
            if (!b)
                alpha = 1 - t;
            var color = Color.black;
            color.a = alpha;

            fade.color = color;

            yield return null;
        }
    }
}
