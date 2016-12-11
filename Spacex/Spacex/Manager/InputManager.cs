using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Spacex.Manager
{
    public class InputManager
    {
        private KeyboardState _oldKS;   // poprzedni stan  
        private KeyboardState _KS;      // obecny stan

        public InputManager()
        {
            Const.INPUT = this;     // obecne wywołanie InputManager
        }

        public void Update()
        {
            if (_KS != null)    // cokolwiek jest przypisane do zmiennej KS w chwili obecnej to poprzedni stan KS jest równy obecnemu stanowi KS
                _oldKS = _KS;

            _KS = Keyboard.GetState();  // przypisanie wartosci z obecnego stanu wciśnięcia przycisku (gdy nic nie jesy wciskane, przypisuje się null)
        }

        public bool isKeyPressed(Keys k)    // funkcja sprawdza czy dany przycisk jako argument funkcji (z klasy Keys) został właśnie wciśnięty, przy czym w poprzedniej klatce ten sam klawisz jest odciśnięty (Up)
        {
            return (_oldKS.IsKeyUp(k) && _KS.IsKeyDown(k));
        }

        public bool isKeyRelease(Keys k)
        {
            return (_oldKS.IsKeyUp(k) && _KS.IsKeyDown(k));
        }

        public KeyboardState currentState()
        {
            return this._KS;
        }
    }
}