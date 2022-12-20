using System.Collections;
using UnityEngine;
using RPG.Saving;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        private const string defaultSaveFile = "Save";
        [SerializeField] private float fadeInTime = 0.2f;

        private IEnumerator Start()
        {
            Fader fader = FindObjectOfType<Fader>();

            fader.FadeOutInmediate();

            yield return GetComponent<SavingSystem>().LoadLastScene(defaultSaveFile);

            yield return fader.FadeIn(fadeInTime);
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }

            if(Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        public void Load()
        {
            GetComponent<SavingSystem>().Load(defaultSaveFile);
        }

        public void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSaveFile);
        }
    }
}