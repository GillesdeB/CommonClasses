using System;
using System.Collections.Generic;
using System.Text;

namespace Common_Classes
{
    /// <summary>
    /// Display a modal message accross the screen
    /// </summary>
    class UserMessages
    {
        public static async void messageBox(string msg)
        {
            var msgDlg = new Windows.UI.Popups.MessageDialog(msg);
            msgDlg.DefaultCommandIndex = 1;
            await msgDlg.ShowAsync();
        }

    }
}
