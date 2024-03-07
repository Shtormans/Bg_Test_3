using UnityEngine;

namespace MainMenu
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private Canvas _mainMenu;
        [SerializeField] private Canvas _garage;
        [SerializeField] private Canvas _loginCanvas;
        [SerializeField] private Canvas _registrationCanvas;
        [SerializeField] private Canvas _leaderboard;
        [SerializeField] private Canvas _personalSettings;

        private Canvas _currentCanvas;

        private void OnEnable()
        {
            _currentCanvas = _mainMenu;
        }

        public void ExitFromGame()
        {
            Application.Quit();
        }

        public void MoveToMainMenu()
        {
            ChangeCanvas(_mainMenu);
        }

        public void MoveToGarage()
        {
            ChangeCanvas(_garage);
        }

        public void MoveToLeaderboard()
        {
            ChangeCanvas(_leaderboard);
        }

        public void MoveToLogin()
        {
            ChangeCanvas(_loginCanvas);
        }

        public void MoveToRegistration()
        {
            ChangeCanvas(_registrationCanvas);
        }

        public void MoveToPersonalSettings()
        {
            ChangeCanvas(_personalSettings);
        }

        private void ChangeCanvas(Canvas canvas)
        {
            _currentCanvas.gameObject.SetActive(false);

            _currentCanvas = canvas;
            _currentCanvas.gameObject.SetActive(true);
        }
    }
}
