using System;

namespace ui
{
    using System.Collections.Generic;
    using contracts;

    public class UserInterfaceAdapter : IUserInterface
    {
        private readonly Action<string> _displayAction;

        public UserInterfaceAdapter(Action<string> displayAction)
        {
            _displayAction = displayAction;
        }

        public void ShowResult(IEnumerable<int> decimalNumbers)
        {
            foreach (var number in decimalNumbers)
            {
                _displayAction(number.ToString());
            }
        }
    }
}
