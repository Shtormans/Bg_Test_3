using MainMenu.Garage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace MainGame.Garage
{
    public class UICarsGenerator : MonoBehaviour
    {
        [SerializeField] private GarageCarUI _uiPrefab;
        [SerializeField] private HorizontalLayoutGroup _garageCarLayout;
        [SerializeField] private ScrollRect _scrollRect;

        [SerializeField] private Transform _parentGarageObject;
        [SerializeField] private List<GarageCar> _garageCars;

        private List<GarageCar> _instantiatedPrefabs;
        private const int _prefabsDistance = 20;

        private void OnEnable()
        {
            CreateCars();
            CreateUICars();
        }

        private void OnDisable()
        {
            DeleteCars();
            DeleteUICars();
        }

        private void CreateCars()
        {
            Vector3 position = Vector3.zero;

            _instantiatedPrefabs = _garageCars.Select(car =>
            {
                var prefab = Instantiate(car, position, Quaternion.identity, _parentGarageObject);
                position.x += _prefabsDistance;

                return prefab;
            }).ToList();
        }

        private void CreateUICars()
        {
            _instantiatedPrefabs.ForEach(car =>
            {
                var ui = Instantiate(_uiPrefab, _garageCarLayout.transform);

                ui.SetData(car, car.CarTexture);
                ui.transform.parent = _garageCarLayout.transform;
            });
        }

        private void DeleteCars()
        {
            _instantiatedPrefabs.ForEach(car =>
            {
                Destroy(car.gameObject);
            });

            _instantiatedPrefabs.Clear();
        }

        private void DeleteUICars()
        {
            for (int i = 0; i < _garageCarLayout.transform.childCount; i++)
            {
                var ui = _garageCarLayout.transform.GetChild(i).gameObject;
                Destroy(ui);
            }
        }
    }
}
