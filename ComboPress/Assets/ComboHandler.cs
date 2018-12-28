using UnityEngine;

namespace Wokarol.AdvancedInput
{
    public class ComboHandler
    {
        public bool OnComboDown { get; private set; }
        bool _comboPressed = false;

        Key[] _keys;
        float _waitTime;



        public void Tick() {
            bool isAnyPressed = false;
            bool isAllPressed = true;
            for (int i = 0; i < _keys.Length; i++) {
                if (Input.GetKeyDown(_keys[i].KeyCode)) {
                    _keys[i].Counter = _waitTime;
                }
                if (Input.GetKeyUp(_keys[i].KeyCode)) {
                    _keys[i].Counter = -1;
                }
                if(_keys[i].Counter > 0) {
                    _keys[i].Counter -= Time.deltaTime;
                    isAnyPressed = true;
                } else {
                    isAllPressed = false;
                }
            }

            if(isAllPressed && !_comboPressed) {
                _comboPressed = true;
                OnComboDown = true;
            } else if (_comboPressed) {
                OnComboDown = false;
            }

            if(!isAnyPressed && _comboPressed) {
                _comboPressed = false;
            }
        }

        public ComboHandler (float waitTime, params KeyCode[] keys) {
            _keys = new Key[keys.Length];
            for (int i = 0; i < _keys.Length; i++) {
                _keys[i] = new Key(keys[i]);
            }
            _waitTime = waitTime;
        }
    }

    struct Key
    {
        private KeyCode _keyCode;
        private float _counter;

        public KeyCode KeyCode => _keyCode;
        /// <summary>
        /// Key is active if this value is positive
        /// </summary>
        public float Counter { get => _counter; set => _counter = value; }

        public Key(KeyCode keyCode) {
            _keyCode = keyCode;
            _counter = -1;
        }
    }
}